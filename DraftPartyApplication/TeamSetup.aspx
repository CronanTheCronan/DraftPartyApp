<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamSetup.aspx.cs" Inherits="DraftPartyApplication.TeamSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divTeamSetupContainer">
        <div>
            <h2>Teams Setup</h2>
        </div>
        <div>
            <div>
                <asp:Literal ID="tblTeamNames" runat="server" />
            </div>
        </div>
        <div id="divLSButtonContainer">
            <asp:Button runat="server" ID="btnTeamsSetup" CssClass="btn btn-dark" Text="Next" OnClick="btnTeamsSetup_Click" OnClientClick="defineTeams()" />
        </div>
    </div>
    <asp:HiddenField ID="hidTeamsLabelsList" runat="server" ClientIDMode="Static" Value="Hello" />
    <asp:HiddenField ID="hidTeamsNamesList" runat="server" ClientIDMode="Static" />
    <script src="Content/Scripts/teamSetupScript.js"></script>
</asp:Content>

