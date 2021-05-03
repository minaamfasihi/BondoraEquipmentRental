$(".no-of-days").change(function () {
    minValue = parseInt($(this).attr('min'));
    maxValue = parseInt($(this).attr('max'));
    currValue = parseInt($(this).val());
    if (currValue < minValue) {
        $(".no-of-days").val(minValue);
        $("#add-to-cart").attr("disabled", "disabled");
    }
    else {
        $("#add-to-cart").removeAttr("disabled");
    }
    if (currValue > maxValue) {
        $(".no-of-days").val(maxValue);
        $("#add-to-cart").attr("disabled", "disabled");
    } else {
        $("#add-to-cart").removeAttr("disabled");
    }
});
