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
            ComboNegocio negocio = new ComboNegocio();
            List<Combo> combosActivos = negocio.listarCombosWeb();
            combosActivos = combosActivos.FindAll(X => X.Estado == true);
            combos = combosActivos;
            for (int i = 1; i < combos.Count; i++)
            {
                    Indicador.InnerHtml += "</li>\n\t<li data-target='#carousel' data-slide-to='"+i+"'>";
            }

                for (int i = 0; i < combos.Count; i++)
            {
                string Ruta = combos[i].RutaImagen;
                combos[i].RutaImagen = Ruta.Substring(Ruta.IndexOf("img"), Ruta.Length - Ruta.IndexOf("img")).Replace('\\', '/');
                string divClass;
                if (i == 0)
                {
                    divClass = "<div class='carousel-item active border'>";
                }
                else
                {
                    divClass = "<div class='carousel-item border'>";
                }
                ContenedorImg.InnerHtml += "\n" + divClass + "\n" +
                                 "<img id='img" + i + "' alt='Imagen' class='mx-auto d-block img-fluid' src='" + combos[i].RutaImagen + "'/></img>\n" +
                                 "<div class='carousel-caption' style='filter: invert(100%)'>\n" +
                                "<h3>" + combos[i].Nombre + "</h3>\n</div>\n</div>\n\n";

            }
        }
    }
}