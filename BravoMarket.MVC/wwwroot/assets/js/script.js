$(document).ready(function () {

    var skipVacancy = 3;
    var vacancyCount = $("#vacancyCount").val();

    $(document).on("click", "#loadMore", function () {

        $.ajax({
            url: "/Vacancy/LoadVacancies?skip=" + skipVacancy,
            type: "GET",
            success: function (response) {
                $("#vacancyRow").append(response);

                skipVacancy += 3; 
                console.log(skipVacancy, vacancyCount, $("#vacancyRow"));

                if (skipVacancy >= vacancyCount) { 
                    $("#loadMore").remove();
                }
            },
            error: function (xhr) {
                console.error(xhr);
            }
        });

    });

    $(document).on('input', '#input_search', function (e) {
        e.preventDefault();

        var searchedProductsTitle = $('#input_search').val();

        $.ajax({
            url: `/OnlineMarket/Search?searchedProductsTitle=${searchedProductsTitle}`,
            type: "GET",
            success: function (response) {
                $('#append_search').empty();
                $('#append_search').html(response);
            },
            error: function (xhr) {
                console.error(xhr);
            }
        });
    });

});
