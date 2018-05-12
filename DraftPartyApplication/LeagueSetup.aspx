<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeagueSetup.aspx.cs" Inherits="DraftPartyApplication.LeagueSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divLeagueSetupContainer">
        <div id="divLSHeaderContainer">
            <div id="divLSHeaderH2">
                <h2>League Setup</h2>
            </div>
            <div>
                <h3>During the next few screens we'll help you set up your draft for an optimal experience.</h3>
            </div>
        </div>
        <div id="divLSLeagueNameContainer">
            <div id="divLSLeagueNameLabel">
                <asp:Label runat="server" ID="lblLeagueName" Text="Enter your league name" Font-Bold="True" Font-Size="Large" />
            </div>
            <div id="divLSLeagueNameText">
                <asp:TextBox runat="server" ID="txtLeagueName" />
            </div>
        </div>
        <div id="divLSNumOfTeamsContainer">
            <div id="divLSDDLLabel">
                <asp:Label runat="server" ID="lblNumberOfTeams" Text="Enter the number of teams" Font-Bold="True" Font-Size="Large" />
            </div>
            <div id="divLSDDLContainer">
                <asp:DropDownList runat="server" ID="ddlNumberOfTeams" />
            </div>
        </div>
        <div id="divLSButtonContainer">
            <asp:Button runat="server" ID="btnLeagueSetup" CssClass="btn btn-dark" Text="Next" OnClick="btnLeagueSetup_Click" />
        </div>
    </div>

</asp:Content>
