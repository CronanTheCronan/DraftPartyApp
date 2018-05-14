<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Draft.aspx.cs" Inherits="DraftPartyApplication.Draft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divDraftContainer">
        <div id="divDraftPlayerSelector"></div>
    <div id="divDraftBoardContainer">
        <asp:Literal ID="tblDraftBoard" runat="server" />
    </div>
        </div>
</asp:Content>
