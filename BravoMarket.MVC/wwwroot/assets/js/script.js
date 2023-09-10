$(document).ready(function () {
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
