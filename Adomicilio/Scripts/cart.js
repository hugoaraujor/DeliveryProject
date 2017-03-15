function updatecart(s,u,div1,div2,div3) {
    var sesss = s; var us =u;

    $.ajax({
        url: "/CarritodeCompras/GetCartData",
        data: { sessionid: sesss, userid: us },
        type: 'GET',
        success: function (result) {
            document.getElementById(div2).innerText = "Bs." + currencyFormatES(result.montoart);
            document.getElementById(div1).innerText = result.numarticulos + " Productos";
            document.getElementById(div3).innerText = "Bs." + currencyFormatES(result.montoart);

        }
    });
 }
function currencyFormatES(num) {
          return num
            .toFixed(2) // always two decimal digits
            .replace(".", ",") // replace decimal point character with ,
            .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")   // use . as a separator
    }