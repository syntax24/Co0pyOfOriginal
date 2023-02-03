function DateComputing() {
    var
        persianNumbers = [/۰/g, /۱/g, /۲/g, /۳/g, /۴/g, /۵/g, /۶/g, /۷/g, /۸/g, /۹/g],
        arabicNumbers = [/٠/g, /١/g, /٢/g, /٣/g, /٤/g, /٥/g, /٦/g, /٧/g, /٨/g, /٩/g],
        fixNumbers = function (str) {
            if (typeof str === 'string') {
                for (var i = 0; i < 10; i++) {
                    str = str.replace(persianNumbers[i], i).replace(arabicNumbers[i], i);
                }
            }
            return str;
        };
    let getdate = document.getElementById('dateStart').value;
    var result;
    var m1, m2;
    var y1, y2, y3, y4;
    var d1, d2;
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
        if (i === 5) {
            m1 = fixNumbers(getdate[i]);
        }
        if (i === 6) {
            m2 = fixNumbers(getdate[i]);
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




    if (month < 7) {
        result = yRes + "/" + mRes + "/31";
    }
    if (month >= 7 && month < 12) {
        result = yRes + "/" + mRes + "/30";
    }
    if (month === 12) {
        switch (year) {
            case 1346: result = yRes + "/" + mRes + "/30";
                break;
            case 1350: result = yRes + "/" + mRes + "/30";
                break;
            case 1354: result = yRes + "/" + mRes + "/30";
                break;
            case 1358: result = yRes + "/" + mRes + "/30";
                break;
            case 1362: result = yRes + "/" + mRes + "/30";
                break;
            case 1366: result = yRes + "/" + mRes + "/30";
                break;
            case 1370: result = yRes + "/" + mRes + "/30";
                break;
            case 1375: result = yRes + "/" + mRes + "/30";
                break;
            case 1379: result = yRes + "/" + mRes + "/30";
                break;
            case 1383: result = yRes + "/" + mRes + "/30";
                break;
            case 1387: result = yRes + "/" + mRes + "/30";
                break;
            case 1391: result = yRes + "/" + mRes + "/30";
                break;
            case 1395: result = yRes + "/" + mRes + "/30";
                break;
            case 1399: result = yRes + "/" + mRes + "/30";
                break;
            case 1403: result = yRes + "/" + mRes + "/30";
                break;
            case 1408: result = yRes + "/" + mRes + "/30";
                break;
            case 1412: result = yRes + "/" + mRes + "/30";
                break;
            case 1416: result = yRes + "/" + mRes + "/30";
                break;
            case 1420: result = yRes + "/" + mRes + "/30";
                break;
            case 1424: result = yRes + "/" + mRes + "/30";
                break;
            case 1428: result = yRes + "/" + mRes + "/30";
                break;
            case 1432: result = yRes + "/" + mRes + "/30";
                break;
            case 1436: result = yRes + "/" + mRes + "/30";
                break;
            case 1441: result = yRes + "/" + mRes + "/30";
                break;
            case 1445: result = yRes + "/" + mRes + "/30";
                break;
            default: result = yRes + "/" + mRes + "/29";

        }
       
    }
  
    var endDateRes = result;
    document.getElementById('endDate').value = result;
    document.getElementById('setContract').value = getdate;

    /////////////////////////////toGorgianDate/////////////////////////////////////

    //JalaliDate = {
    //    g_days_in_month: [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31],
    //    j_days_in_month: [31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29]
    //};

    //JalaliDate.jalaliToGregorian = function (j_y, j_m, j_d) {
    //    j_y = parseInt(j_y);
    //    j_m = parseInt(j_m);
    //    j_d = parseInt(j_d);
    //    var jy = j_y - 979;
    //    var jm = j_m - 1;
    //    var jd = j_d - 1;

    //    var j_day_no = 365 * jy + parseInt(jy / 33) * 8 + parseInt((jy % 33 + 3) / 4);
    //    for (var i = 0; i < jm; ++i) j_day_no += JalaliDate.j_days_in_month[i];

    //    j_day_no += jd;

    //    var g_day_no = j_day_no + 79;

    //    var gy = 1600 + 400 * parseInt(g_day_no / 146097); /* 146097 = 365*400 + 400/4 - 400/100 + 400/400 */
    //    g_day_no = g_day_no % 146097;

    //    var leap = true;
    //    if (g_day_no >= 36525) /* 36525 = 365*100 + 100/4 */ {
    //        g_day_no--;
    //        gy += 100 * parseInt(g_day_no / 36524); /* 36524 = 365*100 + 100/4 - 100/100 */
    //        g_day_no = g_day_no % 36524;

    //        if (g_day_no >= 365) g_day_no++;
    //        else leap = false;
    //    }

    //    gy += 4 * parseInt(g_day_no / 1461); /* 1461 = 365*4 + 4/4 */
    //    g_day_no %= 1461;

    //    if (g_day_no >= 366) {
    //        leap = false;

    //        g_day_no--;
    //        gy += parseInt(g_day_no / 365);
    //        g_day_no = g_day_no % 365;
    //    }

    //    for (var i = 0; g_day_no >= JalaliDate.g_days_in_month[i] + (i == 1 && leap); i++)
    //        g_day_no -= JalaliDate.g_days_in_month[i] + (i == 1 && leap);
    //    var gm = i + 1;
    //    var gd = g_day_no + 1;

    //    gm = gm < 10 ? "0" + gm : gm;
    //    gd = gd < 10 ? "0" + gd : gd;

    //    return [gy, gm, gd];
    //}

    //var stdate = yRes + "/" + mRes + "/" + dRes;
    //dateSplitted = stdate.split("/"),
    //    jD = JalaliDate.jalaliToGregorian(dateSplitted[0], dateSplitted[1], dateSplitted[2]);
    //startResult = jD[0] + "-" + jD[1] + "-" + jD[2];

    //var endate = endDateRes;
    //dateSplitted = endate.split("/"),
    //    jD = JalaliDate.jalaliToGregorian(dateSplitted[0], dateSplitted[1], dateSplitted[2]);
    //endtResult = jD[0] + "-" + jD[1] + "-" + jD[2];

    //document.getElementById('testDate').innerHTML = "start : " + startResult;
    //document.getElementById('endDateTest').innerHTML = "end : " + endtResult;

    //let startdateSet = new Date(startResult);
    //let finishDateSet = new Date(endtResult);
    //var dayMilliseconds = 1000 * 60 * 60 * 24;
    
    //let sundayCount = 0;
    //let mondayCount = 0;
    //let tuesdayCount = 0;
    //let wednesdayCount = 0;
    //let thursdayCount = 0;
    //let fridayCount = 0;
    //let saturdayCount = 0;
    //while (startdateSet <= finishDateSet) {
    //    let days = startdateSet.getDay()
        
    //    if (days == 0) {
    //        sundayCount++;
    //    }
    //    if (days == 1) {
    //        mondayCount++;
    //    }
    //    if (days == 2) {
    //        tuesdayCount++;
    //    }
    //    if (days == 3) {
    //        wednesdayCount++;
    //    }
    //    if (days == 4) {
    //        thursdayCount++;
    //    }
    //    if (days == 5) {
    //        fridayCount++;
    //    }
    //    if (days == 6) {
    //        saturdayCount++;
    //    }

    //    startdateSet = new Date(+startdateSet + dayMilliseconds);
    //}

    //document.getElementById('sunday').innerHTML = "sundays : " + sundayCount;
    //document.getElementById('monday').innerHTML = "monday : " + mondayCount;
    //document.getElementById('tuseday').innerHTML = "tuesday : " + tuesdayCount;
    //document.getElementById('wednesday').innerHTML = "wednesday : " + wednesdayCount;
    //document.getElementById('thursday').innerHTML = "thursday : " + thursdayCount;
    //document.getElementById('friday').innerHTML = "friday : " + fridayCount;
    //document.getElementById('sturday').innerHTML = "saturday : " + saturdayCount;

  
}

//document.getElementById('dateStart').addEventListener('click', function() {
//    DateComputing();
//});
document.querySelector('#dateStart').addEventListener('keypress', function(e) {
    if (e.key === 'Enter') {
        DateComputing();
    }
});
//document.getElementById('endDate').addEventListener('change', function () {
//    DateComputing();
//});