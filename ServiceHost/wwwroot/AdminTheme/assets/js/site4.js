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
                    window.location.href = "#showmodal=/Admin/File/FilePage?handler=EditFile";



                }, 1000);

            } else {
                /*alert(data.message);*/

                $.Notification.autoHideNotify('error', 'top center', 'پیام سیستم ', data.message);

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

