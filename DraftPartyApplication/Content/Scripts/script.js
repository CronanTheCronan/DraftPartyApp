function calculateRows() {
    var stringArray = [];
    var total = 0;

    $('.roundSetupCount').each(function () {
        stringArray.push($(this).val());
    })

    for (i = 0; i < stringArray.length; i++) {
        var currentNumber = parseInt(stringArray[i]);
        total += currentNumber;
    }

    $('#spanCalcResults').text(total);
}