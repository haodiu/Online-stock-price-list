"use strict" // strict mode: quản lý nghiêm ngặt hơn về cú pháp

var connection = new signalR.HubConnectionBuilder().withUrl("/bangGiaHub").build();

$(function () {
    connection.start().then(function () {
        InvokePrices();
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

function InvokePrices() {

    connection.invoke("SendPrices").catch(function (err) {

        return console.error(err.toString());
    });
}

connection.on("ReceivedPrices", function (Prices) {

    BindPricesToGrid(Prices);

});

function BindPricesToGrid(Prices) {
    $('#tblInfo tbody').empty(); // Xoá các phần tử của thẻ có id tblInfo và thẻ tbody có sẵn trước khi chạy hàm này
                                 // Nếu không dùng -> tất cả data sau khi update hoặc thêm sẽ gắn thêm vào cuối bảng trên giao diện web

    var tr;
    $.each(Prices, function (index, price) {

        tr = $('<tr/>');
        tr.append(`<td>${price.mack}</td>`);
        tr.append(`<td>${price.giamuaba}</td>`);
        tr.append(`<td>${price.soluongmuaba}</td>`);
        tr.append(`<td>${price.giamuahai}</td>`); 
        tr.append(`<td>${price.soluongmuahai}</td>`); 
        tr.append(`<td>${price.giamuamot}</td>`); 
        tr.append(`<td>${price.soluongmuamot}</td>`);
        tr.append(`<td>${price.giakhoptructuyen}</td>`);
        tr.append(`<td>${price.soluongkhoptructuyen}</td>`); 
        tr.append(`<td>${price.giabanmot}</td>`); 
        tr.append(`<td>${price.soluongbanmot}</2d>`);
        tr.append(`<td>${price.giabanhai}</td>`);
        tr.append(`<td>${price.soluongbanhai}</td>`);
        tr.append(`<td>${price.giabanba}</td>`);
        tr.append(`<td>${price.soluongbanba}</td>`);
        tr.append(`<td>${price.tongsoluong}</td>`);

        $('#tblInfo').append(tr);

    });
}