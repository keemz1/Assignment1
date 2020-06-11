<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment1.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="container-fluid" style="height: auto">
        <div class="card text-white bg-dark mb-3" style="margin-left: 15rem; margin-right: 15rem">
            <div class="card-header">
                <h1 style="color: green;">Login</h1>
            </div>
            <div class="card-body">
                <div class="topic">
                </div>
                <div class="" style="width: 50%; margin: 0 auto;">
                    <p class="card-text">Login and take a peek at the queues available.</p>
                    <br />
                    <br />
                    <div class="mb-3">
                        <asp:Literal ID="StatusMessage" runat="server"></asp:Literal>
                    </div>
                    <br />
                    <div class="form-group row">
                        <asp:Label ID="lblemail" runat="server" class="col-sm-4 col-form-label no-wrap" Text="Email Address"></asp:Label>

                        <div class="col-5">
                            <asp:TextBox ID="txtemail" placeholder="myemail@gmail.com" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter your email address" ControlToValidate="txtemail" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect email format" ControlToValidate="txtemail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="lblpass" runat="server" class="col-sm-4 col-form-label no-wrap" Text="Password"></asp:Label>

                        <div class="col-5">
                            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtpass" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="align-content-center" style="text-align: center">
                        <div class="">
                            <asp:Button ID="btnSignin" runat="server" Text="Sign In" OnClick="btnSignin_Click"
                                CssClass="form-control btn btn-outline-primary btn-light btn-rounded"
                                Width="100px" Style="margin: auto" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
