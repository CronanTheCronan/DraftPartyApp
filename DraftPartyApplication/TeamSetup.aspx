<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamSetup.aspx.cs" Inherits="DraftPartyApplication.TeamSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Teams Setup</h2>
    </div>
    <div id="divTeamSetupContainer">
        <div>
            <asp:Literal ID="tblTeamNames" runat="server" />
        </div>
    </div>

</asp:Content>
