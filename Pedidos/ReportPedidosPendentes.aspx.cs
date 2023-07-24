using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class Pedidos_ReportPedidosPendentes : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ReportsPos"] = null;
            ConfigureCrystalReports();
        }

        if (!(Session["ReportsPos"] == null))
        {
            crvPendentes.ReportSource = (ReportDocument)Session["ReportsPos"];
        }
    }

    protected void ConfigureCrystalReports()
    {
        rprt.Load(Server.MapPath("~/Pedidos/ReportPedidosPendentes.rpt"));


        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=hspmArquivo;Integrated Security= True");

        SqlConnection con = new SqlConnection(@"Data Source=10.48.16.28;database=hspmArquivo; Persist Security Info=True;user id=hspmApp;password=SoundG@rden=1");

        string sqlString = "SELECT * " +
                      " FROM [hspmArquivo].[dbo].[pedido_same]" +
                      " WHERE status = 'PENDENTE'";

        SqlCommand cmd = new SqlCommand(sqlString, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);



        DataTable dt = new DataTable();
        //DataSet ds = new DataSet();
        //sda.Fill(ds, "vw_baixa_por_profissional_mes");
        sda.Fill(dt);

        rprt.SetDataSource(dt);

        crvPendentes.ReportSource = rprt;
        Session["ReportsPos"] = rprt;
    }
}
