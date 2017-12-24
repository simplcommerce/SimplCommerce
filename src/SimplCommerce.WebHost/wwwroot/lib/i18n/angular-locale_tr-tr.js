/*jslint indent: 2, maxerr: 50, maxlen: 120, node: true, nomen: true, plusplus: true, vars: true */
/*global angular: false */

// Tek paket halinde yüklemek için:
// angular-locale_tr-tr paketini tercih edin.

"use strict";

angular.module("ngLocale", [], ["$provide", function ($provide) {

    $provide.value("$locale", {
        "id": "tr-tr",
        "DATETIME_FORMATS": {
            "AMPMS": [
                "\u00d6\u00d6",
                "\u00d6S"
            ],
            "DAY": [
                "Pazar",
                "Pazartesi",
                "Sal\u0131",
                "\u00c7ar\u015famba",
                "Per\u015fembe",
                "Cuma",
                "Cumartesi"
            ],
            "ERAS": [
                "M\u00d6",
                "MS"
            ],
            "ERANAMES": [
                "Milattan \u00d6nce",
                "Milattan Sonra"
            ],
            "FIRSTDAYOFWEEK": 1,
            "MONTH": [
                "Ocak",
                "\u015eubat",
                "Mart",
                "Nisan",
                "May\u0131s",
                "Haziran",
                "Temmuz",
                "A\u011fustos",
                "Eyl\u00fcl",
                "Ekim",
                "Kas\u0131m",
                "Aral\u0131k"
            ],
            "SHORTDAY": [
                "Paz",
                "Pzt",
                "Sal",
                "\u00c7ar",
                "Per",
                "Cum",
                "Cmt"
            ],
            "SHORTMONTH": [
                "Oca",
                "\u015eub",
                "Mar",
                "Nis",
                "May",
                "Haz",
                "Tem",
                "A\u011fu",
                "Eyl",
                "Eki",
                "Kas",
                "Ara"
            ],
            "fullDate": "EEEE, dd MMMM y",
            "longDate": "dd MMMM y",
            "medium": "dd MMM y hh:mm:ss",
            "mediumDate": "dd MMM y",
            "mediumTime": "hh:mm:ss",
            "short": "dd/MM/yy hh:mm",
            "shortDate": "dd/MM/yy",
            "shortTime": "hh:mm"
        },
        "NUMBER_FORMATS": {
            "CURRENCY_SYM": "\u20BA",
            "DECIMAL_SEP": ",",
            "GROUP_SEP": ".",
            "PATTERNS": [
                { // Ondalık Örüntüsü (Decimal Pattern)
                    "gSize": 3,
                    "lgSize": 3,
                    "maxFrac": 3,
                    "minFrac": 0,
                    "minInt": 1,
                    "negPre": "-",
                    "negSuf": "",
                    "posPre": "",
                    "posSuf": ""
                },
                { // Para Birimi Örüntüsü (Currency Pattern)
                    "gSize": 3,
                    "lgSize": 3,
                    "maxFrac": 2,
                    "minFrac": 2,
                    "minInt": 1,
                    "negPre": "-",
                    "negSuf": "\u00a0\u00a4",
                    "posPre": "",
                    "posSuf": "\u00a0\u00a4"
                }
            ]
        },
        "pluralCat": function (num) {

            if (num === 0) {
                return "hiç";
            }

            if (num === 1) {
                return "bir";
            }

            return "birçok";
        }
    });
}]);