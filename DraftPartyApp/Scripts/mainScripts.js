var leagueName = "Legends of Scoreboard";
var numberOfTeams = 10;
var numberOfRounds = 16;
var rows = numberOfRounds;
var cols = numberOfTeams;
var tableHead = '';
var tableBody = '';

for (var i = 0; i < numberOfTeams; i++) {
    tableHead += '<th>Team ' + (i + 1) + '</th>';
}

for (var r = 0; r < rows; r++) {
    tableBody += '<tr>';

    for (var c = 0; c < cols; c++) {
        tableBody += '<td id="tdRow' + r + 'Col' + c + '"</td>';
    }

    tableBody += '</tr>';
}

var table = '<table><thead><tr>' + tableHead + '</tr></thead><tbody>' + tableBody + '</tbody></table>';

document.getElementById('draftBoardContainer').innerHTML = table;


$("td").click(function (event) {
    $("#elementSelected").html(event.target.id);
    $(this).toggleClass("pickSelection");
});

$("h2 span").text(leagueName);
