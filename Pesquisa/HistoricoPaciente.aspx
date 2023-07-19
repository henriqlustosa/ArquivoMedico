<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="HistoricoPaciente.aspx.cs" Inherits="Pesquisa_HistoricoPaciente" Title="ARQUIVO HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Histórico do Paciente</h2>
                <div class="clearfix">
                </div>
            </div>
            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                    <div class="col-auto form-group">
                        <label class="control-label" for="UsernameTextBox">
                            Informe o nome do paciente:
                        </label>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8">
                            <asp:TextBox ID="txbNome" class="form-control numeric" runat="server" AutoPostBack="true" />
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-8 ">
                            <asp:Button ID="SearchButton" runat="server" Text="Pesquisar" class="btn btn-primary"
                                OnClick="btnPesquisar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="x_panel">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-striped jambo_table"
                           DataKeyNames="id_ped_same"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdMain_RowCommand">
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
                                <asp:BoundField DataField="dataCadastro" HeaderText="Data do Pedido" SortExpression="dataCadastro"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="usuario_solicitante" HeaderText="Solicitante" SortExpression="usuario_solicitante"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="dataProntRecebido" HeaderText="Data Recebimento" SortExpression="dataProntRecebido"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="usuario_recebeu" HeaderText="Recebido Por" SortExpression="usuario_recebeu"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-CssClass="hidden-xs"
                                    HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="nota" HeaderText="Nota do Arquivo" SortExpression="nota"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">
                                    <ItemTemplate>
                                        <div class="form-inline">
                                            <asp:LinkButton ID="gvlnkPrint" CommandName="printPedido" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                                CssClass="btn btn-info" runat="server">
                                    <i class="fa fa-print" title="Ligar"></i> 
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
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <!-- Bootstrap -->

    <script src='<%= ResolveUrl("~/vendors/bootstrap/dist/js/bootstrap431.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $.noConflict();
            $('#<%= GridView1.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
