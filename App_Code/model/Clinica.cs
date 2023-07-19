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
/// Summary description for Clinica
/// </summary>
public class Clinica
{
    public int cod { get; set; }
    public string descricao { get; set; }
    public bool ativo { get; set; }
}
