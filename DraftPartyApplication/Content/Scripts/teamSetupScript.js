function defineTeams() {
    var teamsArray = [];
    var teamIds = [];
    var teamsArrayString = '';
    var teamIdsString = '';

    $('.teamsInputs').each(function () {
        teamsArray.push($(this).val());
    })

    teamsArrayString = teamsArray.join();
    
    $('.teamsLabels').each(function () {
        teamIds.push($(this).attr('id'));
    })

    teamIdsString = teamIds.join();

    document.getElementById('hidTeamsLabelsList').value = teamIdsString;
    document.getElementById('hidTeamsNamesList').value = teamsArrayString;

}