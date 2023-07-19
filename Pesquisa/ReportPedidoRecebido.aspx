<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportPedidoRecebido.aspx.cs" Inherits="Pesquisa_ReportPedidoRecebido"
    Title="ARQUIVO HSPM" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h1>
        Recebido</h1>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Pedido:
                    <asp:Label ID="lbCodPedido" runat="server" Text=""></asp:Label></h2>
                <div class="clearfix">
                </div>
            </div>
            <div>
                <asp:Panel ID="Panel1" runat="server">
                    <CR:CrystalReportViewer ID="crvPedido" runat="server" EnableDatabaseLogonPrompt="False"
                        EnableParameterPrompt="False" HasCrystalLogo="False" ToolPanelView="None" AutoDataBind="True"
                        HasToggleParameterPanelButton="False" BestFitPage="False" Width="1000px" />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
