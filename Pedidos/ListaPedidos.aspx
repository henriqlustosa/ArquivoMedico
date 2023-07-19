<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaPedidos.aspx.cs" Inherits="Pedidos_ListaPedidos" Title="ARQUIVO HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<h1>Lista de pedidos de Prontuários/Documentos</h1>

<div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Geral</h2>
                <div class="clearfix">
                </div>
            </div>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" >
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="id_localLabel" runat="server" Text='<%# Eval("id_local") %>' />
                </td>
                <td>
                    <asp:Label ID="id_clinicaLabel" runat="server" 
                        Text='<%# Eval("id_clinica") %>' />
                </td>
                <td>
                    <asp:Label ID="dataCadastroLabel" runat="server" 
                        Text='<%# Eval("dataCadastro") %>' />
                </td>
                <td>
                    <asp:Label ID="dataConsultaLabel" runat="server" 
                        Text='<%# Eval("dataConsulta") %>' />
                </td>
                <td>
                    <asp:Label ID="prontuarioLabel" runat="server" 
                        Text='<%# Eval("prontuario") %>' />
                </td>
                <td>
                    <asp:Label ID="nm_pacienteLabel" runat="server" 
                        Text='<%# Eval("nm_paciente") %>' />
                </td>
                <td>
                    <asp:Label ID="observacaoLabel" runat="server" 
                        Text='<%# Eval("observacao") %>' />
                </td>
                <td>
                    <asp:Label ID="usuarioLabel" runat="server" Text='<%# Eval("usuario") %>' />
                </td>
                <td>
                    <%--<asp:CheckBox ID="recebidoCheckBox" runat="server" 
                        Checked='<%# Eval("recebido") %>' Enabled ="false"  />--%>
                         <asp:LinkButton ID="gvlnkEdit"
                                    runat="server">
                                    <%# (bool)Eval("recebido") == true ? "<i class='fa fa-toggle-on fa-2x' style='color: #1ABB9C;' ></i>" : "<i class='fa fa-toggle-off fa-2x' style='color: #BAB8B8;' ></i>"%>
                                </asp:LinkButton>
                      
                </td>
                
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;">
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="id_localLabel" runat="server" Text='<%# Eval("id_local") %>' />
                </td>
                <td>
                    <asp:Label ID="id_clinicaLabel" runat="server" 
                        Text='<%# Eval("id_clinica") %>' />
                </td>
                <td>
                    <asp:Label ID="dataCadastroLabel" runat="server" 
                        Text='<%# Eval("dataCadastro") %>' />
                </td>
                <td>
                    <asp:Label ID="dataConsultaLabel" runat="server" 
                        Text='<%# Eval("dataConsulta") %>' />
                </td>
                <td>
                    <asp:Label ID="prontuarioLabel" runat="server" 
                        Text='<%# Eval("prontuario") %>' />
                </td>
                <td>
                    <asp:Label ID="nm_pacienteLabel" runat="server" 
                        Text='<%# Eval("nm_paciente") %>' />
                </td>
                <td>
                    <asp:Label ID="observacaoLabel" runat="server" 
                        Text='<%# Eval("observacao") %>' />
                </td>
                <td>
                    <asp:Label ID="usuarioLabel" runat="server" Text='<%# Eval("usuario") %>' />
                </td>
                <td>
                    <%--<asp:CheckBox ID="recebidoCheckBox" runat="server" 
                        Checked='<%# Eval("recebido") %>' Enabled="false" />--%>
                        <asp:LinkButton ID="gvlnkEdit2"
                                    runat="server">
                                    <%# (bool)Eval("recebido") == true ? "<i class='fa fa-toggle-on fa-2x' style='color: #1ABB9C;' ></i>" : "<i class='fa fa-toggle-off fa-2x' style='color: #BAB8B8;' ></i>"%>
                                </asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" 
                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="id_localTextBox" runat="server" 
                        Text='<%# Bind("id_local") %>' />
                </td>
                <td>
                    <asp:TextBox ID="id_clinicaTextBox" runat="server" 
                        Text='<%# Bind("id_clinica") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataCadastroTextBox" runat="server" 
                        Text='<%# Bind("dataCadastro") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataConsultaTextBox" runat="server" 
                        Text='<%# Bind("dataConsulta") %>' />
                </td>
                <td>
                    <asp:TextBox ID="prontuarioTextBox" runat="server" 
                        Text='<%# Bind("prontuario") %>' />
                </td>
                <td>
                    <asp:TextBox ID="nm_pacienteTextBox" runat="server" 
                        Text='<%# Bind("nm_paciente") %>' />
                </td>
                <td>
                    <asp:TextBox ID="observacaoTextBox" runat="server" 
                        Text='<%# Bind("observacao") %>' />
                </td>
                <td>
                    <asp:TextBox ID="usuarioTextBox" runat="server" Text='<%# Bind("usuario") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                        Checked='<%# Bind("recebido") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="Tr2" runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th id="Th1" runat="server">
                                    id</th>
                                <th id="Th2" runat="server">
                                    id_local</th>
                                <th id="Th3" runat="server">
                                    Clínica</th>
                                <th id="Th4" runat="server">
                                    Data Cadastro</th>
                                <th id="Th5" runat="server">
                                    Data Consulta</th>
                                <th id="Th6" runat="server">
                                    Prontuário</th>
                                <th id="Th7" runat="server">
                                    Paciente</th>
                                <th id="Th8" runat="server">
                                    Observação</th>
                                <th id="Th9" runat="server">
                                    Solicitante</th>
                                <th id="Th10" runat="server">
                                    Recebido</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" 
                        style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="background-color: #999999;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="id_localTextBox" runat="server" 
                        Text='<%# Bind("id_local") %>' />
                </td>
                <td>
                    <asp:TextBox ID="id_clinicaTextBox" runat="server" 
                        Text='<%# Bind("id_clinica") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataCadastroTextBox" runat="server" 
                        Text='<%# Bind("dataCadastro") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataConsultaTextBox" runat="server" 
                        Text='<%# Bind("dataConsulta") %>' />
                </td>
                <td>
                    <asp:TextBox ID="prontuarioTextBox" runat="server" 
                        Text='<%# Bind("prontuario") %>' />
                </td>
                <td>
                    <asp:TextBox ID="nm_pacienteTextBox" runat="server" 
                        Text='<%# Bind("nm_paciente") %>' />
                </td>
                <td>
                    <asp:TextBox ID="observacaoTextBox" runat="server" 
                        Text='<%# Bind("observacao") %>' />
                </td>
                <td>
                    <asp:TextBox ID="usuarioTextBox" runat="server" Text='<%# Bind("usuario") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                        Checked='<%# Bind("recebido") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="id_localLabel" runat="server" Text='<%# Eval("id_local") %>' />
                </td>
                <td>
                    <asp:Label ID="id_clinicaLabel" runat="server" 
                        Text='<%# Eval("id_clinica") %>' />
                </td>
                <td>
                    <asp:Label ID="dataCadastroLabel" runat="server" 
                        Text='<%# Eval("dataCadastro") %>' />
                </td>
                <td>
                    <asp:Label ID="dataConsultaLabel" runat="server" 
                        Text='<%# Eval("dataConsulta") %>' />
                </td>
                <td>
                    <asp:Label ID="prontuarioLabel" runat="server" 
                        Text='<%# Eval("prontuario") %>' />
                </td>
                <td>
                    <asp:Label ID="nm_pacienteLabel" runat="server" 
                        Text='<%# Eval("nm_paciente") %>' />
                </td>
                <td>
                    <asp:Label ID="observacaoLabel" runat="server" 
                        Text='<%# Eval("observacao") %>' />
                </td>
                <td>
                    <asp:Label ID="usuarioLabel" runat="server" Text='<%# Eval("usuario") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                        Checked='<%# Eval("recebido") %>' Enabled="false" />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:arquivoConnectionString %>" 
        SelectCommand="SELECT * FROM [pedido] WHERE recebido = 0">
        
    </asp:SqlDataSource>
            </div>
            
            <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            SAME</h2>
                    <div class="clearfix">
                    </div>
                    
                    </div>
                    Colocar list do same
                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2" 
                        DataKeyNames="id_ped_same">
                    <ItemTemplate>
                        <tr style="background-color: #E0FFFF;color: #333333;">
                            <td>
                                <asp:Label ID="id_ped_sameLabel" runat="server" 
                                    Text='<%# Eval("id_ped_same") %>' />
                            </td>
                            <td>
                                <asp:Label ID="prontuarioLabel" runat="server" 
                                    Text='<%# Eval("prontuario") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nome_pacienteLabel" runat="server" 
                                    Text='<%# Eval("nome_paciente") %>' />
                            </td>
                            <td>
                                <asp:Label ID="arquivo_sateliteLabel" runat="server" 
                                    Text='<%# Eval("arquivo_satelite") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documentoLabel" runat="server" Text='<%# Eval("documento") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documento_obsLabel" runat="server" 
                                    Text='<%# Eval("documento_obs") %>' />
                            </td>
                            <td>
                                <asp:Label ID="data_pedidoLabel" runat="server" 
                                    Text='<%# Eval("data_pedido") %>' />
                            </td>
                            <td>
                                <asp:Label ID="usuario_solicitanteLabel" runat="server" 
                                    Text='<%# Eval("usuario_solicitante") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                                    Checked='<%# Eval("recebido") %>' Enabled="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFFFFF;color: #284775;">
                            <td>
                                <asp:Label ID="id_ped_sameLabel" runat="server" 
                                    Text='<%# Eval("id_ped_same") %>' />
                            </td>
                            <td>
                                <asp:Label ID="prontuarioLabel" runat="server" 
                                    Text='<%# Eval("prontuario") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nome_pacienteLabel" runat="server" 
                                    Text='<%# Eval("nome_paciente") %>' />
                            </td>
                            <td>
                                <asp:Label ID="arquivo_sateliteLabel" runat="server" 
                                    Text='<%# Eval("arquivo_satelite") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documentoLabel" runat="server" Text='<%# Eval("documento") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documento_obsLabel" runat="server" 
                                    Text='<%# Eval("documento_obs") %>' />
                            </td>
                            <td>
                                <asp:Label ID="data_pedidoLabel" runat="server" 
                                    Text='<%# Eval("data_pedido") %>' />
                            </td>
                            <td>
                                <asp:Label ID="usuario_solicitanteLabel" runat="server" 
                                    Text='<%# Eval("usuario_solicitante") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                                    Checked='<%# Eval("recebido") %>' Enabled="false" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>
                                    No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                    Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Clear" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="prontuarioTextBox" runat="server" 
                                    Text='<%# Bind("prontuario") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="nome_pacienteTextBox" runat="server" 
                                    Text='<%# Bind("nome_paciente") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="arquivo_sateliteTextBox" runat="server" 
                                    Text='<%# Bind("arquivo_satelite") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="documentoTextBox" runat="server" 
                                    Text='<%# Bind("documento") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="documento_obsTextBox" runat="server" 
                                    Text='<%# Bind("documento_obs") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="data_pedidoTextBox" runat="server" 
                                    Text='<%# Bind("data_pedido") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="usuario_solicitanteTextBox" runat="server" 
                                    Text='<%# Bind("usuario_solicitante") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                                    Checked='<%# Bind("recebido") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                            <th runat="server">
                                                id_ped_same</th>
                                            <th runat="server">
                                                Prontuário</th>
                                            <th runat="server">
                                                Paciente</th>
                                            <th runat="server">
                                                Arquivo Satélite</th>
                                            <th runat="server">
                                                Documento</th>
                                            <th runat="server">
                                                Observação</th>
                                            <th runat="server">
                                                Data Pedido</th>
                                            <th runat="server">
                                                Solicitante</th>
                                            <th runat="server">
                                                Recebido</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" 
                                    style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <tr style="background-color: #999999;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Cancel" />
                            </td>
                            <td>
                                <asp:Label ID="id_ped_sameLabel1" runat="server" 
                                    Text='<%# Eval("id_ped_same") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="prontuarioTextBox" runat="server" 
                                    Text='<%# Bind("prontuario") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="nome_pacienteTextBox" runat="server" 
                                    Text='<%# Bind("nome_paciente") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="arquivo_sateliteTextBox" runat="server" 
                                    Text='<%# Bind("arquivo_satelite") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="documentoTextBox" runat="server" 
                                    Text='<%# Bind("documento") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="documento_obsTextBox" runat="server" 
                                    Text='<%# Bind("documento_obs") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="data_pedidoTextBox" runat="server" 
                                    Text='<%# Bind("data_pedido") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="usuario_solicitanteTextBox" runat="server" 
                                    Text='<%# Bind("usuario_solicitante") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                                    Checked='<%# Bind("recebido") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                            <td>
                                <asp:Label ID="id_ped_sameLabel" runat="server" 
                                    Text='<%# Eval("id_ped_same") %>' />
                            </td>
                            <td>
                                <asp:Label ID="prontuarioLabel" runat="server" 
                                    Text='<%# Eval("prontuario") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nome_pacienteLabel" runat="server" 
                                    Text='<%# Eval("nome_paciente") %>' />
                            </td>
                            <td>
                                <asp:Label ID="arquivo_sateliteLabel" runat="server" 
                                    Text='<%# Eval("arquivo_satelite") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documentoLabel" runat="server" Text='<%# Eval("documento") %>' />
                            </td>
                            <td>
                                <asp:Label ID="documento_obsLabel" runat="server" 
                                    Text='<%# Eval("documento_obs") %>' />
                            </td>
                            <td>
                                <asp:Label ID="data_pedidoLabel" runat="server" 
                                    Text='<%# Eval("data_pedido") %>' />
                            </td>
                            <td>
                                <asp:Label ID="usuario_solicitanteLabel" runat="server" 
                                    Text='<%# Eval("usuario_solicitante") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="recebidoCheckBox" runat="server" 
                                    Checked='<%# Eval("recebido") %>' Enabled="false" />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:arquivoConnectionString %>" 
                        SelectCommand="SELECT * FROM [pedido_same] WHERE [recebido] = 0">
                       
                    </asp:SqlDataSource>
                    
                    
            </div>
            
</div>







</asp:Content>

