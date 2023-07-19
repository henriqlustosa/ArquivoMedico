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
using System.Data.SqlClient;

public partial class Pedidos_ListaPedidosPendentes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carregaPedidosSame();
        }
    }

    protected void carregaPedidosSame()
    {
        try
        {
            GridView1.DataSource = PedidoDAO.CarregaListaPedidosSame();
            GridView1.DataBind();
        }
        catch (WebException ex)
        {
            string err = ex.Message;
        }
        catch (Exception ex1)
        {
            string err1 = ex1.Message;
        }
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        string usuario = System.Web.HttpContext.Current.User.Identity.Name;

        if (e.CommandName.Equals("editRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            int _id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

            var p = PedidoDAO.getPedidoSame(_id);

            txbID.Text = p.id_ped_same.ToString();
            txbProntuario.Text = p.prontuario.ToString();
            txbNomePacienteModal.Text = p.nm_paciente;
            txbSatelite.Text = p.arquivo_satelie;
            txbDocumento.Text = p.documento;
            txbObs.Text = p.observacao;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
                    "<script>$('#editModal').modal('show');</script>", false);
        }
    }

    protected void btnVisImpressao_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pedidos/ReportPedidosPendentes.aspx");
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        string _id = txbID.Text;
        string _status = rblStatus.SelectedItem.Value;
        string _nota = txbNota.Text + " Registro em " + DateTime.Now + " por " + System.Web.HttpContext.Current.User.Identity.Name;

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();

            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {
                cmm.CommandText = "UPDATE [pedido_same]" +
                                           "SET " +
                                              "status = @status, " +
                                              "nota = @nota " +
                                               " WHERE  id_ped_same = @id";
                cmm.Parameters.Add(new SqlParameter("@id", _id));
                cmm.Parameters.Add(new SqlParameter("@status", _status));
                cmm.Parameters.Add(new SqlParameter("@nota", _nota));
                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();

                cnn.Close();
            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("$('.modal-backdrop').remove();");
        sb.Append("$(document.body).removeClass('modal-open');");

        ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "clientscript", sb.ToString(), true);

        ClearInputs(Page.Controls);// limpa os textbox
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            ClearInputs(ctrl.Controls);
        }
    }
}