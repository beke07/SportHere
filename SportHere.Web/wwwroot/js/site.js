$(document).ready(function () {
    $(".select2").select2({
        minimumInputLength: 2,
        allowClear: true,
        placeholder: 'Válasszon!',
        language: {
            inputTooShort: function () {
                return "Kérem üssön be legalább 2 karaktert!";
            },
            noResults: function () {
                return "Nincs találat!";
            }
        },
        ajax: {
            url: function () {
                return $(this).attr("url");
            },
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            type: "GET",
            data: function (searchterm) {
                return searchterm;
            },
            processResults: function (data) {
                return {
                    results: data
                };
            }
        }
    });

    $(".sport-checkbox").click(function () {

        $.ajax({
            url: $(this).attr("url"),
            data: {
                id: $(this).attr("id")
            },
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (response) {

            },
            failure: function (response) {

            }
        });
    });
});