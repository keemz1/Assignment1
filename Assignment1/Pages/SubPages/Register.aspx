<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Assignment1.Pages.SubPages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="regContainer container-fluid" style="height: auto">
        <div class="card text-white bg-dark mb-3 mt-5" style="margin-left: 15rem; margin-right: 15rem">
            <div class="card-header">
                <div style="margin-bottom: 0px;">
                    <h1>Registration Form</h1>
                </div>
            </div>
            <div class="card-body">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
                <div class="container" style="padding-top: 30px">
                    <div class="form-group row">
                        <asp:Label ID="lbluserName" runat="server" class="col-4 col-form-label no-wrap" Text="User Name"></asp:Label>
                        <div class="col-4">
                            <asp:TextBox ID="txtUserName" placeholder="Jane101" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter a unique user name" ControlToValidate="txtUserName" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="lblfn" runat="server" class="col-4 col-form-label no-wrap" Text="First Name"></asp:Label>
                        <div class="col-4">
                            <asp:TextBox ID="txtfname" placeholder="Jane" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter your first name" ControlToValidate="txtfname" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="lblln" runat="server" class="col-4 col-form-label no-wrap" Text="Last Name"></asp:Label>

                        <div class="col-4">
                            <asp:TextBox ID="txtlname" placeholder="Doe" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter your last name" ControlToValidate="txtlname" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="lblemail" runat="server" class="col-4 col-form-label no-wrap" Text="Email Address"></asp:Label>

                        <div class="col-4">
                            <asp:TextBox ID="txtemail" placeholder="myemail@gmail.com" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter your email address" ControlToValidate="txtemail" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect email format" ControlToValidate="txtemail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="lblpass" runat="server" class="col-4 col-form-label no-wrap" Text="Password"></asp:Label>

                        <div class="col-4">
                            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtpass" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="lblcpass" runat="server" class="col-4 col-form-label no-wrap" Text="Confirm Password"></asp:Label>

                        <div class="col-4">
                            <asp:TextBox ID="txtconfirmpass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password entered didn't match" ControlToCompare="txtpass" ControlToValidate="txtconfirmpass" ForeColor="Red">*</asp:CompareValidator>
                        </div>
                    </div>

                    <div style="">
                        <asp:Button CssClass="btn btn-outline-success btn-light btn-rounded" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" CssClass="form-control" HeaderText="Validation Errors:" ForeColor="Red" runat="server" />
                </div>
            </div>
        </div>

        <script type="text/javascript" src="Scripts/jquery-3.4.1.min.js"></script>
        <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    </div>
</asp:Content>
