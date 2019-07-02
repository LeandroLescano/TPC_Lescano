using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using negocioCom;


namespace PresWebForm
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteID"] != null)
            {
                if (Session["ClienteID"].ToString() != "")
                    ClienteID.Value = Session["ClienteID"].ToString();
            }
        }
    }
}