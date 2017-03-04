

function megusta(empresaid) {
    if (localStorage.getItem("howmanylikes" + empresaid.toString()) == "" || localStorage.getItem("howmanylikes" + empresaid.toString()) == null) {
        $.ajax({
            url: '/Empresas/Likes',
            type: "Post",
            dataType: "JSON",
            data: { id: empresaid, add: true },
            success: function (num) {
                document.getElementById("howmanylikes" + empresaid).innerHTML = num;
                document.getElementById("likehand" + empresaid).style.color = "darkorange";
            }
        });
        localStorage.setItem("howmanylikes" + empresaid.toString(), "1");
    } else {
        localStorage.removeItem("howmanylikes" + empresaid.toString());
        $.ajax({
            url: '/Empresas/Likes',
            type: "Post",
            dataType: "JSON",
            data: { id: empresaid, add: false },
            success: function (num) {
                document.getElementById("howmanylikes" + empresaid).innerHTML = num;
                document.getElementById("likehand" + empresaid).style.color = "gray";
            }
        });

    }
}

function release(id) {

    var aux1 = "choosestar" + id;
    document.getElementById(aux1).style.display = "none";
    document.getElementById(aux1).style.visibility = "hidden";

    var aux2 = "ranking" + id
    document.getElementById(aux2).style.display = "block";
    document.getElementById(aux2).style.visibility = "visible";


 }
 function valora(id, num) {
   
    vota(id,num);
    var aux1 = "choosestar" + id
    document.getElementById(aux1).style.display = "none";
    document.getElementById(aux1).style.visibility = "hidden";
    var aux2 = "ranking" + id
    document.getElementById(aux2).style.display = "block";
    document.getElementById(aux2).style.visibility = "visible";



   }
   function activavalor(id) {
       var existe = localStorage.getItem("vota" +id.toString());
       if (existe == "" || existe == null) {
           var aux1 = "ranking" + id
           document.getElementById(aux1).style.display = "none";
           document.getElementById(aux1).style.visibility = "hidden";
           var aux2 = "choosestar" + id
           document.getElementById(aux2).style.display = "block";
           document.getElementById(aux2).style.visibility = "visible";
           setTimeout("release(" + id + ")", 9000);
       }
     }


    function vota(empresaid, num) {
        var existe = localStorage.getItem("vota" + empresaid.toString());
        if (existe == "" || existe== null) {
            alert("2netra");
            $.ajax({
                url: '/Empresas/Votar',
                type: "Post",
                dataType: "JSON",
                data: { id: empresaid, valor: num },
                success: function (num) {
                    localStorage.setItem("vota" + empresaid.toString(), num);
                    document.getElementById("valoracion" + empresaid).innerHTML = num;

                }
            });

        }
    }