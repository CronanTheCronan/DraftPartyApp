<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DraftRoom.aspx.cs" Inherits="DraftPartyApp.DraftRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div id="divHeaderContainer">
            <div id="divHeaderRoundInfo">
                <h4>Round #: <span></span></h4>
            </div>
            <div id="divHeaderLeagueInfo">
                <h1>Draft Party</h1>
                <h2><span id="leagueNameSpan"></span></h2>
            </div>
            <div id="divPlayerInfo">
                <h4>Best Player Available: <span></span></h4>
            </div>
        </div>
    </section>
    <section>
        <div id="divPlayerPicker">
            <div id="divFilters" style="display: flex; justify-content:space-around;">
                <div><span>Position Filter: </span><asp:DropDownList ID="ddlPositions" runat="server" OnSelectedIndexChanged="ddlPositions_SelectedIndexChanged"></asp:DropDownList></div>
                <div><span>Team Filter: </span><asp:DropDownList ID="ddlTeams" runat="server"></asp:DropDownList></div>
            </div>
            <div id="divPlayerTable" runat="server" style="height: 200px;">
                <asp:Panel ID="pnlPlayerContainer" runat="server"></asp:Panel>
            </div>
        </div>
    </section>
    <section>
        <div id="draftBoardContainer">
        </div>
    </section>
</asp:Content>
