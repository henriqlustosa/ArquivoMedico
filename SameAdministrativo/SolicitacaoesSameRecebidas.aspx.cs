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
using System.Net;

public partial class SameAdministrativo_SolicitacaoesSameRecebidas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //carregaPedidosSame();
    }


    //protected void carregaPedidosSame()
    //{
    //    try
    //    {
    //        GridView1.DataSource = PedidoDAO.CarregaPedidosSameRecebidas();
    //        GridView1.DataBind();
    //    }
    //    catch (WebException ex)
    //    {
    //        string err = ex.Message;
    //    }
    //    catch (Exception ex1)
    //    {
    //        string err1 = ex1.Message;
    //    }
    //}

    protected void GridView1_PreRender(object sender, EventArgs e)
    {

        // colocar no grid OnPreRender="GridView1_PreRender"

        int _dias = Convert.ToInt32(ddlPeriodo.SelectedValue.ToString());
        // You only need the following 2 lines of code if you are not 
        // using an ObjectDataSource of SqlDataSource
        
        GridView1.DataSource = PedidoDAO.CarregaPedidosSameRecebidas(_dias);
        
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            GridView1.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;

        }
    }



}
