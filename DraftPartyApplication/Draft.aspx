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
                <div id="playerStickerDiv">
                </div>
                <div>
                    <input id="btnStartDraft" type="button" class="btn btn-success" value="Start Draft" />
                    <input id="btnDraftPlayer" type="button" class="btn btn-success" value="Draft Player" />
                </div>
            </div>

            <div id="divDraftPlayerSelector">
                <div>
                    <table id="tblPlayerTable" border="1" style="border-collapse: collapse">
                        <thead>
                            <tr>
                                <th class="hdnPlayerID">PlayerID</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Position</th>
                                <th>Team</th>
                            </tr>
                        </thead>
                        <tbody id="tblPlayerTableBody"></tbody>
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
                        <input id="btnFilterPlayers" type="button" class="btn btn-dark" value="Filter" />
                    </div>
                </div>
            </div>

                
        </div>
        <div id="divDraftBoardContainer">
            <asp:Literal ID="tblDraftBoard" runat="server" />
        </div>
    </div>
   
<script type="text/javascript">
    // TODO get round count and col count from C#
    var isDrafting = false;
    var myArr = [];
    var pick = 1;
    var round = 1;
    var rows = 16;
    var cols = 6;
    var currentPick;
    var playerSelected;
    var currentSticker;
    var position;

    $(document).ready(function () {
        $('#divRoundDisplayContainer span').text(round);
        $('#divPickDisplayContainer span').text(pick);

    });


    $(document).ready(function () {
        $.ajax({
            url: 'FootballDbService.asmx/GetAllPlayers',
            data: {},
            method: 'post',
            dataType: 'json',
            success: function () { console.log('success') },
            error: function (err) {
                alert(err);
            }
        });
    });

    $(document).ready(function () {
        $('#btnStartDraft').click(function () {
            var posID = $('select[id$=ddlPositionFilter]').val();
            var teamID = $('select[id$=ddlTeamsFilter]').val();

            $.ajax({
                url: 'FootballDbService.asmx/GetPlayersFromFilter',
                data: {
                    posID: 1,
                    teamID: 1
                },
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    var playerTable = $('#tblPlayerTable tbody');
                    playerTable.empty();

                    $(data).each(function (index, player) {
                        playerTable.append('<tr><td class="hdnPlayerID">' + player.PlayerID + '</td><td>' +
                            player.PlayerFirstName + '</td><td>'
                            + player.PlayerLastName + '</td><td id="playerPositionID">' + player.PositionName +
                            '</td><td>' + player.TeamName + '</td></tr>')
                    })
                },
                error: function (err) {
                    alert(err);
                }
            });
        });
    });

    $('#btnStartDraft').click(function () {
        //myArr = $('.draftCell').map(function (index, element) {
        //    return $(element).attr('id');
        //}).get();

        //currentPick = $('#' + myArr[0]);
        currentPick = '#Round' + round + 'Pick' + pick;
        $(currentPick).css('background-color', 'lightgray');
        isDrafting = true;
        $(this).hide();
        $('#btnDraftPlayer').show();
        $('#tblPlayerTable').show();

    });



    $(document).ready(function () {
        $('#btnFilterPlayers').click(function () {
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
                        playerTable.append('<tr><td class="hdnPlayerID">' + player.PlayerID + '</td><td>' +
                            player.PlayerFirstName + '</td><td>'
                            + player.PlayerLastName + '</td><td id="playerPositionID">' + player.PositionName +
                            '</td><td>' + player.TeamName + '</td></tr>')
                    })
                },
                error: function (err) {
                    alert(err);
                }
            });
        });
    });

    $('#tblPlayerTableBody').on('mouseenter', 'tr', function () {
        $(this).css("background-color", "green");
        $(this).css("color", "white");
        $(this).css("cursor", "pointer");
    }).on('mouseleave', 'tr', function () {
        $(this).css("background-color", "#F5F5F5");
        $(this).css("color", "black");
        $(this).css("cursor", "default");
        });

    $('#tblPlayerTableBody').on('click', 'tr', function(){
        playerSelected = $(this).find('.hdnPlayerID').text();
        positionSelected = $(this).find('#playerPositionID').text();
        playerSelectedDiv = $('#playerSelectedDiv');

        $.ajax({
            url: 'FootballDbService.asmx/GetPlayerByID',
            data: {
                playerID: playerSelected
            },
            method: 'post',
            dataType: 'json',
            success: function (data) {
                var playerSticker = $('#playerStickerDiv');
                playerSticker.empty();

                $(data).each(function (index, player) {
                    playerSticker.append('<div id="divTopRow"><div id="divTopLeft">' + player.PositionName + '</div><div id="divTopMiddle">'
                                         + player.PlayerFirstName + '</div><div id="divTopRight">' + player.PlayerID + '</div></div>' +
                                         '<div id="divBottomRow"><div id="divBottom">' + player.PlayerLastName + '</div></div>')
                })
            },
            error: function (err) {
                alert(err);
            }
        });

        position = $('#divTopLeft').text();
        var trimmedPosition = $.trim(position);
        switch (trimmedPosition) {
            case 'QB':
                $('#playerStickerDiv').css('background-color', 'palevioletred');
                $(currentPick).css('color', 'black');
                break;
            case 'RB':
                $('#playerStickerDiv').css('background-color', 'deepskyblue');
                $(currentPick).css('color', 'black');
                break;
            case 'WR':
                $('#playerStickerDiv').css('background-color', 'palegoldenrod');
                $(currentPick).css('color', 'black');
                break;
            case 'TE':
                $('#playerStickerDiv').css('background-color', 'mediumpurple');
                $(currentPick).css('color', 'black');
                break;
            case 'K':
                $('#playerStickerDiv').css('background-color', 'black');
                $('#playerStickerDiv').css('color', 'white');
                break;
            default:
                $('#playerStickerDiv').css('background-color', 'brown');
                $('#playerStickerDiv').css('color', 'white');
                break;
        }

    });

    //TODO write logic to fix it from drafting an empty div
    $('#btnDraftPlayer').click(function () {
        position = $('#divTopLeft').text();
        playerID = $('#divTopRight').text();
        var trimmedPosition = $.trim(position);
        var trimmedPlayerID = $.trim(playerID);
        currentSticker = $('#playerStickerDiv').html();

        $(currentPick).css('background-color', '#f5f5f5');
        $(currentPick).html(currentSticker);

        switch (trimmedPosition) {
            case 'QB':
                $(currentPick).css('background-color', 'palevioletred');
                break;
            case 'RB':
                $(currentPick).css('background-color', 'deepskyblue');
                break;
            case 'WR':
                $(currentPick).css('background-color', 'palegoldenrod');
                break;
            case 'TE':
                $(currentPick).css('background-color', 'mediumpurple');
                break;
            case 'K':
                $(currentPick).css('background-color', 'black');
                $(currentPick).css('color', 'white');
                break;
            default:
                $(currentPick).css('background-color', 'brown');
                $(currentPick).css('color', 'white');
                break;
        }

        var playerSticker = $('#playerStickerDiv');
        $(playerSticker).css('background-color', '#f5f5f5');
        playerSticker.empty();

        $.ajax({
            url: 'FootballDbService.asmx/RemovePlayerFromTable',
            data: {
                playerID: trimmedPlayerID
            },
            method: 'post',
            dataType: 'json',
            error: function (err) {
                alert(err);
            }
        });

        //TODO change to Get by Ranking
        $.ajax({
                url: 'FootballDbService.asmx/GetPlayersFromFilter',
                data: {
                    posID: 1,
                    teamID: 1
                },
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    var playerTable = $('#tblPlayerTable tbody');
                    playerTable.empty();

                    $(data).each(function (index, player) {
                        playerTable.append('<tr><td class="hdnPlayerID">' + player.PlayerID + '</td><td>' +
                            player.PlayerFirstName + '</td><td>'
                            + player.PlayerLastName + '</td><td id="playerPositionID">' + player.PositionName +
                            '</td><td>' + player.TeamName + '</td></tr>')
                    })
                },
                error: function (err) {
                    alert(err);
                }
            });

        if (round >= rows && pick >= cols) {
            isDrafting = false;
            //TODO Implement logic to process draft (perhaps export to excel)
        }
	    else if(pick >= cols){
		    pick = 1;
		    round++;
		    $('#divRoundDisplayContainer span').text(round);
            $('#divPickDisplayContainer span').text(pick);
        } else {
		    pick++;
		    $('#divPickDisplayContainer span').text(pick);
	    }	
        currentPick = '#Round' + round + 'Pick' + pick;
        $(currentPick).css('background-color', 'lightgray');
    });

    //function () {
    //$(this).css("background-color", "white");
    //$(this).css("color", "black");
    //$(this).css("cursor", "pointer");
        //$('#tblPlayerTable td').click(function(){
	       // playerSelected = $(this).text();
        //});

        //$('#btnDraftPlayer').click(function(){
	       // var currentPick = $('#' + myArr[0]);
	       // $(currentPick).text(playerSelected);
	       // myArr.shift();
        //});

        
    </script>
    <asp:HiddenField runat="server" ID="hdnPlayerSelected" />
</asp:Content>
