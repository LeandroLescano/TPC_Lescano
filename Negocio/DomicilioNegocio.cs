using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class DomicilioNegocio
    {
        public void agregarDomicilio(Domicilio nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            try
            {
                int IDLocalidad = negocioLoc.idLocalidad(nuevo.Localidad.Nombre, nuevo.Localidad.Partido);
                if (nuevo.Edificio == null)
                {
                    if (IDLocalidad == -1)
                        accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2) VALUES(" + nuevo.Altura + ", '" + nuevo.Calle + "', '" + nuevo.EntreCalle1 + "', '" + nuevo.EntreCalle2 + "')");
                    else
                        accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2, IDLOCALIDAD) VALUES(" + nuevo.Altura + ", '" + nuevo.Calle + "', '" + nuevo.EntreCalle1 + "', '" + nuevo.EntreCalle2 + "', " + IDLocalidad + ")");
                }
                else
                {
                    if (IDLocalidad == -1)
                        accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2, PISO, DEPARTAMENTO) VALUES(" + nuevo.Altura + ", '" + nuevo.Calle + "', '" + nuevo.EntreCalle1 + "', '" + nuevo.EntreCalle2 + "', " + nuevo.Edificio.Piso + ", '" + nuevo.Edificio.Departamento + "')");
                    else
                        accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2, PISO, DEPARTAMENTO, IDLOCALIDAD) VALUES(" + nuevo.Altura + ", '" + nuevo.Calle + "', '" + nuevo.EntreCalle1 + "', '" + nuevo.EntreCalle2 + "', "+ nuevo.Edificio.Piso +", '"+ nuevo.Edificio.Departamento +"', "+ IDLocalidad +")");
                }
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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

        public void modificarDomicilio(Domicilio modif)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            DomicilioNegocio negocioDom = new DomicilioNegocio();
            try
            {
                int IDLocalidad = negocioLoc.idLocalidad(modif.Localidad.Nombre, modif.Localidad.Partido);
                //string Consulta = "UPDATE DOMICILIOS SET CALLE = @Calle, ALTURA = @Altura, ENTRECALLE1 = @EntreCalle1, ENTRECALLE2 = @Entrecalle2";
                //if (modif.Edificio != null)
                //{
                //    Consulta += ", PISO=@Piso, DEPARTAMENTO=@Depto";
                //}
                //if(IDLocalidad != -1)
                //{
                //    Consulta += ", IDLOCALIDAD=@Localidad";
                //}
                //accesoDatos.setearConsulta(Consulta +  " WHERE ID=" + negocioDom.idDomicilio(modif));
                //accesoDatos.Comando.Parameters.Clear();
                //accesoDatos.Comando.Parameters.AddWithValue("@Calle", modif.Calle);
                //accesoDatos.Comando.Parameters.AddWithValue("@Altura", modif.Altura);
                //accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle1", modif.EntreCalle1);
                //accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle2", modif.EntreCalle2);
                //if(modif.Edificio != null)
                //{
                //    accesoDatos.Comando.Parameters.AddWithValue("@Piso", modif.Edificio.Piso);
                //    accesoDatos.Comando.Parameters.AddWithValue("@Depto", modif.Edificio.Departamento);
                //}
                //accesoDatos.Comando.Parameters.AddWithValue("@Localidad", IDLocalidad);
                accesoDatos.setearConsulta("UPDATE DOMICILIOS SET CALLE = @Calle, ALTURA = @Altura, ENTRECALLE1 = @EntreCalle1, ENTRECALLE2 = @Entrecalle2, PISO=@Piso, DEPARTAMENTO=@Depto, IDLOCALIDAD=@Localidad WHERE ID=" + negocioDom.idDomicilio(modif));
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Calle", modif.Calle);
                accesoDatos.Comando.Parameters.AddWithValue("@Altura", modif.Altura);
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle1", modif.EntreCalle1);
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle2", modif.EntreCalle2);
                if (modif.Edificio != null)
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Piso", modif.Edificio.Piso);
                    accesoDatos.Comando.Parameters.AddWithValue("@Depto", modif.Edificio.Departamento);
                }
                else
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Piso", DBNull.Value);
                    accesoDatos.Comando.Parameters.AddWithValue("@Depto", DBNull.Value);
                }
                if(IDLocalidad != -1)
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Localidad", IDLocalidad);
                }
                else
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Localidad", DBNull.Value);
                }

                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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

        public int idDomicilio (Domicilio dom)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idDom = -1;
                accesoDatos.setearConsulta("Select ID FROM DOMICILIOS where CALLE LIKE '%" + dom.Calle + "%' AND ALTURA LIKE " + dom.Altura);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    idDom = accesoDatos.Lector.GetInt32(0);
                }

                return idDom;
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
