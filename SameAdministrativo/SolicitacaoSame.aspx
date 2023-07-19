﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SolicitacaoSame.aspx.cs" Inherits="Administrativo_SolicitacaoSame"
    Title="ARQUIVO HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function() {
            $("input").attr("autocomplete", "off");

            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green',
                increaseArea: '20%' // optional
            });

            $('.numeric').keyup(function() {
                $(this).val(this.value.replace(/\D/g, ''));
            });
        });

    </script>

    <style type="text/css">
        fieldset.scheduler-border
        {
            border: 1px groove #ddd !important;
            padding: 0 1.4em 1.4em 1.4em !important;
            margin: 0 0 1.5em 0 !important;
            -webkit-box-shadow: 0px 0px 0px 0px #000;
        }
        legend.scheduler-border
        {
            font-size: 1.2em !important;
            font-weight: bold !important;
            text-align: center !important;
        }
        .icheckbox_flat-green
        {
            margin: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    SAME</h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        RH/PRONTUÁRIO</label>
                    <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric" AutoPostBack="true"
                        OnTextChanged="txbProntuario_TextChanged" required ></asp:TextBox>
                </div>
                <div class="col-md-7 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">Satélites</legend>
                        <asp:CheckBoxList ID="cblSatelites" runat="server" DataSourceID="SqlDataSource1"
                            DataTextField="desc_satelite" DataValueField="cod_satelite">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:arquivoConnectionString %>"
                            SelectCommand="SELECT [cod_satelite], [desc_satelite] FROM [satelite]"></asp:SqlDataSource>
                    </fieldset>
                </div>
                <div class="col-4">
                    <div>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Ficha de Atendimento Ambulatorial</legend>
                            <div class="row">
                                <asp:CheckBox ID="cbFAA" runat="server" />
                                <asp:TextBox ID="txbFAAObs" runat="server" class="form-control col-10"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                    <div>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Outro</legend>
                            <div class="row">
                                <asp:CheckBox ID="cbOutros" runat="server" />
                                <asp:TextBox ID="txbOutrosObs" runat="server" class="form-control col-10"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                    <div>
                        <asp:Button ID="btnConfirma" runat="server" Text="Confirmar" class="btn btn-info"
                            OnClick="btnConfirma_Click" />
                    </div>
                </div>
                <div class="col-4">
                    <div>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Boletim de Emergência</legend>
                            <div class="row">
                                <asp:CheckBox ID="cbBE" runat="server" />
                                <asp:TextBox ID="txbBEObs" runat="server" class="form-control col-10"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                    <div>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Internação</legend>
                            <div class="row">
                                <asp:CheckBox ID="cbInternacao" runat="server" />
                                <asp:TextBox ID="txbInterObs" runat="server" class="form-control col-10"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Lista <small><i>- Solicitações/Pedidos</i></small></h2>
                <div class="clearfix">
                </div>
            </div>
             <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"
                class="table table-striped jambo_table" DataKeyNames="id_ped_same" CellPadding="4" ForeColor="#333333"
                GridLines="None" Width="100%"  OnRowCommand="grdMain_RowCommand" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                
                <Columns>
                    <asp:BoundField DataField="id_ped_same" HeaderText="id" SortExpression="id_ped_same" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs" />
                   
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
                  <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                  <asp:BoundField DataField="nota" HeaderText="Nota do Arquivo" SortExpression="nota"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                   
                    <asp:TemplateField HeaderText="Confirmar" HeaderStyle-CssClass="sorting_disabled">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkEdit" CommandName="editRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    runat="server">
                                    <%# (string)Eval("status") == "INATIVO" ? "" : "<i class='fa fa-check fa-2x' style='color: #1ABB9C;' ></i>"%>
                                </asp:LinkButton>
                                
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Excluir" HeaderStyle-CssClass="sorting_disabled">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkDelete" CommandName="deleteRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    runat="server">
                                <%# (string)Eval("status") != "PENDENTE" ? "" : "<i class='fa fa-trash fa-2x' style='color: red' ></i>"%>
                                <%--<i class="fa fa-trash fa-2x" style="color: red" ></i>--%>
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
    </div>
</asp:Content>