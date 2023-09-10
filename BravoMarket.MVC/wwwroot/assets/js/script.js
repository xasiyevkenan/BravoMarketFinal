$(document).ready(function () {
    $(document).on('submit', '.form_search', function (e) {

        var searchedProductsTitle = $('#searchedProducts').val();

        $.ajax({
            url: `/OnlineMarket/Search?searchedProductsTitle=${searchedProductsTitle}`,
            type: "GET",

            success: function (response) {
                $('#searched_Product').empty();
                $('#searched_Product').append(response);
            },

            error: function (xhr) {
                console.error(xhr);
            }
        });
    });

    $(document).on('keyup', '#searchedProducts', function () {
    });
});






