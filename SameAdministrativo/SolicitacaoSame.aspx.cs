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
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;

public partial class Administrativo_SolicitacaoSame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carregaPedidosSame();
        }
    }

    protected void txbProntuario_TextChanged(object sender, System.EventArgs e)
    {
        // If the TextBox contains text, change its foreground and background colors.
        if (!string.IsNullOrEmpty(txbProntuario.Text))
        {
            int _pront = Convert.ToInt32(txbProntuario.Text);
            txbNomePaciente.Text = CarregaDadosPaciente(_pront).Nm_nome;
        }
    }

    public Paciente CarregaDadosPaciente(int prontuario)
    {
            Paciente details = new Paciente();

        try
        {
            string URI = "http://10.48.21.64:5000/hspmsgh-api/pacientes/paciente/" + prontuario;
            WebRequest request = WebRequest.Create(URI);

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URI);
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(httpResponse.GetResponseStream());

                JsonSerializer json = new JsonSerializer();

                var objText = reader.ReadToEnd();

                details = JsonConvert.DeserializeObject<Paciente>(objText);
            }
        }
        catch (WebException ex)
        {
            string err = ex.Message;
        }
        catch (Exception ex1)
        {
            string err1 = ex1.Message;
        }
        return details;
    }

    protected void btnConfirma_Click(object sender, EventArgs e)
    {
        PedidoSame p = new PedidoSame();
        p.prontuario = Convert.ToInt32(txbProntuario.Text);
        p.nm_paciente = txbNomePaciente.Text;
        if (!string.IsNullOrEmpty(p.nm_paciente) || p.nm_paciente == " ")
        {
            p.dataCadastro = DateTime.Now;
            p.usuario_solicitante = System.Web.HttpContext.Current.User.Identity.Name;

            for (int i = 0; i < cblSatelites.Items.Count; i++)
            {
                if (cblSatelites.Items[i].Selected == true)// getting selected value from CheckBox List  
                {
                    p.arquivo_satelie = cblSatelites.Items[i].Text; // add selected Item text to the String

                    try
                    {
                        PedidoDAO.GravaPedidoSameSatelites(p.prontuario, p.nm_paciente, p.arquivo_satelie, p.dataCadastro, p.usuario_solicitante);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
            }

            if (cbFAA.Checked)
            {
                p.documento = "FAA";
                p.observacao = txbFAAObs.Text;
                PedidoDAO.GravaPedidoSameDocumentos(p.prontuario, p.nm_paciente, p.documento, p.observacao, p.dataCadastro, p.usuario_solicitante);

            }
            if (cbBE.Checked)
            {
                p.documento = "BE";
                p.observacao = txbBEObs.Text;
                PedidoDAO.GravaPedidoSameDocumentos(p.prontuario, p.nm_paciente, p.documento, p.observacao, p.dataCadastro, p.usuario_solicitante);
            }
            if (cbInternacao.Checked)
            {
                p.documento = "INTERNAÇÃO";
                p.observacao = txbInterObs.Text;
                PedidoDAO.GravaPedidoSameDocumentos(p.prontuario, p.nm_paciente, p.documento, p.observacao, p.dataCadastro, p.usuario_solicitante);
            }
            if (cbOutros.Checked)
            {
                p.documento = "OUTROS";
                p.observacao = txbOutrosObs.Text;
                PedidoDAO.GravaPedidoSameDocumentos(p.prontuario, p.nm_paciente, p.documento, p.observacao, p.dataCadastro, p.usuario_solicitante);
            }

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Obrigatório o preenchimento do campo Nome');", true);
        }

    }

    protected void carregaPedidosSame()
    {
        try
        {
            GridView1.DataSource = PedidoDAO.CarregaPedidosSame();
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
                                              "nota_same = @nota " +
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
       

        ClearInputs(Page.Controls);// limpa os textbox
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {


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
    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        string usuario = System.Web.HttpContext.Current.User.Identity.Name;
        if (e.CommandName.Equals("editNotaRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            int _id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

            var p = PedidoDAO.getPedidoSame(_id);
            txbNota.Text = p.nota_same;
            txbID.Text = p.id_ped_same.ToString();
            txbProntuarioModal.Text = p.prontuario.ToString();
            txbNomePacienteModal.Text = p.nm_paciente;
         

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
                    "<script>$('#editModal').modal('show');</script>", false);
        
         
        }
        else
        {
            if (e.CommandName.Equals("editRecord"))
            {
                index = Convert.ToInt32(e.CommandArgument);

                int _id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

                string recebido = PedidoDAO.getPedidoSame(_id).status;
                if (recebido.Equals("RECEBIDO"))
                {
                    PedidoDAO.SameRecebido(_id, usuario, "PENDENTE");
                }
                else if (recebido.Equals("PENDENTE NÃO ENCONTRADO"))
                {
                    PedidoDAO.SameRecebido(_id, usuario, "NÃO ENCONTRADO");
                }
                else
                {
                    PedidoDAO.SameRecebido(_id, usuario, "RECEBIDO");
                }
            }

            if (e.CommandName.Equals("deleteRecord"))
            {
                index = Convert.ToInt32(e.CommandArgument);

                int _id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

                string recebido = PedidoDAO.getPedidoSame(_id).status;
                if (recebido.Equals("RECEBIDO"))
                {
                    //pedido já recebido, não é possivel excluir
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('pedido já recebido, não é possivel excluir');", true);
                }
                else
                {
                    PedidoDAO.SameExcluiPedido(_id);
                }
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}