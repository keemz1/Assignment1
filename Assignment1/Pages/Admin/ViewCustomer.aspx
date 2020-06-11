<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="Assignment1.Pages.Admin.Remove_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="align-items-center container-fluid" style="min-height: 100%">
        <div class="card text-white bg-dark mb-3 mt-3" style="margin-left: 15rem; margin-right: 15rem">
            <div class="card-header"><h1>Edit User</h1></div>
            <div class="card-body">
                <div class="card text-white bg-info mb-3" style="margin: auto">
                    <div class="card-header">Users</div>
                    <div class="card-body">
                        <div class="product-grid">
                            <asp:GridView ID="userGridView" ForeColor="Black" runat="server" Height="195px" Width="379px"
                                ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="QueueOrderNumber">
                                <Columns>
                                    <asp:BoundField DataField="QueueOrderNumber" HeaderText="QueueOrderNumber" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" SortExpression="QueueOrderNumber" ReadOnly="True" />
                                    <asp:BoundField DataField="ServiceQueueNumber" HeaderText="ServiceQueueNumber" SortExpression="ServiceQueueNumber" />
                                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" SortExpression="CustomerId" />
                                    <asp:BoundField DataField="CustomerNumber" HeaderText="CustomerNumber" SortExpression="CustomerNumber" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input type="button" value="Remove" id="btnRemoveOrder" runat="server"
                                                text="Save Item" title="Remove item from Order"
                                                class="rounded btn btn-outline-danger"
                                                onserverclick="btnRemoveFromQueue" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RestaurantDb %>" SelectCommand="SELECT * FROM [QueueOrders]" DeleteCommand="DELETE FROM [QueueOrders] WHERE [QueueOrderNumber] = @QueueOrderNumber">
                                <DeleteParameters>
                                    <asp:Parameter Name="QueueOrderNumber" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ServiceQueueNumber" Type="Int32" />
                                    <asp:Parameter Name="CustomerId" Type="String" />
                                    <asp:Parameter Name="CustomerNumber" Type="Int32" />
                                    <asp:Parameter Name="Status" Type="String" />
                                    <asp:Parameter Name="QueueOrderNumber" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </div>
                        <input type="button" value="View" id="btnViewQueue" runat="server"
                            text="Save Item" title="View Customers"
                            class="rounded btn btn-outline-dark"
                            onserverclick="btnViewCustomerQueue" />
                    </div>
                </div>
            </div>
        </div>
    </div>




    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <script type="text/javascript">
        $(".alert-target").click(function () {
            toastr["info"]("I was launched via jQuery!")
        });
    </script>
</asp:Content>
