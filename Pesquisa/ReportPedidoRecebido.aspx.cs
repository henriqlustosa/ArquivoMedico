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

public partial class Pesquisa_ReportPedidoRecebido : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        string pedido = Request.QueryString["cod_pedido"];
        lbCodPedido.Text = pedido;

        if (!IsPostBack)
        {
            Session["ReportsPos"] = null;
            ConfigureCrystalReports(pedido);
        }

        if (!(Session["ReportsPos"] == null))
        {
            crvPedido.ReportSource = (ReportDocument)Session["ReportsPos"];
        }
    }

    protected void ConfigureCrystalReports(string pedido)
    {
        rprt.Load(Server.MapPath("~/Pesquisa/ReportPedidoRecebido.rpt"));


        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=hspmArquivo_Homologacao;Integrated Security= True");

        SqlConnection con = new SqlConnection(@"Data Source=10.48.16.28;database=hspmArquivo_Homologacao; Persist Security Info=True;user id=hspmApp;password=SoundG@rden=1");

        string sqlString = "SELECT * " +
                      " FROM [hspmArquivo_Homologacao].[dbo].[vw_same_arquivo_recebido] " +
                      " WHERE id_ped_same = " + pedido;

        SqlCommand cmd = new SqlCommand(sqlString, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);



        DataTable dt = new DataTable();
        sda.Fill(dt);

        rprt.SetDataSource(dt);

        crvPedido.ReportSource = rprt;
        Session["ReportsPos"] = rprt;
    }
}
