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
        public int agregarDomicilio(Domicilio nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            try
            {
                int idDomicilio = 0;
                accesoDatos.setearConsulta("INSERT INTO DOMICILIOS (ALTURA, CALLE, ENTRECALLE1, ENTRECALLE2, PISO, DEPARTAMENTO, IDLOCALIDAD) VALUES(@Altura, @Calle, @EntreCalle1, @EntreCalle2, @Piso, @Depto, @Localidad ) select TOP 1 ID from DOMICILIOS ORDER BY ID DESC ");
                accesoDatos.Comando.Parameters.AddWithValue("@Calle", esNulo(nuevo.Calle));
                accesoDatos.Comando.Parameters.AddWithValue("@Altura", esNulo(nuevo.Altura));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle1", esNulo(nuevo.EntreCalle1));
                accesoDatos.Comando.Parameters.AddWithValue("@EntreCalle2", esNulo(nuevo.EntreCalle2));
                accesoDatos.Comando.Parameters.AddWithValue("@Piso", esNulo(nuevo.Edificio.Piso));
                accesoDatos.Comando.Parameters.AddWithValue("@Depto", esNulo(nuevo.Edificio.Departamento));
                accesoDatos.Comando.Parameters.AddWithValue("@Localidad", esNulo(nuevo.Localidad.ID));
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    idDomicilio = accesoDatos.Lector.GetInt32(0);
                }

                return idDomicilio;
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
                if ((int)campo == 0)
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
