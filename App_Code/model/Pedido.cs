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

/// <summary>
/// Summary description for Pedido
/// </summary>
public class Pedido
{
    public int id { get; set; }
    public int local { get; set; }
    public Clinica clinica { get; set; }
    public DateTime dataCadastro { get; set; }
    public DateTime dataConsulta { get; set; }
    public int prontuario { get; set; }
    public string nm_paciente { get; set; }
    public string observacao { get; set; }
    public string usuario_solicitante { get; set; }
    public string status { get; set; }
    public string textRecebido { get; set; }
    public DateTime dataProntRecebido { get; set; }
    public string usuario_recebeu { get; set; }
    public string nota { get; set; }
}
