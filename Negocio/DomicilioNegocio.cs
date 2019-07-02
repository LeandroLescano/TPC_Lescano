using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace negocioCom
{
    public class DomicilioNegocio
    {
        public int agregarDomicilio(Domicilio nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2, PISO, DEPARTAMENTO, IDLOCALIDAD) VALUES(@Altura, @Calle, @EntreCalle1, @EntreCalle2, @Piso, @Depto, @Localidad ) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.AddWithValue("@Calle", esNulo(nuevo.Calle));
                accesoDatos.Comando.Parameters.AddWithValue("@Altura", esNulo(nuevo.Altura));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle1", esNulo(nuevo.EntreCalle1));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle2", esNulo(nuevo.EntreCalle2));
                accesoDatos.Comando.Parameters.AddWithValue("@Piso", esNulo(nuevo.Edificio.Piso));
                accesoDatos.Comando.Parameters.AddWithValue("@Depto", esNulo(nuevo.Edificio.Departamento));
                accesoDatos.Comando.Parameters.AddWithValue("@Localidad", esNulo(nuevo.Localidad.ID));
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

        public void modificarDomicilio(Domicilio modif)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE DOMICILIOS SET CALLE = @Calle, ALTURA = @Altura, ENTRECALLE1 = @EntreCalle1, ENTRECALLE2 = @Entrecalle2, PISO=@Piso, DEPARTAMENTO=@Depto, IDLOCALIDAD=@Localidad WHERE ID=" + modif.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Calle", esNulo(modif.Calle));
                accesoDatos.Comando.Parameters.AddWithValue("@Altura", esNulo(modif.Altura));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle1", esNulo(modif.EntreCalle1));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle2", esNulo(modif.EntreCalle2));
                accesoDatos.Comando.Parameters.AddWithValue("@Piso", esNulo(modif.Edificio.Piso));
                accesoDatos.Comando.Parameters.AddWithValue("@Depto", esNulo(modif.Edificio.Departamento));
                accesoDatos.Comando.Parameters.AddWithValue("@Localidad", esNulo(modif.Localidad.ID));
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

        internal Domicilio listarDomicilio(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Domicilio> listado = new List<Domicilio>();
            Domicilio dom = new Domicilio();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM DOMICILIOS AS D LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD WHERE D.ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                dom.Edificio = new Edificio();
                dom.Localidad = new Localidad();
                dom.Coordenadas = new Coordenada();
                while (accesoDatos.Lector.Read())
                {
                    if (!Convert.IsDBNull(accesoDatos.Lector["ID"]))
                       dom.ID = (int)accesoDatos.Lector["ID"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                       dom.Calle = (string)accesoDatos.Lector["CALLE"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                       dom.Altura = (int)accesoDatos.Lector["ALTURA"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE1"]))
                       dom.EntreCalle1 = (string)accesoDatos.Lector["ENTRECALLE1"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE2"]))
                       dom.EntreCalle2 = (string)accesoDatos.Lector["ENTRECALLE2"];

                    //Edificio
                    if (!Convert.IsDBNull(accesoDatos.Lector["PISO"]))
                       dom.Edificio.Piso = (int)accesoDatos.Lector["PISO"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["DEPARTAMENTO"]))
                       dom.Edificio.Departamento = (string)accesoDatos.Lector["DEPARTAMENTO"];

                    //Localidad
                    if (!Convert.IsDBNull(accesoDatos.Lector["NOMBRE"]))
                       dom.Localidad.Nombre = (string)accesoDatos.Lector["NOMBRE"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["CODPOSTAL"]))
                       dom.Localidad.CPostal = (string)accesoDatos.Lector["CODPOSTAL"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["PARTIDO"]))
                       dom.Localidad.Partido = (string)accesoDatos.Lector["PARTIDO"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDLOCALIDAD"]))
                       dom.Localidad.ID = (int)accesoDatos.Lector["IDLOCALIDAD"];
                }
                return dom;
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

        public void eliminarDomicilio(Domicilio dom)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM DOMICILIOS WHERE ID = " + dom.ID);
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

        private object esNulo(object campo)
        {
            double num;
            bool isNumber = Double.TryParse(Convert.ToString(campo), out num);
            if(isNumber)
            {
                if ((int)campo == 0 || (int)campo == -1)
                    return DBNull.Value;
                else
                    return campo;
            }
            else if (campo == null)
            {
                return DBNull.Value;
            }
            else
            {
                return campo;
            }
        }
    }
}
