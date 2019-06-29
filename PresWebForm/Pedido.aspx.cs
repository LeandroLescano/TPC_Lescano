using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace PresWebForm
{
    public partial class About : Page
    {
        public List<Combo> combos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteID"] != null)
            {
                if (Session["ClienteID"].ToString() != "")
                    ClienteID.Value = Session["ClienteID"].ToString();
            }
            ComboNegocio negocio = new ComboNegocio();
            List<Combo> combosActivos = negocio.listarCombos();
            combosActivos = combosActivos.FindAll(X => X.Estado == true);
            combos = combosActivos;
            for (int i = 1; i < combos.Count; i++)
            {
                Indicador.InnerHtml += "</li>\n\t<li data-target='#carousel' data-slide-to='" + i + "'>";
            }

            for (int i = 0; i < combos.Count; i++)
            {
                string Ruta = combos[i].RutaImagen;
                if (Ruta != null)
                    combos[i].RutaImagen = Ruta.Substring(Ruta.IndexOf("img"), Ruta.Length - Ruta.IndexOf("img")).Replace('\\', '/');
                else
                    combos[i].RutaImagen = "https://www.igaxes.org/wp-content/uploads/2018/04/img-default.jpg";
                string divClass;
                if (i == 0)
                {
                    divClass = "<div class='carousel-item active'>";
                }
                else
                {
                    divClass = "<div class='carousel-item'>";
                }
                ContenedorImg.InnerHtml += "\n" + divClass + "\n" +
                                 "<img id='img" + i + "' alt='Imagen' class='mx-auto d-block img-fluid'  style='max-height:300px;' src='" + combos[i].RutaImagen + "'/></img>\n" +
                                 "<div class='carousel-caption' style='filter: invert(100%)'>\n" +
                                "<h3>" + combos[i].Nombre + "</h3>\n</div>\n</div>\n\n";

            }
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            Pedido nuevo = new Pedido();
            nuevo.Cliente = new Cliente();
            nuevo.Combo = new Combo();
            nuevo.Cliente.ID = Convert.ToInt32(ClienteID.Value);
            nuevo.Combo = combos[Convert.ToInt32(ComboID.Value)];
            nuevo.Observacion = txtObservaciones.Text;
            nuevo.FechaEntrega = Convert.ToDateTime(dtpFechaEntrega.Text);
            nuevo.FechaSolicitud = System.DateTime.Now;
            nuevo.PrecioFinal = nuevo.Combo.Precio;
            nuevo.Estado = "A revisar";
            negocio.cargarPedido(nuevo);
        }

        [System.Web.Services.WebMethod]
        public static string verificarUsuario(string UDNI, string Pass)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            int IDCliente = negocio.verificarUsuario(UDNI, Pass);
            if (IDCliente != -1)
            {
                HttpContext.Current.Session.Add("ClienteID", IDCliente);
                cliente = negocio.listarCliente(IDCliente);
                return cliente.Nombre + "," + cliente.ID;
            }
            else
            {
                return "No existe";
            }
        }


        [System.Web.Services.WebMethod]
        public static void limpiarSession()
        {
            HttpContext.Current.Session.Remove("ClienteID");
        }
        [System.Web.Services.WebMethod]
        public static string usuarioDuplicado(string usuario)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            if (negocio.usuarioDuplicado(usuario))
            {
                return "Existe";
            }
            else
            {
                return "No existe";
            }
        }

        [System.Web.Services.WebMethod]
        public static string dniDuplicado(string DNI)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            if(negocio.dniCuitDuplicado(DNI, 'D'))
            {
                return "Existe";
            }
            else
            {
                return "No existe";
            }
        }

        [System.Web.Services.WebMethod]
        public static string nombreCliente(int ID)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente = negocio.listarCliente(ID);
            return cliente.Nombre;
        }

        [System.Web.Services.WebMethod]
        public static string registrarCliente(string Nom, string Ape, string DNI, string Usuario, string Pass, string Mail, string Tel, string fechaNac)
        {
            ClienteNegocio negocioC = new ClienteNegocio();
            MailNegocio negocioM = new MailNegocio();
            TelefonoNegocio negocioT = new TelefonoNegocio();
            UsuarioNegocio negocioU = new UsuarioNegocio();

            Cliente nuevo = new Cliente();
            nuevo.TipoPersona = new TipoPersona();
            nuevo.TipoPersona.Fisica = true;
            nuevo.Domicilio = new Domicilio();
            nuevo.Usuario = new Usuario();
            nuevo.Telefonos = new List<Telefono>();
            nuevo.Mails = new List<Mail>();

            nuevo.Nombre = Nom;
            nuevo.Apellido = Ape;
            nuevo.DNI = DNI;
            nuevo.FechaNacimiento = Convert.ToDateTime(fechaNac);
            nuevo.Usuario.Nombre = Usuario;
            nuevo.Usuario.Contraseña = Pass;

            Telefono telefono = new Telefono();
            telefono.Numero = Tel;
            nuevo.Telefonos.Add(telefono);

            Mail mail = new Mail();
            mail.Descripcion = Nom + ", " + Ape;
            mail.Direccion = Mail;
            nuevo.Mails.Add(mail);

            nuevo.Usuario.ID = negocioU.agregarUsuario(nuevo.Usuario);

            negocioC.agregarCliente(nuevo);

            int idMail = negocioM.agregarMail(nuevo.Mails[0]);
            negocioC.agregarMailXCliente(nuevo, idMail);

            int idTel = negocioT.agregarTelefono(nuevo.Telefonos[0]);
            negocioC.agregarTelefonoXCliente(nuevo, idTel);

            HttpContext.Current.Session.Add("ClienteID", nuevo.ID);
            return nuevo.Nombre;
        }
    }
}