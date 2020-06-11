﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Login.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="Assignment1.Pages.SubPages.Log_Out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div style="width:50%; margin:auto">
        <h1 class="" style="color: black;font-weight:600">Log out Confirmation
        </h1>
        <p style="color: black; font-weight:600; padding-top: 100px">
            Are you sure you want to log out? :(
        </p>
        <asp:Button ID="btnLogUut" runat="server" Text="Log Out" CssClass="rounded btn btn-danger col-2" OnClick="btnLogUut_Click" />
    </div>
</asp:Content>
