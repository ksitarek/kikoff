using System.ComponentModel.DataAnnotations;

namespace Kikoff.BuildingBlocks.Domain.StandardTypes;

public enum Currency
{
    [Display(Name = "United Arab Emirates dirham", Description = "784", ShortName = "AED")]
    AED = 784,

    [Display(Name = "Afghan afghani", Description = "971", ShortName = "AFN")]
    AFN = 971,

    [Display(Name = "Albanian lek", Description = "008", ShortName = "ALL")]
    ALL = 8,

    [Display(Name = "Armenian dram", Description = "051", ShortName = "AMD")]
    AMD = 51,

    [Display(Name = "Netherlands Antillean guilder", Description = "532", ShortName = "ANG")]
    ANG = 532,

    [Display(Name = "Angolan kwanza", Description = "973", ShortName = "AOA")]
    AOA = 973,

    [Display(Name = "Argentine peso", Description = "032", ShortName = "ARS")]
    ARS = 32,

    [Display(Name = "Australian dollar", Description = "036", ShortName = "AUD")]
    AUD = 36,

    [Display(Name = "Aruban florin", Description = "533", ShortName = "AWG")]
    AWG = 533,

    [Display(Name = "Azerbaijani manat", Description = "944", ShortName = "AZN")]
    AZN = 944,

    [Display(Name = "Bosnia and Herzegovina convertible mark", Description = "977", ShortName = "BAM")]
    BAM = 977,

    [Display(Name = "Barbados dollar", Description = "052", ShortName = "BBD")]
    BBD = 52,

    [Display(Name = "Bangladeshi taka", Description = "050", ShortName = "BDT")]
    BDT = 50,

    [Display(Name = "Bulgarian lev", Description = "975", ShortName = "BGN")]
    BGN = 975,

    [Display(Name = "Bahraini dinar", Description = "048", ShortName = "BHD")]
    BHD = 48,

    [Display(Name = "Burundian franc", Description = "108", ShortName = "BIF")]
    BIF = 108,

    [Display(Name = "Bermudian dollar", Description = "060", ShortName = "BMD")]
    BMD = 60,

    [Display(Name = "Brunei dollar", Description = "096", ShortName = "BND")]
    BND = 96,

    [Display(Name = "Boliviano", Description = "068", ShortName = "BOB")]
    BOB = 68,

    [Display(Name = "Bolivian Mvdol (funds code)", Description = "984", ShortName = "BOV")]
    BOV = 984,

    [Display(Name = "Brazilian real", Description = "986", ShortName = "BRL")]
    BRL = 986,

    [Display(Name = "Bahamian dollar", Description = "044", ShortName = "BSD")]
    BSD = 44,

    [Display(Name = "Bhutanese ngultrum", Description = "064", ShortName = "BTN")]
    BTN = 64,

    [Display(Name = "Botswana pula", Description = "072", ShortName = "BWP")]
    BWP = 72,

    [Display(Name = "Belarusian ruble", Description = "933", ShortName = "BYN")]
    BYN = 933,

    [Display(Name = "Belize dollar", Description = "084", ShortName = "BZD")]
    BZD = 84,

    [Display(Name = "Canadian dollar", Description = "124", ShortName = "CAD")]
    CAD = 124,

    [Display(Name = "Congolese franc", Description = "976", ShortName = "CDF")]
    CDF = 976,

    [Display(Name = "WIR euro (complementary currency)", Description = "947", ShortName = "CHE")]
    CHE = 947,

    [Display(Name = "Swiss franc", Description = "756", ShortName = "CHF")]
    CHF = 756,

    [Display(Name = "WIR franc (complementary currency)", Description = "948", ShortName = "CHW")]
    CHW = 948,

    [Display(Name = "Unidad de Fomento (funds code)", Description = "990", ShortName = "CLF")]
    CLF = 990,

    [Display(Name = "Chilean peso", Description = "152", ShortName = "CLP")]
    CLP = 152,

    [Display(Name = "Colombian peso", Description = "170", ShortName = "COP")]
    COP = 170,

    [Display(Name = "Unidad de Valor Real (UVR) (funds code)", Description = "970", ShortName = "COU")]
    COU = 970,

    [Display(Name = "Costa Rican colon", Description = "188", ShortName = "CRC")]
    CRC = 188,

    [Display(Name = "Cuban convertible peso", Description = "931", ShortName = "CUC")]
    CUC = 931,

    [Display(Name = "Cuban peso", Description = "192", ShortName = "CUP")]
    CUP = 192,

    [Display(Name = "Cape Verdean escudo", Description = "132", ShortName = "CVE")]
    CVE = 132,

    [Display(Name = "Czech koruna", Description = "203", ShortName = "CZK")]
    CZK = 203,

    [Display(Name = "Djiboutian franc", Description = "262", ShortName = "DJF")]
    DJF = 262,

    [Display(Name = "Danish krone", Description = "208", ShortName = "DKK")]
    DKK = 208,

    [Display(Name = "Dominican peso", Description = "214", ShortName = "DOP")]
    DOP = 214,

    [Display(Name = "Algerian dinar", Description = "012", ShortName = "DZD")]
    DZD = 12,

    [Display(Name = "Egyptian pound", Description = "818", ShortName = "EGP")]
    EGP = 818,

    [Display(Name = "Eritrean nakfa", Description = "232", ShortName = "ERN")]
    ERN = 232,

    [Display(Name = "Ethiopian birr", Description = "230", ShortName = "ETB")]
    ETB = 230,

    [Display(Name = "Euro", Description = "978", ShortName = "EUR")]
    EUR = 978,

    [Display(Name = "Fiji dollar", Description = "242", ShortName = "FJD")]
    FJD = 242,

    [Display(Name = "Falkland Islands pound", Description = "238", ShortName = "FKP")]
    FKP = 238,

    [Display(Name = "Pound sterling", Description = "826", ShortName = "GBP")]
    GBP = 826,

    [Display(Name = "Georgian lari", Description = "981", ShortName = "GEL")]
    GEL = 981,

    [Display(Name = "Ghanaian cedi", Description = "936", ShortName = "GHS")]
    GHS = 936,

    [Display(Name = "Gibraltar pound", Description = "292", ShortName = "GIP")]
    GIP = 292,

    [Display(Name = "Gambian dalasi", Description = "270", ShortName = "GMD")]
    GMD = 270,

    [Display(Name = "Guinean franc", Description = "324", ShortName = "GNF")]
    GNF = 324,

    [Display(Name = "Guatemalan quetzal", Description = "320", ShortName = "GTQ")]
    GTQ = 320,

    [Display(Name = "Guyanese dollar", Description = "328", ShortName = "GYD")]
    GYD = 328,

    [Display(Name = "Hong Kong dollar", Description = "344", ShortName = "HKD")]
    HKD = 344,

    [Display(Name = "Honduran lempira", Description = "340", ShortName = "HNL")]
    HNL = 340,

    [Display(Name = "Croatian kuna", Description = "191", ShortName = "HRK")]
    HRK = 191,

    [Display(Name = "Haitian gourde", Description = "332", ShortName = "HTG")]
    HTG = 332,

    [Display(Name = "Hungarian forint", Description = "348", ShortName = "HUF")]
    HUF = 348,

    [Display(Name = "Indonesian rupiah", Description = "360", ShortName = "IDR")]
    IDR = 360,

    [Display(Name = "Israeli new shekel", Description = "376", ShortName = "ILS")]
    ILS = 376,

    [Display(Name = "Indian rupee", Description = "356", ShortName = "INR")]
    INR = 356,

    [Display(Name = "Iraqi dinar", Description = "368", ShortName = "IQD")]
    IQD = 368,

    [Display(Name = "Iranian rial", Description = "364", ShortName = "IRR")]
    IRR = 364,

    [Display(Name = "Icelandic króna (plural: krónur)", Description = "352", ShortName = "ISK")]
    ISK = 352,

    [Display(Name = "Jamaican dollar", Description = "388", ShortName = "JMD")]
    JMD = 388,

    [Display(Name = "Jordanian dinar", Description = "400", ShortName = "JOD")]
    JOD = 400,

    [Display(Name = "Japanese yen", Description = "392", ShortName = "JPY")]
    JPY = 392,

    [Display(Name = "Kenyan shilling", Description = "404", ShortName = "KES")]
    KES = 404,

    [Display(Name = "Kyrgyzstani som", Description = "417", ShortName = "KGS")]
    KGS = 417,

    [Display(Name = "Cambodian riel", Description = "116", ShortName = "KHR")]
    KHR = 116,

    [Display(Name = "Comoro franc", Description = "174", ShortName = "KMF")]
    KMF = 174,

    [Display(Name = "North Korean won", Description = "408", ShortName = "KPW")]
    KPW = 408,

    [Display(Name = "South Korean won", Description = "410", ShortName = "KRW")]
    KRW = 410,

    [Display(Name = "Kuwaiti dinar", Description = "414", ShortName = "KWD")]
    KWD = 414,

    [Display(Name = "Cayman Islands dollar", Description = "136", ShortName = "KYD")]
    KYD = 136,

    [Display(Name = "Kazakhstani tenge", Description = "398", ShortName = "KZT")]
    KZT = 398,

    [Display(Name = "Lao kip", Description = "418", ShortName = "LAK")]
    LAK = 418,

    [Display(Name = "Lebanese pound", Description = "422", ShortName = "LBP")]
    LBP = 422,

    [Display(Name = "Sri Lankan rupee", Description = "144", ShortName = "LKR")]
    LKR = 144,

    [Display(Name = "Liberian dollar", Description = "430", ShortName = "LRD")]
    LRD = 430,

    [Display(Name = "Lesotho loti", Description = "426", ShortName = "LSL")]
    LSL = 426,

    [Display(Name = "Libyan dinar", Description = "434", ShortName = "LYD")]
    LYD = 434,

    [Display(Name = "Moroccan dirham", Description = "504", ShortName = "MAD")]
    MAD = 504,

    [Display(Name = "Moldovan leu", Description = "498", ShortName = "MDL")]
    MDL = 498,

    [Display(Name = "Malagasy ariary", Description = "969", ShortName = "MGA")]
    MGA = 969,

    [Display(Name = "Macedonian denar", Description = "807", ShortName = "MKD")]
    MKD = 807,

    [Display(Name = "Myanmar kyat", Description = "104", ShortName = "MMK")]
    MMK = 104,

    [Display(Name = "Mongolian tögrög", Description = "496", ShortName = "MNT")]
    MNT = 496,

    [Display(Name = "Macanese pataca", Description = "446", ShortName = "MOP")]
    MOP = 446,

    [Display(Name = "Mauritanian ouguiya", Description = "929", ShortName = "MRU")]
    MRU = 929,

    [Display(Name = "Mauritian rupee", Description = "480", ShortName = "MUR")]
    MUR = 480,

    [Display(Name = "Maldivian rufiyaa", Description = "462", ShortName = "MVR")]
    MVR = 462,

    [Display(Name = "Malawian kwacha", Description = "454", ShortName = "MWK")]
    MWK = 454,

    [Display(Name = "Mexican peso", Description = "484", ShortName = "MXN")]
    MXN = 484,

    [Display(Name = "Mexican Unidad de Inversion (UDI) (funds code)", Description = "979", ShortName = "MXV")]
    MXV = 979,

    [Display(Name = "Malaysian ringgit", Description = "458", ShortName = "MYR")]
    MYR = 458,

    [Display(Name = "Mozambican metical", Description = "943", ShortName = "MZN")]
    MZN = 943,

    [Display(Name = "Namibian dollar", Description = "516", ShortName = "NAD")]
    NAD = 516,

    [Display(Name = "Nigerian naira", Description = "566", ShortName = "NGN")]
    NGN = 566,

    [Display(Name = "Nicaraguan córdoba", Description = "558", ShortName = "NIO")]
    NIO = 558,

    [Display(Name = "Norwegian krone", Description = "578", ShortName = "NOK")]
    NOK = 578,

    [Display(Name = "Nepalese rupee", Description = "524", ShortName = "NPR")]
    NPR = 524,

    [Display(Name = "New Zealand dollar", Description = "554", ShortName = "NZD")]
    NZD = 554,

    [Display(Name = "Omani rial", Description = "512", ShortName = "OMR")]
    OMR = 512,

    [Display(Name = "Panamanian balboa", Description = "590", ShortName = "PAB")]
    PAB = 590,

    [Display(Name = "Peruvian sol", Description = "604", ShortName = "PEN")]
    PEN = 604,

    [Display(Name = "Papua New Guinean kina", Description = "598", ShortName = "PGK")]
    PGK = 598,

    [Display(Name = "Philippine peso", Description = "608", ShortName = "PHP")]
    PHP = 608,

    [Display(Name = "Pakistani rupee", Description = "586", ShortName = "PKR")]
    PKR = 586,

    [Display(Name = "Polish złoty", Description = "985", ShortName = "PLN")]
    PLN = 985,

    [Display(Name = "Paraguayan guaraní", Description = "600", ShortName = "PYG")]
    PYG = 600,

    [Display(Name = "Qatari riyal", Description = "634", ShortName = "QAR")]
    QAR = 634,

    [Display(Name = "Romanian leu", Description = "946", ShortName = "RON")]
    RON = 946,

    [Display(Name = "Serbian dinar", Description = "941", ShortName = "RSD")]
    RSD = 941,

    [Display(Name = "Renminbi", Description = "156", ShortName = "CNY")]
    CNY = 156,

    [Display(Name = "Russian ruble", Description = "643", ShortName = "RUB")]
    RUB = 643,

    [Display(Name = "Rwandan franc", Description = "646", ShortName = "RWF")]
    RWF = 646,

    [Display(Name = "Saudi riyal", Description = "682", ShortName = "SAR")]
    SAR = 682,

    [Display(Name = "Solomon Islands dollar", Description = "090", ShortName = "SBD")]
    SBD = 90,

    [Display(Name = "Seychelles rupee", Description = "690", ShortName = "SCR")]
    SCR = 690,

    [Display(Name = "Sudanese pound", Description = "938", ShortName = "SDG")]
    SDG = 938,

    [Display(Name = "Swedish krona (plural: kronor)", Description = "752", ShortName = "SEK")]
    SEK = 752,

    [Display(Name = "Singapore dollar", Description = "702", ShortName = "SGD")]
    SGD = 702,

    [Display(Name = "Saint Helena pound", Description = "654", ShortName = "SHP")]
    SHP = 654,

    [Display(Name = "Sierra Leonean leone", Description = "694", ShortName = "SLL")]
    SLL = 694,

    [Display(Name = "Sierra Leonean leone (obsolete)", Description = "925", ShortName = "SLE")]
    SLE = 925,

    [Display(Name = "Somali shilling", Description = "706", ShortName = "SOS")]
    SOS = 706,

    [Display(Name = "Surinamese dollar", Description = "968", ShortName = "SRD")]
    SRD = 968,

    [Display(Name = "South Sudanese pound", Description = "728", ShortName = "SSP")]
    SSP = 728,

    [Display(Name = "São Tomé and Príncipe dobra", Description = "930", ShortName = "STN")]
    STN = 930,

    [Display(Name = "Salvadoran colón", Description = "222", ShortName = "SVC")]
    SVC = 222,

    [Display(Name = "Syrian pound", Description = "760", ShortName = "SYP")]
    SYP = 760,

    [Display(Name = "Swazi lilangeni", Description = "748", ShortName = "SZL")]
    SZL = 748,

    [Display(Name = "Thai baht", Description = "764", ShortName = "THB")]
    THB = 764,

    [Display(Name = "Tajikistani somoni", Description = "972", ShortName = "TJS")]
    TJS = 972,

    [Display(Name = "Turkmenistan manat", Description = "934", ShortName = "TMT")]
    TMT = 934,

    [Display(Name = "Tunisian dinar", Description = "788", ShortName = "TND")]
    TND = 788,

    [Display(Name = "Tongan paʻanga", Description = "776", ShortName = "TOP")]
    TOP = 776,

    [Display(Name = "Turkish lira", Description = "949", ShortName = "TRY")]
    TRY = 949,

    [Display(Name = "Trinidad and Tobago dollar", Description = "780", ShortName = "TTD")]
    TTD = 780,

    [Display(Name = "New Taiwan dollar", Description = "901", ShortName = "TWD")]
    TWD = 901,

    [Display(Name = "Tanzanian shilling", Description = "834", ShortName = "TZS")]
    TZS = 834,

    [Display(Name = "Ukrainian hryvnia", Description = "980", ShortName = "UAH")]
    UAH = 980,

    [Display(Name = "Ugandan shilling", Description = "800", ShortName = "UGX")]
    UGX = 800,

    [Display(Name = "United States dollar", Description = "840", ShortName = "USD")]
    USD = 840,

    [Display(Name = "United States dollar (next day) (funds code)", Description = "997", ShortName = "USN")]
    USN = 997,

    [Display(Name = "Uruguay Peso en Unidades Indexadas (URUIURUI) (funds code)", Description = "940", ShortName = "UYI")]
    UYI = 940,

    [Display(Name = "Uruguayan peso", Description = "858", ShortName = "UYU")]
    UYU = 858,

    [Display(Name = "Unidad previsional", Description = "927", ShortName = "UYW")]
    UYW = 927,

    [Display(Name = "Uzbekistan som", Description = "860", ShortName = "UZS")]
    UZS = 860,

    [Display(Name = "Venezuelan bolívar digital", Description = "926", ShortName = "VED")]
    VED = 926,

    [Display(Name = "Venezuelan bolívar soberano", Description = "928", ShortName = "VES")]
    VES = 928,

    [Display(Name = "Vietnamese đồng", Description = "704", ShortName = "VND")]
    VND = 704,

    [Display(Name = "Vanuatu vatu", Description = "548", ShortName = "VUV")]
    VUV = 548,

    [Display(Name = "Samoan tala", Description = "882", ShortName = "WST")]
    WST = 882,

    [Display(Name = "CFA franc BEAC", Description = "950", ShortName = "XAF")]
    XAF = 950,

    [Display(Name = "Silver (one troy ounce)", Description = "961", ShortName = "XAG")]
    XAG = 961,

    [Display(Name = "Gold (one troy ounce)", Description = "959", ShortName = "XAU")]
    XAU = 959,

    [Display(Name = "European Composite Unit (EURCO) (bond market unit)", Description = "955", ShortName = "XBA")]
    XBA = 955,

    [Display(Name = "European Monetary Unit (E.M.U.-6) (bond market unit)", Description = "956", ShortName = "XBB")]
    XBB = 956,

    [Display(Name = "European Unit of Account 9 (E.U.A.-9) (bond market unit)", Description = "957", ShortName = "XBC")]
    XBC = 957,

    [Display(Name = "European Unit of Account 17 (E.U.A.-17) (bond market unit)", Description = "958", ShortName = "XBD")]
    XBD = 958,

    [Display(Name = "East Caribbean dollar", Description = "951", ShortName = "XCD")]
    XCD = 951,

    [Display(Name = "Special drawing rights", Description = "960", ShortName = "XDR")]
    XDR = 960,

    [Display(Name = "CFA franc BCEAO", Description = "952", ShortName = "XOF")]
    XOF = 952,

    [Display(Name = "Palladium (one troy ounce)", Description = "964", ShortName = "XPD")]
    XPD = 964,

    [Display(Name = "CFP franc (franc Pacifique)", Description = "953", ShortName = "XPF")]
    XPF = 953,

    [Display(Name = "Platinum (one troy ounce)", Description = "962", ShortName = "XPT")]
    XPT = 962,

    [Display(Name = "SUCRE", Description = "994", ShortName = "XSU")]
    XSU = 994,

    [Display(Name = "Code reserved for testing", Description = "963", ShortName = "XTS")]
    XTS = 963,

    [Display(Name = "ADB Unit of Account", Description = "965", ShortName = "XUA")]
    XUA = 965,

    [Display(Name = "No currency", Description = "999", ShortName = "XXX")]
    XXX = 999,

    [Display(Name = "Yemeni rial", Description = "886", ShortName = "YER")]
    YER = 886,

    [Display(Name = "South African rand", Description = "710", ShortName = "ZAR")]
    ZAR = 710,

    [Display(Name = "Zambian kwacha", Description = "967", ShortName = "ZMW")]
    ZMW = 967,

    [Display(Name = "Zimbabwean dollar", Description = "932", ShortName = "ZWL")]
    ZWL = 932
}
