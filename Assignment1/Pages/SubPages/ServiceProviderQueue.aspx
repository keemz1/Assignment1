<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="ServiceProviderQueue.aspx.cs" Inherits="Assignment1.Pages.SubPages.RestaurantQueue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-white bg-dark mb-3 mt-3" style="margin-left: 15rem; margin-right: 15rem">
        <div class="card-header">Service Provider Kiosk</div>
        <div class="card-body">
            <h5 class="card-title">Welcome</h5>
            <p class="card-text">Here you can choose to Added or Removed from a queue of a variety of differnt service providers.</p>
            <div class="card-group">
                <div class="col" style="margin-left: 10rem;">
                    <div class="card text-white bg-primary mb-3" style="max-width: 18rem;">
                        <div class="card-header">NCB Bank</div>
                        <div class="card-body">
                            <h5 class="card-title">Primary card title</h5>
                            <p class="card-text"></p>
                            <div class="pb-3 pt-2">
                                <asp:Button CssClass="btn btn-light btn-rounded btn-outline-success"
                                    ID="NCBBank" runat="server" Text="Add/Remove"
                                    OnClick="btnGoToQueue_Click" />
                            </div>
                            <div class="row">
                                <div class="col-4 text-left">
                                    <span class="h6">Queue Position</span>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="txtQueueNumber1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card text-white bg-danger mb-3" style="max-width: 18rem;">
                        <div class="card-header">Digicel</div>
                        <div class="card-body">
                            <h5 class="card-title">Primary card title</h5>
                            <p class="card-text"></p>
                            <div class="pb-3 pt-2">
                                <asp:Button CssClass="btn btn-light btn-rounded btn-outline-success"
                                    ID="Digicel" runat="server" Text="Add/Remove"
                                    OnClick="btnGoToQueue_Click" />
                            </div>
                            <div class="row">
                                <div class="col-4 text-left">
                                    <span class="h6">Queue Position</span>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="txtQueueNumber2" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col" style="margin-right: 10rem">
                    <div class="card text-white bg-warning mb-3" style="max-width: 18rem;">
                        <div class="card-header">Automotive</div>
                        <div class="card-body">
                            <h5 class="card-title">Primary card title</h5>
                            <p class="card-text"></p>
                            <div class="pb-3 pt-2">
                                <asp:Button CssClass="btn btn-light btn-rounded btn-outline-success"
                                    ID="Automotive" runat="server" Text="Add/Remove"
                                    OnClick="btnGoToQueue_Click" />
                            </div>
                            <div class="row">
                                <div class="col-4 text-left">
                                    <span class="h6">Queue Position</span>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="txtQueueNumber3" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card text-white bg-success mb-3" style="max-width: 18rem;">
                        <div class="card-header">Restaurant</div>
                        <div class="card-body">
                            <h5 class="card-title">Primary card title</h5>
                            <p class="card-text"></p>
                            <div class="pb-3 pt-2">
                                <asp:Button CssClass="btn btn-light btn-rounded btn-outline-success"
                                    ID="Restaurant" runat="server" Text="Add/Remove"
                                    OnClick="btnGoToQueue_Click" />
                            </div>
                            <div class="row">
                                <div class="col-4 text-left">
                                    <span class="h6">Queue Position</span>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="txtQueueNumber4" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
