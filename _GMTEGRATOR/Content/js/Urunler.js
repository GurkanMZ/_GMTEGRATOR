

$(document).ready(function () {


    var tblUrunler = new Tabulator("#tblUrunler", {
        layout: "fitDataTable",
        pagination: "local",
        paginationSize: 15,
        columns: [

            { formatter: "rowSelection", titleFormatter: "rowSelection", align: "center", headerSort: false }
            , {
                field: "resim_url1", title: "Ürün Kodu", formatter: function (cell, formatterParams) {
                    var value = cell.getValue();
                    return "" + cell.getRow().getData().STOK_KODU + "<br><img src='" + value + "' width='80' height='80'>";
                }, cellClick: function (e, cell) {
                    var STOK_KODU = cell.getRow().getData().STOK_KODU;
                         

                    $.ajax({
                        type: "POST",
                        url: "/Urun/Index",
                        data: JSON.stringify({ STOK_KODU: STOK_KODU }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            window.open("/Urun/Index");
                            $("#STOK_ADI").val("eeee");
                        },
                        failure: function (response) {
                            alert("failure");
                        },
                        error: function (response) {
                            alert("HATAAAA"+response.responseText);
                        }
                    });

                },
            },
            {
                field: "STOK_ADI", title: "Ürün Adı", formatter: "textarea", width: 400, cellClick: function (e, cell) {
                    var STOK_KODU = cell.getRow().getData().STOK_KODU;


                    $.ajax({
                        type: "POST",
                        url: "/Urun/Index",
                        data: JSON.stringify({ STOK_KODU: STOK_KODU }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            window.open("/Urun/Index");
                            $("#STOK_ADI").val("eeee");
                        },
                        failure: function (response) {
                            alert("failure");
                        },
                        error: function (response) {
                            alert("HATAAAA" + response.responseText);
                        }
                    });

                },},
            { field: "STOK_FIYAT", title: "Fiyat" },
            { field: "STOK_ADEDI", title: "Stok" },
            { field: "Marka", title: "Marka" },
        ],
    });


    $.ajax({
        type: "GET",
        url: "/Home/TumUrunlerList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Urunlistesi) {

            tblUrunler.setData(Urunlistesi);
            //tblUrunler.on("tableBuilt", function () {
            //    tblUrunler.setData(Urunlistesi);
            //});
        },
        failure: function (response) {
            alert("failure");
        },
        error: function (response) {
            alert("errorrr");
        }
    });





});