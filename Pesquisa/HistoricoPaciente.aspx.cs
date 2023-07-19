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
using System.Drawing.Printing;

public partial class Pesquisa_HistoricoPaciente : System.Web.UI.Page
{
    public string _nome_impressora { get; set; }
    public int _pedido { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        string nome = txbNome.Text;
        GridView1.DataSource = PedidoDAO.CarregaPedidosRecebidosPaciente(nome);
        GridView1.DataBind();
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;

        if (e.CommandName.Equals("printPedido"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            _pedido = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());

            Response.Redirect("~/Pesquisa/ReportPedidoRecebido.aspx?cod_pedido=" + _pedido);
        }
    }
}