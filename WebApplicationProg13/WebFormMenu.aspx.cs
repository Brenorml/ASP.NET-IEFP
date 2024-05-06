using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProg13
{
    public partial class WebFormMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRectangulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebRectangulo.aspx");
        }

        protected void btnQuadrado_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebQuadrado.aspx");
        }

        protected void btnTriangulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebTriangulo.aspx");
        }

        protected void btnCirculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebCirculo.aspx");
        }
    }
}