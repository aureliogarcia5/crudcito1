using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.Page;
using System.Web.UI.WebControls;
using System.Data; //se agrega para las clases con datos
using System.Reflection.Emit;

namespace crudcito.pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }
        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            gvusuarios.DataSource=dt;
            gvusuarios.DataBind();
            con.Close();

        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/crud.aspx?op=C");
        }
        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/crud.aspx?id="+id+"&op=R");//aqui pasamos dos variables

        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/crud.aspx?id=" + id + "&op=U");//aqui pasamos dos variables
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/crud.aspx?id=" + id + "&op=D");//aqui pasamos dos variables

        }
    }
}