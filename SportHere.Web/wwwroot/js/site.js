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

    $('.datatable thead tr').clone(true).appendTo('.datatable thead');
    $('.datatable thead tr:eq(1) th').each(function (i) {
        var title = $(this).text();

        if (title != "Részletek" && title != "Típus") {
            $(this).html('<input type="text" class="form-control d-inline-block" placeholder = "Keresés ' + title.toLocaleLowerCase() + ' szerint" /> ');
        }
        else {
            $(this).empty();
        }

        $('input', this).on('keyup change', function () {
            if (table.column(i).search() !== this.value) {
                table
                    .column(i)
                    .search(this.value)
                    .draw();
            }
        });
    });

    var table = $('.datatable').DataTable({
        orderCellsTop: true,
        fixedHeader: true,
        searching: false,
        language: {
            "lengthMenu": "Oldalanként _MENU_ elem megjelenítése",
            "zeroRecords": "Nincs találat",
            "info": " _PAGE_ / _PAGES_ oldal",
            "infoEmpty": "Nem található elem",
            "infoFiltered": "( _MAX_ elemből szűrve)",
            "search": "Keresés:",
            "paginate": {
                "previous": "Előző",
                "next": "Következő"
            }
        }
    });
});