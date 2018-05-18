<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Draft.aspx.cs" Inherits="DraftPartyApplication.Draft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div id="divDraftContainer">
        <div id="divRoundInfoContainer">
            <div id="divRoundInfo">
                <div id="divHeaderSection"><asp:Label runat="server" ID="lblLeagueName" Text="" /></div>
                <div id="divRoundDisplayContainer">Round: <span></span></div>
                <div id="divPickDisplayContainer">Pick: <span></span></div>
            </div>
            <div id="divDraftPlayerSelector">
                <div>Player Selector TODO</div>
                <div><asp:Button runat="server" ID="btnProcessPlayer" CssClass="btn btn-dark" Text="Pick" OnClientClick="return prepareDraft()" /></div>
            </div>
            <div>
                <div></div>
                <div></div>
            </div>
        </div>
        <div id="divDraftBoardContainer">
            <asp:Literal ID="tblDraftBoard" runat="server" />
        </div>
    </div>

    <script>

        function prepareDraft() {
            var myArr = [];

            myArr = $('.draftCell').map(function (index, element) {
                return $(element).attr('id');
            }).get();
        }
        
    </script>
</asp:Content>
