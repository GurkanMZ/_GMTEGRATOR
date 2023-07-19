$(document).ready(function () {
    $("#gorsel").change(function () {
        var fileName = document.getElementById("gorsel").value;
        var idxDot = fileName.lastIndexOf(".") + 1;
        var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
        if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
            //TO DO                

        } else {
            alert("Sadece resim dosyası seçebilirsiniz.");
            this.value = "";
            //    $('#gorsel').val('');
            //    document.getElementById("gorsel").value = "";
            //    document.getElementById("gorsel").setAttribute("style", "background-image: url('/image/Sistem resimleri/dot.png');width:172px;height:160px;");
        }
    });
});


$('#gorsel').on('change', function () {
    var numb = $(this)[0].files[0].size / 1024 / 1024;
    numb = numb.toFixed(2);
    if (numb > 2) {
        alert('HATA! Dosya Boyutu En fazla 2 MB olabilir');
        this.value = "";
        $('#gorsel').val('');
        document.getElementById("gorsel").value = "";

    }
});











$(document).ready(function () {
    $("#gorsel2").change(function () {
        var fileName = document.getElementById("gorsel2").value;
        var idxDot = fileName.lastIndexOf(".") + 1;
        var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
        if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
            //TO DO                

        } else {
            alert("Sadece resim dosyası seçebilirsiniz.");
            this.value = "";
            //    $('#gorsel').val('');
            //    document.getElementById("gorsel").value = "";
            //    document.getElementById("gorsel").setAttribute("style", "background-image: url('/image/Sistem resimleri/dot.png');width:172px;height:160px;");
        }
    });
});


$('#gorsel2').on('change', function () {
    var numb = $(this)[0].files[0].size / 1024 / 1024;
    numb = numb.toFixed(2);
    if (numb > 2) {
        alert('HATA! Dosya Boyutu En fazla 2 MB olabilir');
        this.value = "";
        $('#gorsel2').val('');
        document.getElementById("gorsel2").value = "";

    }
});




$(document).ready(function () {
    $("#gorsel3").change(function () {
        var fileName = document.getElementById("gorsel3").value;
        var idxDot = fileName.lastIndexOf(".") + 1;
        var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
        if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
            //TO DO                

        } else {
            alert("Sadece resim dosyası seçebilirsiniz.");
            this.value = "";
            //    $('#gorsel').val('');
            //    document.getElementById("gorsel").value = "";
            //    document.getElementById("gorsel").setAttribute("style", "background-image: url('/image/Sistem resimleri/dot.png');width:172px;height:160px;");
        }
    });
});


$('#gorsel3').on('change', function () {
    var numb = $(this)[0].files[0].size / 1024 / 1024;
    numb = numb.toFixed(2);
    if (numb > 2) {
        alert('HATA! Dosya Boyutu En fazla 2 MB olabilir');
        this.value = "";
        $('#gorsel3').val('');
        document.getElementById("gorsel3").value = "";

    }
});


$(document).ready(function () {
    $("#gorsel4").change(function () {
        var fileName = document.getElementById("gorsel4").value;
        var idxDot = fileName.lastIndexOf(".") + 1;
        var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
        if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
            //TO DO                

        } else {
            alert("Sadece resim dosyası seçebilirsiniz.");
            this.value = "";
            //    $('#gorsel').val('');
            //    document.getElementById("gorsel").value = "";
            //    document.getElementById("gorsel").setAttribute("style", "background-image: url('/image/Sistem resimleri/dot.png');width:172px;height:160px;");
        }
    });
});


$('#gorsel4').on('change', function () {
    var numb = $(this)[0].files[0].size / 1024 / 1024;
    numb = numb.toFixed(2);
    if (numb > 2) {
        alert('HATA! Dosya Boyutu En fazla 2 MB olabilir');
        this.value = "";
        $('#gorsel4').val('');
        document.getElementById("gorsel4").value = "";

    }
});