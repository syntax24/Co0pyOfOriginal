// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(function () {
        var data = [];
        function setData(index) {
            data.push({ key: 1, value: 'A' });
            data.push({ key: 2, value: '-' });
            data.push({ key: 3, value: 'H' });
            data.push({ key: 4, value: 'I' });
            data.push({ key: 5, value: 'H' });
            data.push({ key: 6, value: 'I' });
            data.push({ key: 7, value: '-' });
        }
        let index = 0;
        for (let index = 0; index < 80; index++) {
            setData(index)
        }
        $(window).on('load', function () {
            let source = [{ "key": 1, "value": "thành" },
            { "key": 2, "value": "Kris" },
            { "key": 462, "value": "Donni" },
            { "key": 463, "value": "Jessika" },
            { "key": 464, "value": "Benjamen" },
            { "key": 465, "value": "Rosalyn" },
            { "key": 466, "value": "Farr" },
            { "key": 997, "value": "Caesar" },
            { "key": 998, "value": "Edie" },
            { "key": 999, "value": "Deborah" },
            { "key": 1000, "value": "Violette" }];
            var result = $('#data').panelMultiSelect({
                dataSource: source
            });
            $('#btn').on('click', function () {
                alert('id array selected: ' + result.getSelectedResult());
            })
        });
    });
});
