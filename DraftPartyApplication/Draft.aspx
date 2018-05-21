<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Draft.aspx.cs" Inherits="DraftPartyApplication.Draft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="divDraftContainer">
        <div id="divRoundInfoContainer">

                <div id="divRoundInfo">
                    <div id="divHeaderSection">
                        <asp:Label runat="server" ID="lblLeagueName" Text="" />
                    </div>
                    <div id="divRoundDisplayContainer">Round: <span></span></div>
                    <div id="divPickDisplayContainer">Pick: <span></span></div>
                </div>

                <div>
                    <input id="btnStartDraft" type="button" class="btn btn-dark" value="Start Draft" />
                    <input id="btnDraftPlayer" type="button" class="btn btn-success" value="Draft Player" />
                </div>

            <div id="divDraftPlayerSelector">
                <div>
                    <table id="tblPlayerTable" border="1" style="border-collapse: collapse">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Team</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div id="divFilterSettings">
                    <div>
                        <asp:DropDownList runat="server" ID="ddlTeamsFilter" />

                    </div>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlPositionFilter" />

                    </div>
                    <div>
                        <input type="button" id="btnFilterPlayers" value="Filter" class="btn btn-dark" />
                    </div>
                </div>
            </div>

                
        </div>
        <div id="divDraftBoardContainer">
            <asp:Literal ID="tblDraftBoard" runat="server" />
        </div>
    </div>
   
    <script type="text/javascript">

        var draftStarted = false;
        var myArr = [];
        var firstPick;
        var playerSelected;



$('#btnDraftPlayer').click(function(){
	var currentPick = $('#' + myArr[0]);
	$(currentPick).text(playerSelected);
	myArr.shift();
});

        // TODO Implement this.
        //$('select[id$=ddlTeamsFilter]').val();

        $('#btnStartDraft').click(function () { 
            myArr = $('.draftCell').map(function (index, element) {
                return $(element).attr('id');
            }).get();

            firstPick = $('#' + myArr[0]);
            $(firstPick).css('background-color', 'lightgray');
            draftStarted = true;

            $(this).css('display', 'none');

        })

        $(document).ready(function () {
            var posID = $('select[id$=ddlPositionFilter]').val();
            var teamID = $('select[id$=ddlTeamsFilter]').val();

            $.ajax({
                url: 'FootballDbService.asmx/GetPlayersFromFilter',
                data: {
                    posID: posID,
                    teamID: teamID
                },
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    var playerTable = $('#tblPlayerTable tbody');
                    playerTable.empty();

                    $(data).each(function (index, player) {
                        playerTable.append('<tr><td>' + player.PlayerName + '</td><td>'
                            + player.PositionName + '</td><td>' + player.TeamName + '</td>')
                    })
                },
                error: function (err) {
                    alert(err);
                }
            });
        });

        $(document).ready(function () {
            $('#btnFilterPlayers').click(function () {
                var posID = $('select[id$=ddlPositionFilter]').val();
                var teamID = $('select[id$=ddlTeamsFilter]').val();
                playerSelected = null;
                $.ajax({
                    url: 'FootballDbService.asmx/GetPlayersFromFilter',
                    data: {
                        posID: posID,
                        teamID: teamID
                    },
                    method: 'post',
                    dataType: 'json',
                    success: function (data) {
                        var playerTable = $('#tblPlayerTable tbody');
                        playerTable.empty();

                        $(data).each(function (index, player) {
                            playerTable.append('<tr><td>' + player.PlayerName + '</td><td>'
                            + player.PositionName + '</td><td>' + player.TeamName + '</td>')
                        })
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            });
        });

        $('#tblPlayerTable td').click(function(){
	        playerSelected = $(this).text();
        });

        $('#btnDraftPlayer').click(function(){
	        var currentPick = $('#' + myArr[0]);
	        $(currentPick).text(playerSelected);
	        myArr.shift();
        });

        
    </script>

</asp:Content>
