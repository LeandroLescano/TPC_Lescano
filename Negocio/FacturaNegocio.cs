using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using Dominio;
using AccesoDatos;
using System.Windows.Forms;

namespace negocioCom
{
    public class FacturaNegocio
    {
        public int agregarFactura(Factura nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO FACTURAS (NUMERO, CUIT ,IDDOMICILIO, FECHAINICIO, FECHAACTUAL, INGRESOSBRUTOS) " +
                                         "VALUES(@NumFactura, @CUIT, @Domicilio, @FechaInicio, @FechaActual, @IngresosB) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", nueva.Domicilio.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@NumFactura", nueva.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nueva.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaInicio", nueva.FechaInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaActual", nueva.FechaActual);
                accesoDatos.Comando.Parameters.AddWithValue("@IngresosB", nueva.IngresosBrutos);
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        internal Factura listarFactura(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                DomicilioNegocio negocioD = new DomicilioNegocio();
                Factura nueva = new Factura();
                accesoDatos.setearConsulta("SELECT * FROM FACTURAS WHERE ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva.Numero = accesoDatos.Lector.GetString(1);
                    nueva.CUIT = accesoDatos.Lector.GetString(2);
                    nueva.Domicilio = negocioD.listarDomicilio(accesoDatos.Lector.GetInt32(3));
                    nueva.FechaInicio = accesoDatos.Lector.GetDateTime(4);
                    nueva.FechaActual = accesoDatos.Lector.GetDateTime(5);
                    nueva.IngresosBrutos = accesoDatos.Lector.GetString(6);

                }
                return nueva;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void FacturaWord(Factura fact, Venta venta)
        {
            Word.Application wordApp;
            Word.Document aDoc;

            object missing = Missing.Value;
            object filename;
                wordApp = new Word.Application();

            try
            {
                string rutaArchivo = Path.GetFullPath("Factura.docx");
                File.Copy(rutaArchivo, Path.Combine(Application.StartupPath, "Factura "+ NumeroNuevaFact() +".docx") , true);
                filename = Path.Combine(Application.StartupPath, "Factura " + NumeroNuevaFact() + ".docx");

                if(File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;
                    aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible,
                        ref missing, ref missing, ref missing, ref missing);
                    aDoc.Activate();
                    reemplazarDoc(wordApp, fact, venta);
                    aDoc.Save();
                    object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                    wordApp.Quit(ref saveChanges, ref missing, ref missing);
                }
                else
                {
                    MessageBox.Show("El archivo no existe.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                wordApp.Quit(ref saveChanges, ref missing, ref missing);
                throw ex;
            }
        }

        private void reemplazarDoc(Word.Application doc, Factura f, Venta v)
        {
            ComercioNegocio negocioCom = new ComercioNegocio();
            Comercio comercio = negocioCom.listarComercio();
            int index = 1;
            foreach (DetalleVenta item in f.ListadoProductos)
            {
                findAndReplace(doc, "{Cant" + index + "}", (item.Cantidad + item.Kilos).ToString());
                findAndReplace(doc, "{Prod" + index + "}", item.Producto.Nombre.ToString());
                findAndReplace(doc, "{Precio" + index + "}", Math.Round(item.Producto.PrecioUnitario,2).ToString());
                findAndReplace(doc, "{SubT" + index + "}", Math.Round(item.PrecioParcial,2).ToString());
                index++;
            }
            findAndReplace(doc, "{Numero}", NumeroNuevaFact());
            findAndReplace(doc, "{FechaActual}", f.FechaActual.Date);
            findAndReplace(doc, "{Comercio}", comercio.NombreFantasia);
            findAndReplace(doc, "{Domicilio}", f.Domicilio.ToString());
            findAndReplace(doc, "{IngresosB}", f.IngresosBrutos);
            findAndReplace(doc, "{FechaInicio}", f.FechaInicio);
            findAndReplace(doc, "{Cliente}", v.Cliente.ToString());
            findAndReplace(doc, "{PrecioNeto}", v.Importe);
            findAndReplace(doc, "{PrecioFinal}", v.Importe);

            for (int i = index; i <= 30 ; i++)
            {
                findAndReplace(doc, "{Cant" + i + "}", "");
                findAndReplace(doc, "{Prod" + i + "}", "");
                findAndReplace(doc, "{Precio" + i + "}", "");
                findAndReplace(doc, "{SubT" + i + "}", "");
            }

        }

        public void findAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms,
                ref forward, ref wrap, ref format, ref replaceText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        public string NumeroNuevaFact()
        {

            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("select top 1 NUMERO FROM FACTURAS order by NUMERO DESC");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    string Numero = accesoDatos.Lector.GetString(0);
                    int nueva = (Convert.ToInt32(Numero.Substring(5))) + 1;
                    Numero = "0001-" + nueva.ToString("00000000");
                    return Numero;
                }
                return "0001-00000001";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
