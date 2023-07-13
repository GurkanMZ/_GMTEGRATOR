

$(document).ready(function () {

    var tableData = [
        { id: 1, name: "Billy Bob", age: "12", gender: "male", height: 1, col: "red", dob: "", cheese: 1 },
        { id: 2, name: "Mary May", age: "1", gender: "female", height: 2, col: "blue", dob: "14/05/1982", cheese: true },
    ];
    var tblUrunler = new Tabulator("#tblUrunler", {
        layout: "fitDataTable",
        pagination: "local",
        paginationSize: 15,
        columns: [{ field: "STOK_KODU", title: "STOK_KODU" }],
    });


    $.ajax({
        type: "GET",
        url: "/Home/TumUrunlerList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Urunlistesi) {
            var dataaa = Urunlistesi;
            tblUrunler.on("tableBuilt", function () {
                tblUrunler.setData(dataaa);
            });
        },
        failure: function (response) {
            alert("failure");
        },
        error: function (response) {
            alert("errorrr");
        }
    });





});