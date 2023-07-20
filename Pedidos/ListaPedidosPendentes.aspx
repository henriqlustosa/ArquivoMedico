<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaPedidosPendentes.aspx.cs" Inherits="Pedidos_ListaPedidosPendentes"
    Title="ARQUIVO HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .radioboxlist radioboxlistStyle
        {
            font-size: x-large;
            padding-right: 20px;
        }
        .radioboxlist label
        {
            color: #3E3928;
            background-color: #E8E5D4;
            padding-left: 6px;
            padding-right: 16px;
            padding-top: 2px;
            padding-bottom: 2px;
            border: 1px solid #AAAAAA;
            white-space: nowrap;
            clear: left;
            margin-right: 10px;
            margin-left: 10px;
        }
        .radioboxlist label:hover
        {
            color: #CC3300;
            background: #D1CFC2;
        }
        input:checked + label
        {
            color: #CC3300;
            background: #D1CFC2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
      <Scripts>
       <asp:ScriptReference Path="../vendors/jquery/dist/jquery.js" />
        <asp:ScriptReference Path="../build/js/jquery.dataTables.js" /> 
      </Scripts>
     
  </asp:ScriptManagerProxy>
    <h1>
        Lista de pedidos de Prontuários/Documentos Pendentes</h1>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    SAME</h2>
                   
                <div class="clearfix">
                </div>
            </div>
            
             <div class="form-group row">
                                <div class="col-md-4 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="Button2" runat="server" Text="Visualizar Impressão" class="btn btn-warning"
                                      OnClick="btnVisImpressao_Click" />
                                </div>
                            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-striped jambo_table"
                        DataKeyNames="id_ped_same" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Width="100%" OnRowCommand="grdMain_RowCommand">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="id_ped_same" HeaderText="id" SortExpression="id_ped_same"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="nm_paciente" HeaderText="Paciente" SortExpression="nm_paciente"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="prontuario" HeaderText="Prontuário" SortExpression="prontuario"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="arquivo_satelie" HeaderText="Arquivo Satelite" SortExpression="arquivo_satelie"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="documento" HeaderText="Documento" SortExpression="documento"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="observacao" HeaderText="Observação" SortExpression="observacao"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                 <asp:BoundField DataField="nota_same" HeaderText="Nota SAME" SortExpression="nota_same"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="dataCadastro" HeaderText="Data do Pedido" SortExpression="dataCadastro"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="sorting_disabled">
                                <ItemTemplate>
                                    <div class="form-inline">
                                        <asp:LinkButton ID="gvlnkDelete" CommandName="editRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                            runat="server">
                                    <i class="fa fa-pencil-square-o fa-2x" style="color: red" ></i>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <!-- Large modal -->
                    <div class="modal fade bs-example-modal-lg" id="editModal" tabindex="-1" role="dialog"
                        aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLabel">
                                        Detalhes do Pedido</h4>
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container">
                                        <div class="modal-body">
                                            <div class="form-group row">
                                                <label for="txtID" class="col-sm-2 col-form-label">
                                                    ID:</label>
                                                <div class="col-sm-10">
                                                    <asp:Label ID="txbID" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="txbProntuario" class="col-sm-2 col-form-label">
                                                    Prontuário:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txbProntuario" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="txbNomePacienteModal" class="col-sm-2 col-form-label">
                                                    Nome Paciente:</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txbNomePacienteModal" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="txbSatelite" class="col-sm-2 col-form-label">
                                                    Arquivo Satélite:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txbSatelite" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                </div>
                                                <label for="txbDocumento" class="col-sm-2 col-form-label">
                                                    Documento:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txbDocumento" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="txbObs" class="col-sm-2 col-form-label">
                                                    Observação:</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txbObs" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <asp:RadioButtonList ID="rblStatus" CssClass="radioboxlist" runat="server">
                                                    <asp:ListItem  Selected>NÃO ENCONTRADO</asp:ListItem>
                                                    <asp:ListItem>INATIVO</asp:ListItem>
                                                    <asp:ListItem>ENCONTRADO</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="Label1" for="txbNota" runat="server" Text="Observação:"></asp:Label>
                                                <asp:TextBox ID="txbNota" runat="server" class="form-control" TextMode="MultiLine"
                                                    Rows="4"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button1" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnEditar_Click" />
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                                        Cancelar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- fim modal large -->
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    
     <script type="text/javascript">
         $(document).ready(function() {

             $('#<%= GridView1.ClientID %>').prepend($("<thead></thead>").append($('#<%= GridView1.ClientID %>').find("tbody tr:first"))).DataTable({
                 language: {
                     search: "<i class='fa fa-search' aria-hidden='true'></i>",
                     processing: "Processando...",
                     lengthMenu: "Mostrando _MENU_ registros por páginas",
                     info: "Mostrando página _PAGE_ de _PAGES_",
                     infoEmpty: "Nenhum registro encontrado",
                     infoFiltered: "(filtrado de _MAX_ registros no total)"
                 }
             });

         });
         </script>
</asp:Content>
