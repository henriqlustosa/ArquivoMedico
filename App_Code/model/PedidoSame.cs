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
/// Summary description for PedidoSame
/// </summary>
public class PedidoSame : Pedido
{
    public int id_ped_same { get; set; }
    public string arquivo_satelie { get; set; }
    public string documento { get; set; }
    public string nota_same { get; set; }
}
