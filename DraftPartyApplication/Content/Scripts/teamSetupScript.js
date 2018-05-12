function defineTeams() {
    var teamsArray = [];
    var teamIds = [];
    var teamsArrayString = '';
    var teamIdsString = '';

    alert(hidTeamsLabelsList);
    alert(hidTeamsLabelsList);

    $('.teamsInputs').each(function () {
        teamsArray.push($(this).val());
    })

    teamsArrayString = teamsArray.join();
    

    $('.teamsLabels').each(function () {
        teamIds.push($(this).attr('id'));
    })

    teamIdsString = teamIds.join();


    document.getElementById('<%=hidTeamsLabelsList.ClientID%>').value = teamIdsString;
    document.getElementById('<%=hidTeamsNamesList%>').value = teamsArrayString;
}