// Collapsing navbar after clicking a link
$('.navbar-collapse').click(function () {
    $(".navbar-collapse").collapse('hide');

});
$(".navbar-brand").click(function () {
    $(".navbar-collapse").collapse('hide');
})
// end of Collapsing navbar after clicking a link

$("#btnSymbol").on("click", function (event) {
    event.preventDefault();
    $("#txtError").empty();
    if ($("#SearchSymbol").val() == "") {$("#txtError").html("Symbol cannot be empty."); return }
    $.ajax({
        url: "OpenAPI/getPrice/?SearchSymbol=" + $("#SearchSymbol").val(),
        type: "GET",
        success: function (response) {
            $("#priceDiv").html(response);
        }
    });
    $.ajax({
        url: "OpenAPI/getChart/?SearchSymbol=" + $("#SearchSymbol").val(),
        type: "GET",
        success: function (res) {
            $("#symbolChartDiv").html(res);
        }
    });
    $.ajax({
        url: "OpenAPI/getInfo/?SearchSymbol=" + $("#SearchSymbol").val(),
        type: "GET",
        success: function (res) {
            $("#symbolInfoDiv").html(res);
        }
    });

});
