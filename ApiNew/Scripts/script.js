

$(function () {
    $('#btnLoad').click(function () {
        $.ajax({
            url: 'http://localhost:60372/api/Projects',
            method: 'GET',
            success: function (prolist) {
                $('#msg').html(prolist.length + " Projects found");
                prolist.forEach(function (pro) {
                    var row = "<li><a href='http://localhost:60372/api/Projects'>" + pro.name + "</a></li>";
                    $('#plist').append(row);
                });

            }
        });
    });
});

