using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for PedidoDAO
/// </summary>
public class PedidoDAO
{
    public static void GravaPedidoProntuario(int _local, int _clinica, DateTime _dtCadastro, DateTime _dtConsulta, int _pronuario, string _nm_paciente, string _obs, string _usuario)
    {
        string mensagem = "";


        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;

            try
            {
                cmm.CommandText = "Insert into pedido (local, clinica, dataCadastro, dataConsulta, prontuario, nm_paciente, observacao, usuario)" +
                       "values (@local, @clinica, @dataCadastro, @dataConsulta, @prontuario, @nm_paciente, @observacao, @usuario)";

                cmm.Parameters.Add("@local", SqlDbType.Int).Value = _local;
                cmm.Parameters.Add("@clinica", SqlDbType.Int).Value = _clinica;
                cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = _dtCadastro;
                cmm.Parameters.Add("@dataConsulta", SqlDbType.DateTime).Value = _dtConsulta;
                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = _pronuario;
                cmm.Parameters.Add("@nm_paciente", SqlDbType.VarChar).Value = _nm_paciente;
                cmm.Parameters.Add("@observacao", SqlDbType.VarChar).Value = _obs;
                cmm.Parameters.Add("@usuario", SqlDbType.VarChar).Value = _usuario;

                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Cadastro realizado com sucesso!";

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        //return mensagem;
    }

    public static List<Pedido> CarregaPedidosGeralPendentes()
    {
        var lista = new List<Pedido>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();


            string sqlConsulta = "SELECT [id]" +
                              ",[id_local]" +
                              ",[id_clinica]" +
                              ",[dataCadastro]" +
                              ",[dataConsulta]" +
                              ",[prontuario]" +
                              ",[nm_paciente]" +
                              ",[observacao]" +
                              ",[usuario]" +
                              ",[status]" +
                              " FROM [pedido] " +
                              " WHERE [recebido] = 0 " +
                              " ORDER BY dataCadastro DESC";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    Pedido p = new Pedido();
                    p.id = dr1.GetInt32(0);
                    p.local = dr1.GetInt32(1);
                    p.clinica = ClinicaDAO.clinica(dr1.GetInt32(2));
                    p.dataCadastro = dr1.GetDateTime(3);
                    p.dataConsulta = dr1.GetDateTime(4);
                    p.prontuario = dr1.GetInt32(5);
                    p.nm_paciente = dr1.GetString(6);
                    p.observacao = dr1.GetString(7);
                    p.usuario_solicitante = dr1.GetString(8);
                    p.status = dr1.GetString(9);
                    if (p.status.Equals("PENDENTE"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-off' title='Solicitado'></i>";
                    }
                    else if (p.status.Equals(true))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-on' title='Solicitado'></i>";
                    }

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static List<Pedido> CarregaPedidosGeral(int local)
    {
        var lista = new List<Pedido>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();


            string sqlConsulta = "SELECT [id]" +
                              ",[id_local]" +
                              ",[id_clinica]" +
                              ",[dataCadastro]" +
                              ",[dataConsulta]" +
                              ",[prontuario]" +
                              ",[nm_paciente]" +
                              ",[observacao]" +
                              ",[usuario]" +
                              ",[status]" +
                              " FROM [pedido] " +
                              " WHERE [id_local] = " + local +
                              " ORDER BY dataCadastro DESC";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    Pedido p = new Pedido();
                    p.id = dr1.GetInt32(0);
                    p.local = dr1.GetInt32(1);
                    p.clinica = ClinicaDAO.clinica(dr1.GetInt32(2));
                    p.dataCadastro = dr1.GetDateTime(3);
                    p.dataConsulta = dr1.GetDateTime(4);
                    p.prontuario = dr1.GetInt32(5);
                    p.nm_paciente = dr1.GetString(6);
                    p.observacao = dr1.GetString(7);
                    p.usuario_solicitante = dr1.GetString(8);
                    p.status = dr1.GetString(9);
                    if (p.status.Equals(false))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-off' title='Solicitado'></i>";
                    }
                    else if (p.status.Equals(true))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-on' title='Solicitado'></i>";
                    }

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static void ProntuarioRecebido(int _id, string _usuario, string _recebido)
    {

        string mensagem = "";

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            SqlCommand cmm1 = new SqlCommand();

            cmm.Connection = cnn;
            cmm1.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            //SqlTransaction mt1 = cnn.BeginTransaction();

            cmm.Transaction = mt;
            cmm1.Transaction = mt;
            try
            {

                cmm1.CommandText = "INSERT INTO pront_recebido (id_pedido, dataRecebimento, usuario_recebeu) VALUES (@id_pedido, @dataRecebimento, @usuario_recebeu)";
                cmm1.Parameters.Add(new SqlParameter("@dataRecebimento", DateTime.Now));
                cmm1.Parameters.Add(new SqlParameter("@usuario_recebeu", _usuario.ToUpper()));
                cmm1.Parameters.Add(new SqlParameter("@id_pedido", _id));
                cmm1.ExecuteNonQuery();

                cmm.CommandText = "UPDATE [pedido]" +
                                           "SET " +
                                              "recebido = @recebido" +
                                               " WHERE  id = @id";
                cmm.Parameters.Add(new SqlParameter("@recebido", _recebido));
                cmm.Parameters.Add(new SqlParameter("@id", _id));
                cmm.ExecuteNonQuery();


                //mt1.Commit();
                //mt1.Dispose();

                mt.Commit();
                mt.Dispose();

                cnn.Close();
                mensagem = "Atualização de cadastro realizado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        //return mensagem;
    }

    public static PedidoSame getPedidoSame(int _id){
        PedidoSame p = new PedidoSame();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                 " ,[prontuario]" +
                                 " ,[nome_paciente]" +
                                 " ,[arquivo_satelite]" +
                                 " ,[documento]" +
                                 " ,[documento_obs]" +
                                 " ,[data_pedido]" +
                                 " ,[usuario_solicitante]" +
                                 " ,[status]" +
                                 " ,[nota]" +
                              "FROM [hspmArquivo].[dbo].[pedido_same]" +
                              " WHERE id_ped_same = " + _id;

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {

                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.GetString(7);
                    p.status = dr1.GetString(8);
                    p.nota = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return p;
    }

    public static Pedido getPedido(int _id)
    {
        Pedido p = new Pedido();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();


            string sqlConsulta = "SELECT [id]" +
                              ",[local]" +
                              ",[clinica]" +
                              ",[dataCadastro]" +
                              ",[dataConsulta]" +
                              ",[prontuario]" +
                              ",[nm_paciente]" +
                              ",[observacao]" +
                              ",[usuario]" +
                              ",[recebido]" +
                              " FROM [pedido] " +
                              " WHERE ID = " + _id;

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {

                    p.id = dr1.GetInt32(0);
                    p.local = dr1.GetInt32(1);
                    p.clinica = ClinicaDAO.clinica(dr1.GetInt32(2));
                    p.dataCadastro = dr1.GetDateTime(3);
                    p.dataConsulta = dr1.GetDateTime(4);
                    p.prontuario = dr1.GetInt32(5);
                    p.nm_paciente = dr1.GetString(6);
                    p.observacao = dr1.GetString(7);
                    p.usuario_solicitante = dr1.GetString(8);
                    p.status = dr1.GetString(9);

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return p;
    }

    public static void GravaPedidoSameSatelites(int prontuario, string nm_nome_paciente, string arquivo_satelie, DateTime dataCadastro, string usuario_solicitante)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;

            try
            {
                cmm.CommandText = "Insert into pedido_same (prontuario, nome_paciente, arquivo_satelite, data_pedido, usuario_solicitante)" +
                       "values (@prontuario, @nome_paciente, @arquivo_satelite, @data_pedido, @usuario_solicitante)";
                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = nm_nome_paciente;
                cmm.Parameters.Add("@arquivo_satelite", SqlDbType.VarChar).Value = arquivo_satelie;
                cmm.Parameters.Add("@data_pedido", SqlDbType.DateTime).Value = dataCadastro;
                cmm.Parameters.Add("@usuario_solicitante", SqlDbType.VarChar).Value = usuario_solicitante;

                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();
                //mensagem = "Cadastro realizado com sucesso!";

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //mensagem = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
    }

    public static void GravaPedidoSameDocumentos(int prontuario, string nm_paciente, string documento, string observacao, DateTime dataCadastro, string usuario_solicitante)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;

            try
            {
                cmm.CommandText = "Insert into pedido_same (prontuario, nome_paciente, documento, documento_obs, data_pedido, usuario_solicitante)" +
                       "values (@prontuario, @nome_paciente, @documento, @documento_obs, @data_pedido, @usuario_solicitante)";
                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = nm_paciente;
                cmm.Parameters.Add("@documento", SqlDbType.VarChar).Value = documento;
                cmm.Parameters.Add("@documento_obs", SqlDbType.VarChar).Value = observacao;
                cmm.Parameters.Add("@data_pedido", SqlDbType.DateTime).Value = dataCadastro;
                cmm.Parameters.Add("@usuario_solicitante", SqlDbType.VarChar).Value = usuario_solicitante;

                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();
                //mensagem = "Cadastro realizado com sucesso!";

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //mensagem = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
    }

    public static List<PedidoSame> CarregaPedidosSame()
    {
        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                ",[prontuario]" +
                                ",[nome_paciente]" +
                                ",[arquivo_satelite]" +
                                ",[documento]" +
                                ",[documento_obs]" +
                                ",[data_pedido]" +
                              ",[usuario_solicitante]" +
                              ",[status]" +
                              ",[nota]" +
                              " FROM [pedido_same] " +
                              " WHERE status NOT IN ('RECEBIDO')" +
                              " ORDER BY data_pedido ASC";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.GetString(7);
                    p.status = dr1.GetString(8);
                    if (p.status.Equals("PENDENTE"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-off' title='Solicitado'></i>";
                    }
                    else if (p.status.Equals("RECEBIDO"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-on' title='Solicitado'></i>";
                    }
                    p.nota = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }


    public static List<PedidoSame> CarregaListaPedidosSame()
    {
        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                ",[prontuario]" +
                                ",[nome_paciente]" +
                                ",[arquivo_satelite]" +
                                ",[documento]" +
                                ",[documento_obs]" +
                                ",[data_pedido]" +
                              ",[usuario_solicitante]" +
                              ",[status]" +
                              ",[nota]" +
                              " FROM [pedido_same] " +
                              " WHERE status = 'PENDENTE'" +
                              " ORDER BY data_pedido ASC";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.GetString(7);
                    p.status = dr1.GetString(8);
                    if (p.status.Equals("PENDENTE"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-off' title='Solicitado'></i>";
                    }
                    else if (p.status.Equals("RECEBIDO"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-on' title='Solicitado'></i>";
                    }

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }


    public static List<PedidoSame> CarregaListaPedidosSameInativos()
    {
        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                ",[prontuario]" +
                                ",[nome_paciente]" +
                                ",[arquivo_satelite]" +
                                ",[documento]" +
                                ",[documento_obs]" +
                                ",[data_pedido]" +
                              ",[usuario_solicitante]" +
                              ",[status]" +
                              ",[nota]" +
                              " FROM [pedido_same] " +
                              " WHERE status = 'INATIVO'" +
                              " ORDER BY data_pedido ASC";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.GetString(7);
                    p.status = dr1.GetString(8);
                    if (p.status.Equals("PENDENTE"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-off' title='Solicitado'></i>";
                    }
                    else if (p.status.Equals("RECEBIDO"))
                    {
                        p.textRecebido = "<i class='fa fa-toggle-on' title='Solicitado'></i>";
                    }
                    p.nota = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static void SameRecebido(int _id, string _usuario, string _recebido)
    {
        string mensagem = "";

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            SqlCommand cmm1 = new SqlCommand();

            cmm.Connection = cnn;
            cmm1.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            //SqlTransaction mt1 = cnn.BeginTransaction();

            cmm.Transaction = mt;
            cmm1.Transaction = mt;
            try
            {

                cmm1.CommandText = "INSERT INTO same_recebido (id_ped_same, data_recebimento_same, usuario_recebeu) VALUES (@id_ped_same, @data_recebimento_same, @usuario_recebeu)";
                cmm1.Parameters.Add(new SqlParameter("@data_recebimento_same", DateTime.Now));
                cmm1.Parameters.Add(new SqlParameter("@usuario_recebeu", _usuario.ToUpper()));
                cmm1.Parameters.Add(new SqlParameter("@id_ped_same", _id));
                cmm1.ExecuteNonQuery();

                cmm.CommandText = "UPDATE [pedido_same]" +
                                           "SET " +
                                              "status = @status" +
                                               " WHERE  id_ped_same = @id";
                cmm.Parameters.Add(new SqlParameter("@status", _recebido));
                cmm.Parameters.Add(new SqlParameter("@id", _id));
                cmm.ExecuteNonQuery();


                //mt1.Commit();
                //mt1.Dispose();

                mt.Commit();
                mt.Dispose();

                cnn.Close();
                mensagem = "Atualização de cadastro realizado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        //return mensagem;
    }

    public static void SameExcluiPedido(int _id)
    {
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();

            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();

            cmm.Transaction = mt;
            try
            {
                cmm.CommandText = "DELETE FROM pedido_same WHERE id_ped_same = @id_ped_same";    
                cmm.Parameters.Add(new SqlParameter("@id_ped_same", _id));
                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();

                cnn.Close();
                mensagem = "Cadastro Excluído com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
    }

    public static object CarregaPedidosRecebidosPaciente(string _nome)
    {
        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                    " ,[prontuario]" +
                                    " ,[nome_paciente]" +
                                    " ,[arquivo_satelite]" +
                                    " ,[documento]" +
                                    " ,[documento_obs]" +
                                    " ,[data_pedido]" +
                                    " ,[usuario_solicitante]" +
                                    " ,[data_recebimento_same]" +
                                    " ,[usuario_recebeu]" +
                                    " ,[status]" +
                                    " ,[nota]" +
                                  " FROM [hspmArquivo].[dbo].[vw_same_arquivo_recebido] " +
                                  " WHERE [nome_paciente] LIKE '%" + _nome + "%'" +
                                  " ORDER BY [data_pedido] desc";
            // implementar listar apenas os ultimos 30 dias

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.GetString(7);
                    p.dataProntRecebido = dr1.GetDateTime(8);
                    p.usuario_recebeu = dr1.GetString(9);
                    p.status = dr1.GetString(10);
                    p.nota = dr1.GetString(11);

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }


    public static object CarregaPedidosSameRecebidas(int dias)
    {

        string sqlWherePeriodo = "";
        if (dias.Equals(7))
        {
            sqlWherePeriodo = "WHERE data_pedido between (CONVERT(datetime, GETDATE() - 6, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if(dias.Equals(15)){
            sqlWherePeriodo = "WHERE data_pedido between (CONVERT(datetime, GETDATE() - 14, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if(dias.Equals(30)){
            sqlWherePeriodo = "WHERE data_pedido between (CONVERT(datetime, GETDATE() - 29, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if(dias.Equals(0)){
            sqlWherePeriodo = " ";
        }

        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                    " ,[prontuario]" +
                                    " ,[nome_paciente]" +
                                    " ,[arquivo_satelite]" +
                                    " ,[documento]" +
                                    " ,[documento_obs]" +
                                    " ,[data_pedido]" +
                                    " ,[usuario_solicitante]" +
                                    " ,[data_recebimento_same]" +
                                    " ,[usuario_recebeu]" +
                                    " ,[status]" +
                                    " ,[nota]" +
                                  " FROM [hspmArquivo].[dbo].[vw_same_arquivo_recebido] " +
                                  sqlWherePeriodo +
                                  " ORDER BY [data_pedido] desc";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante =dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    p.dataProntRecebido =  dr1.GetDateTime(8);
                    p.usuario_recebeu = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    p.status = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    p.nota = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    
                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static object CarregaPedidosSameNaoEncontradas(int dias)
    {

        string sqlWherePeriodo = "";
        if (dias.Equals(7))
        {
            sqlWherePeriodo = "and data_pedido between (CONVERT(datetime, GETDATE() - 6, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if (dias.Equals(15))
        {
            sqlWherePeriodo = "and data_pedido between (CONVERT(datetime, GETDATE() - 14, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if (dias.Equals(30))
        {
            sqlWherePeriodo = "and data_pedido between (CONVERT(datetime, GETDATE() - 29, 103)) AND (CONVERT(datetime, GETDATE(), 103)) ";
        }
        else if (dias.Equals(0))
        {
            sqlWherePeriodo = " ";
        }

        var lista = new List<PedidoSame>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [id_ped_same]" +
                                    " ,[prontuario]" +
                                    " ,[nome_paciente]" +
                                    " ,[arquivo_satelite]" +
                                    " ,[documento]" +
                                    " ,[documento_obs]" +
                                    " ,[data_pedido]" +
                                    " ,[usuario_solicitante]" +
                                
                                    " ,[status]" +
                                    " ,[nota]" +
                                  " FROM [hspmArquivo].[dbo].[pedido_same] where status  IN ('NÃO ENCONTRADO')  " +
                                  sqlWherePeriodo +
                                  " ORDER BY [data_pedido] desc";

            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    PedidoSame p = new PedidoSame();
                    p.id_ped_same = dr1.GetInt32(0);
                    p.prontuario = dr1.GetInt32(1);
                    p.nm_paciente = dr1.GetString(2);
                    p.arquivo_satelie = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    p.documento = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    p.observacao = dr1.IsDBNull(5) ? "" : dr1.GetString(5);

                    p.dataCadastro = dr1.GetDateTime(6);
                    p.usuario_solicitante = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                 
                    p.status = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    p.nota = dr1.IsDBNull(9) ? "" : dr1.GetString(9);

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }
}