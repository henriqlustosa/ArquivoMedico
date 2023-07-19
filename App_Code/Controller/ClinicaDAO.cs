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
/// Summary description for ClinicaDAO
/// </summary>
public class ClinicaDAO
{
    public static Clinica clinica(int codigo) {

        Clinica clinica = new Clinica();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT cod, clinica, ativo " +
                             " FROM [clinica] " +
                             " WHERE cod = " + codigo;

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {
                    clinica.cod = dr1.GetInt32(0);
                    clinica.descricao = dr1.GetString(1);
                    clinica.ativo = dr1.GetBoolean(2);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return clinica;
    }


    public static List<Clinica> listaClinicas()
    {
        var lista = new List<Clinica>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["arquivoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT cod, clinica, ativo " +
                             " FROM [clinica] " +
                             " ORDER BY clinica";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Clinica c = new Clinica();
                    c.cod = dr1.GetInt32(0);
                    c.descricao = dr1.GetString(1);
                    c.ativo = dr1.GetBoolean(2);
                    lista.Add(c);
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
