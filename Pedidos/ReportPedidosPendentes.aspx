<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportPedidosPendentes.aspx.cs" Inherits="Pedidos_ReportPedidosPendentes" Title="ARQUIVO HSPM" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
         <CR:CrystalReportViewer ID="crvPendentes" runat="server" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  
            HasCrystalLogo="False" ToolPanelView="None" AutoDataBind="True" 
             HasToggleParameterPanelButton="False" BestFitPage="False" Width="1300px"  />  
      
    
    </asp:Panel>
</div>

</asp:Content>