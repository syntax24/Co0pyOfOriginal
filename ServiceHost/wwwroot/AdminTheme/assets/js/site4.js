var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            console.log(error)
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
            $('.persianDateInput').persianDatepicker({
                format: 'YYYY/MM/DD',
                initialValueType: 'persian',
                initialValue: false,
                'position': 'auto',
                'position': [-270, 25],
                autoClose: true
            });


            $(document).ready(function () {
                $('.select-city').select2({
                    language: "fa",
                    dir: "rtl"
                });
            });
            $(document).ready(function () {
                $('.select-city2').select2({
                    language: "fa",
                    dir: "rtl"
                });
            });
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        console.log(data)
                        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccedded) {

                $.Notification.autoHideNotify('success', 'top center', 'پیام سیستم ', data.message);
                setTimeout(function () {
                    window.location.reload();



                }, 1000);

            } else {
                /*alert(data.message);*/

                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', data.message);

            }
            break;
        case "RefereshList":
            {
                if (data.IsSucceedded == true)
                    window.location.reload();
                //hideModal();
                //const refereshUrl = form.attr("data-refereshurl");
                //const refereshDiv = form.attr("data-refereshdiv");
                //get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        case "Compute":
            removeCall();

            var itemss = [];
            $.each(data, function (key, val) {
                itemss.push({ id: key, vall: val })
            });
            if (!$.trim(itemss[6].vall)) {
                if (itemss[0].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row" dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; روزهای کاری به کسر تعطیلات رسمی :</div><div class="col-md-1" style="text-align: center;">' + itemss[0].vall + '</div><div class="col-md-5" style="margin-right: -5px;"> روز </div></div>'


                    );
                } else {
                    $('#testCall').append(

                        '<div class="call row" dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; روزهای کاری به احتساب تعطیلات :</div><div class="col-md-1" style="text-align: center;">' + itemss[11].vall + '</div><div class="col-md-5" style="margin-right: -5px;"> روز </div></div>'


                    );
                }

                if (itemss[1].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع روزهای کاری جمعه :</div><div class="col-md-1" style="text-align: center;">' + itemss[1].vall + '</div><div class="col-md-5" style="margin-right: -5px;"> روز </div></div>'
                    );
                }


                if (itemss[2].vall != "0" && itemss[3].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای عادی :</div><div class="col-md-1" style="text-align: center;">' + itemss[2].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت <span>&nbsp;<span> و </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[3].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }
                if (itemss[2].vall != "0" && itemss[3].vall == "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای عادی :</div><div class="col-md-1" style="text-align: center;">' + itemss[2].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت  </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[2].vall == "0" && itemss[3].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای عادی :</div><div class="col-md-1" style="text-align: center;"></div><div class="col-md-2" style="margin-right: -5px;">  <span>&nbsp;<span>  </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[3].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }


                if (itemss[4].vall != "0" && itemss[5].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای جمعه :</div><div class="col-md-1" style="text-align: center;">' + itemss[4].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت <span>&nbsp;<span> و </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[5].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }
                if (itemss[4].vall != "0" && itemss[5].vall == "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای جمعه :</div><div class="col-md-1" style="text-align: center;">' + itemss[4].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت  </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[4].vall == "0" && itemss[5].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات کاری در روزهای جمعه :</div><div class="col-md-1" style="text-align: center;"></div><div class="col-md-2" style="margin-right: -5px;">  <span>&nbsp;<span>  </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[5].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }


                if (itemss[7].vall != "0" && itemss[8].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات اضافه کاری :</div><div class="col-md-1" style="text-align: center;">' + itemss[7].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت <span>&nbsp;<span> و </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[8].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }
                if (itemss[7].vall != "0" && itemss[8].vall == "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات اضافه کاری :</div><div class="col-md-1" style="text-align: center;">' + itemss[7].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت  </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[7].vall == "0" && itemss[8].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات اضافه کاری :</div><div class="col-md-1" style="text-align: center;"></div><div class="col-md-2" style="margin-right: -5px;">  <span>&nbsp;<span>  </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[8].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }



                if (itemss[9].vall != "0" && itemss[10].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات شب کاری :</div><div class="col-md-1" style="text-align: center;">' + itemss[9].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت <span>&nbsp;<span> و </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[10].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }
                if (itemss[9].vall != "0" && itemss[10].vall == "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات شب کاری :</div><div class="col-md-1" style="text-align: center;">' + itemss[9].vall + '</div><div class="col-md-2" style="margin-right: -5px;"> ساعت  </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[9].vall == "0" && itemss[10].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; مجموع ساعات شب کاری :</div><div class="col-md-1" style="text-align: center;"></div><div class="col-md-2" style="margin-right: -5px;">  <span>&nbsp;<span>  </div><div class="col-md-3" style="margin-right: -20px;">' + itemss[10].vall + '<span>&nbsp;<span><span> دقیقه </span></div></div>'
                    );
                }
                if (itemss[12] != "0") {
                    $('#testCall').append(


                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp; دستمزد روزانه :</div><div class="col-md-1" style="text-align: center;" id="dayliFee">' + itemss[12].vall + '</div><div class="col-md-2" style="margin-right: 45px;">  ریال </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[13].vall != "0") {
                    $('#testCall').append(

                        '<div class="call row"  dir="rtl"><div dir="rtl" class="col-md-6">&nbsp;  ساعت کار در هفته :</div><div class="col-md-2" style="text-align: center;" id="HoursWeekly">' + itemss[13].vall + '</div><div class="col-md-1" style="margin-right: -5px;">   </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[14] != "0") {
                    $('#testCall').append(


                        '<div class="call row"  dir="rtl" style=" display: none"><div dir="rtl" class="col-md-6">&nbsp;  کمک هزینه اقلام :</div><div class="col-md-2" style="text-align: center;" id="consumable">' + itemss[14].vall + '</div><div class="col-md-1" style="margin-right: 45px;">  </div><div class="col-md-3"></div></div>'
                    );
                }
                if (itemss[15] != "0") {
                    $('#testCall').append(


                        '<div class="call row"  dir="rtl" style=" display: none"><div dir="rtl" class="col-md-6">&nbsp;  کمک هزینه مسکن :</div><div class="col-md-2" style="text-align: center;" id="housing">' + itemss[15].vall + '</div><div class="col-md-1" style="margin-right: 45px;">  </div><div class="col-md-3"></div></div>'
                    );
                }
                //$('#testCall').append(




                //    '<div class="call" style="margin-right: 10px" dir="rtl">' + itemss[4].vall + '</div>'
                //    + '<div class="call" style="margin-right: 10px" dir="rtl">' + itemss[5].vall + '</div>'






                //);

            } else {
                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', itemss[6].vall);
            }

        case "LoadFileEditPage":
            if (data.isSuccedded) {

                $.Notification.autoHideNotify('success', 'top center', 'پیام سیستم ', data.message);
                setTimeout(function () {
                    window.location.replace("#showmodal=/Admin/Company/FilePage?handler=EditFile");

                }, 1000);

            } else {
                /*alert(data.message);*/

                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', data.message);

            }
            break;

        case "ReloadFileTitle":
            console.log(data)
            if (data.result.isSuccedded) {

                $.Notification.autoHideNotify('success', 'top center', 'پیام سیستم ', data.result.message);
                setTimeout(function () {
                    window.location.href = "#showmodal=/Admin/Company/FilePage?handler=CreateOrEditFileTitle&Type=" + data.type;
                }, 1000);
                window.location.hash = "##";
            } else {
                /*alert(data.message);*/

                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', data.result.message);

            }
            break;

        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
            });
    }
}

jQuery.validator.addMethod("maxFileSize",
    function (value, element, params) {
        var size = element.files[0].size;
        var maxSize = 3 * 1024 * 1024;
        if (size > maxSize)
            return false;
        else {
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

//jQuery.validator.addMethod("maxFileSize",
//    function (value, element, params) {
//        var size = element.files[0].size;
//        var maxSize = 3 * 1024 * 1024;
//        debugger;
//        if (size > maxSize)
//            return false;
//        else {
//            return true;
//        }
//    });
//jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

function removeCall() {

    $('div.call').remove();

}

function CreateDatePicker(fromDate, toDate = null, minDate = "") {

    if (minDate != "")
        minDate = p2e(minDate);
    
    date = minDate.toString().split("/");
    minDate = new persianDate([parseInt(date[0]), parseInt(date[1]), parseInt(date[2])]);

    //console.log(date);
    //console.log(fromDate, toDate, minDate.format('YYYY/MM/DD'));

    $(fromDate).persianDatepicker({
        format: 'YYYY/MM/DD',
        initialValueType: 'persian',
        initialValue: false,
        autoClose: true,
        minDate: minDate,

        calendar: {
            persian: {
                leapYearMode: 'astronomical'
            }
        },

        onSelect: function (dateStr) {
            $(toDate).persianDatepicker({
                minDate: new Date(dateStr),
                format: 'YYYY/MM/DD',
                initialValueType: 'persian',
                initialValue: true,
                autoClose: true,

                calendar: {
                    persian: { leapYearMode: 'astronomical' }
                }
            })

            $(toDate).val(new persianDate(dateStr).format("YYYY/MM/DD"));
        }
    });
}

const p2e = s => s.replace(/[۰-۹]/g, d => '۰۱۲۳۴۵۶۷۸۹'.indexOf(d))

function CreateTimePicker(id, defaultVal = false) {

    $(id).persianDatepicker({
        initialValue: false,
        format: 'HH:mm',
        "onlyTimePicker": true,

        "timePicker": {
            "enabled": true,
            "step": 1,
            "hour": {
                "enabled": true,
                "step": null
            },
            "minute": {
                "enabled": true,
                "step": null
            },
            "second": {
                "enabled": false,
                "step": null
            },
            "meridian": {
                "enabled": false,
            }
        }
    });
    if (defaultVal)
        $(id).val(new persianDate().format("HH:mm"))
}

function InsertTime(id) {
    $(id).val(new persianDate().format("HH:mm"));
}

//function checkDateValidation(date, checkComparison = true, activeStartDate = true, activeEndDate = true) {

//    validDate(date)

//    if (checkComparison)
//        CompareDates(date, activeStartDate, activeEndDate)
//}

function validDate(inputField) {

    var persianNumbers = [/۰/g, /۱/g, /۲/g, /۳/g, /۴/g, /۵/g, /۶/g, /۷/g, /۸/g, /۹/g],
        arabicNumbers = [/٠/g, /١/g, /٢/g, /٣/g, /٤/g, /٥/g, /٦/g, /٧/g, /٨/g, /٩/g],
        fixNumbers = function (str) {
            if (typeof str === 'string') {
                for (var i = 0; i < 10; i++) {
                    str = str.replace(persianNumbers[i], i).replace(arabicNumbers[i], i);
                }
            }
            return str;
        };
    
    let getdate;

    inputField.value == undefined ? getdate = inputField : getdate = inputField.value;

    if (getdate == '') return validCheck = true;

    var m1, m2;
    var y1, y2, y3, y4;
    var d1, d2;
    var s1, s2;
    for (var i = 0; i < getdate.length; i++) {
        if (i === 0) {
            y1 = fixNumbers(getdate[i]);
        }
        if (i === 1) {
            y2 = fixNumbers(getdate[i]);
        }
        if (i === 2) {
            y3 = fixNumbers(getdate[i]);
        }
        if (i === 3) {
            y4 = fixNumbers(getdate[i]);
        }
        if (i === 4) {
            s1 = fixNumbers(getdate[i]);
        }
        if (i === 5) {
            m1 = fixNumbers(getdate[i]);
        }
        if (i === 6) {
            m2 = fixNumbers(getdate[i]);
        }
        if (i === 7) {
            s2 = fixNumbers(getdate[i]);
        }
        if (i === 8) {
            d1 = fixNumbers(getdate[i]);
        }
        if (i === 9) {
            d2 = fixNumbers(getdate[i]);
        }

    }
    var yRes = y1 + y2 + y3 + y4;
    var year = parseInt(yRes);
    var mRes = m1 + m2;
    var month = parseInt(mRes);
    var dRes = d1 + d2;
    var day = parseInt(dRes);
    var FixResult = yRes + s1 + mRes + s2 + dRes;


    var isValid = /^([1][3-7][0-9][0-9][/])([0][1-9]|[1][0-2])([/])([0][1-9]|[1-2][0-9]|[3][0-1])$/.test(FixResult);

    if (inputField.value == undefined) {

        if (isValid)
            validCheck = true;

        else
            validCheck = false;
    }
    else {

        if (isValid) {
            //inputField.style.backgroundColor = '#a6e9a6';
            //$("button[type=submit]").attr('disabled', false);
            validCheck = true;

        } else {
            inputField.style.backgroundColor = '#f94c4c';
            $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "لطفا تاریخ را بصورت صحیح وارد کنید");
            $("button[type=submit]").attr('disabled', true)
            validCheck = false;

        }
    }

    
    return validCheck;

}


function CompareDates(date, activeStartDate = true, activeEndDate = true) {

    
    var dates = $('.date');
    var i = 0;

    for (k in dates) {

        //if (!Number.isInteger(k)) return;

        if (dates[k] == date[0])
            break;

        i++;
    }

    startDate = (i - 1 >= 0 && activeStartDate) ? $(dates[i - 1]) : $('<input id="nullDate" value="1300/01/01" hidden/>');
    middleDate = $(dates[i])
    endDate = (dates[i + 1] != undefined && activeEndDate) ? $(dates[i + 1]) : $('<input id="nullDate" value="1600/01/01" hidden/>');

    //console.log(startDate)
    //console.log(middleDate)
    //console.log(endDate)
    //console.log(startDate.val())
    //console.log(middleDate.val())
    //console.log(endDate.val())
    //console.log(validDate(startDate.val()))
    //console.log(validDate(middleDate.val()))
    //console.log(validDate(endDate.val()))
                
    if (validDate(startDate.val()) && validDate(middleDate.val()) && validDate(endDate.val())) {

        start = startDate.val().split('/').join("");
        middle = middleDate.val().split('/').join("");
        end = endDate.val().split('/').join("");

        console.log(activeStartDate, startDate.val(), middleDate.val())

        //if (activeStartDate && (startDate.val() == '' && middleDate.val() == '')) {
        //    $(endDate).css('backgroundColor', '#fff').removeClass('invalidDate');
        //    $(middleDate).css('backgroundColor', '#fff').removeClass('invalidDate');
        //    $(startDate).css('backgroundColor', '#fff').removeClass('invalidDate');

        //    var invalidDates = $('.invalidDate').length;

        //    if (invalidDates === 0)
        //        $("button[type=submit]").attr('disabled', false)

        //    return;
        //}

        //if (activeEndDate && (endDate.val() == '' && middleDate.val() == '')) {
        //    $(endDate).css('backgroundColor', '#fff').removeClass('invalidDate');
        //    $(middleDate).css('backgroundColor', '#fff').removeClass('invalidDate');
        //    $(startDate).css('backgroundColor', '#fff').removeClass('invalidDate');

        //    var invalidDates = $('.invalidDate').length;

        //    if (invalidDates === 0)
        //        $("button[type=submit]").attr('disabled', false)

        //    return;
        //}

        //if (activeStartDate && (startDate.val() == '' || middleDate.val() == ''))
        //{
        //    $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "لطفا تاریخ را درج نمایید");
        //    $(middleDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
        //    $(startDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
        //    $("button[type=submit]").attr('disabled', true)

        //    return;
        //}

        //if (activeEndDate && (endDate.val() == '' || middleDate.val() == ''))
        //{
        //    $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "لطفا تاریخ را درج نمایید");
        //    $(middleDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
        //    $(endDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
        //    $("button[type=submit]").attr('disabled', true)

        //    return;
        //}

        if (start > middle && middle > end) {

            $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "تاریخ درج شده قابل قبول نیست");
            $(endDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $(middleDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $(startDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $("button[type=submit]").attr('disabled', true)

            return;
        }
        if (start <= middle && middle > end) {

            $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "تاریخ درج شده قابل قبول نیست");
            $(endDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $(middleDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $(startDate).css('backgroundColor', '#fff').removeClass('invalidDate');
            $("button[type=submit]").attr('disabled', true)

            return;
        }
        if (start > middle && middle <= end) {

            $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "تاریخ درج شده قابل قبول نیست");
            $(endDate).css('backgroundColor', '#fff').removeClass('invalidDate');
            $(middleDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $(startDate).css('backgroundColor', '#f94c4c').addClass('invalidDate');
            $("button[type=submit]").attr('disabled', true)

            return;
        }
        if (start <= middle && middle <= end) {

            //$.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', "تاریخ درج شده قابل قبول نیست");
            $(endDate).css('backgroundColor', '#fff').removeClass('invalidDate');
            $(middleDate).css('backgroundColor', '#fff').removeClass('invalidDate');
            $(startDate).css('backgroundColor', '#fff').removeClass('invalidDate');

            var invalidDates = $('.invalidDate').length;

            if (invalidDates === 0)
                $("button[type=submit]").attr('disabled', false)

            return;
        }

        return true;
    } 

}


function removeRow(tag, sortId = '') {

    $(tag).parent().remove();

    if (sortId != '') {

        sortPS(sortId);
    }
}


function sortPS(id) {

    const turns = ['اول', 'دوم', 'سوم', 'چهارم', 'پنجم', 'ششم', 'هفتم', 'هشتم', 'نهم', 'دهم']
    var PSCount = ($("#" + id + " .proceedingSession").length - 1) / 2;
    var PS = $("#" + id + " .dateLabel");

    for (var i = 0; i < PSCount; i++) {

        $(PS[i]).html('تاریخ نوبت ' + turns[i] + ' رسیدگی')
    }
}


function numberWithCommas(input) {

    $(input).val($(input).val().split(',').join("").toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ","));
}

function setUrl(element) {

    URL = $(element).attr('href');
}

function getUrl(element) {

    window.location.hash = "##"
    $(element).attr('href', URL)
}

function getSugesstedTitles(element, type) {

    var id = $(element).attr('id') + 's';
    var tag = $(document).find('#' + id).length;

    if (tag == 0) {

        $.ajax({
            dataType: 'json',
            type: 'GET',
            url: '/Admin/Company/FilePage?handler=GetFileTitles',
            //headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            data: { "type": type },

            success: function (response) {

                $(element).attr('list', id)
                const html = `<datalist id="${id}"></datalist>`

                $(html).insertAfter(element)
                $.each(response, function (i, item) {
                    $('#' + id).append($("<option>").text(item));
                });
            },
            failure: function (response) {
                console.log(5, response)
                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', response.message);
            }
        });
    }
}

