<%@ Page Title="" Language="C#" MasterPageFile="~/gridmaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="autocar.aspx.cs" Inherits="Lab5_6_SDH.autocar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoHTML" runat="server">

    
    <div>
        <asp:GridView ID="GridAutocar" 
            runat="server" 
            BackColor="White" 
            BorderColor="#336666" 
            BorderStyle="Double" 
            BorderWidth="3px" 
            CellPadding="4" 
            GridLines="Horizontal" 
            AutoGenerateColumns="false" 
            DataKeyNames="Id_Carro" 
            OnRowCommand="GridAutocar_RowCommand" 
            OnRowEditing="GridAutocar_RowEditing" 
            OnRowCancelingEdit="GridAutocar_RowCancelingEdit" 
            OnRowUpdating="GridAutocar_RowUpdating" 
            OnRowDeleting="GridAutocar_RowDeleting" 
            ShowHeaderWhenEmpty="false" 
            ShowFooter="true"
            >

            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />

            <Columns>
                <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Marca") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMarca" Text='<%# Eval("Marca") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("Marca") %>' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modelo">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Modelo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtModelo" Text='<%# Eval("Modelo") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtModeloPie" Text='<%# Eval("Modelo") %>' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pais">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Pais") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPais" Text='<%# Eval("Pais") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPaisPie" Text='<%# Eval("Pais") %>' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Costo">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Costo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCosto" Text='<%# Eval("Costo") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCostoPie" Text='<%# Eval("Costo") %>' runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Iconos/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Iconos/delete2.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Iconos/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Iconos/cancel2.png" runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Iconos/nuevo.png" runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <br />
        <br />

        <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
        <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>

    </div>
    
   

</asp:Content>
