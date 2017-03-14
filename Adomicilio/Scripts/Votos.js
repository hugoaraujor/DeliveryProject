

function megusta(pid, tipo) {
    var empresa = "howmanylikes" + pid;
    var producto = "prodhowmanylikes" + pid;
    var manito = "likehand" + pid;
    var vdivname = empresa;
    var url1 = '/Empresas/Likes';
    var url2 = '/Menus/Likes';
    var url0 = url1;
    if (tipo == 2)
    { vdivname = producto;
        url0 = url2;
        var manito = "prodlikehand" + pid;
    }
   
 
        if (localStorage.getItem(vdivname) == "" || (localStorage.getItem(vdivname) == null)) {
            $.ajax({
                url: url0,
                type: "POST",
                dataType: "JSON",
                data: { id: pid, add: true },
                success: function (num) {
                    document.getElementById(vdivname).innerHTML = num;
                    document.getElementById(manito).style.color = "darkorange";
                
                }
            });
        
            localStorage.setItem(vdivname, "1");
        } else {
            localStorage.removeItem(vdivname);
            $.ajax({
                url: url0,
                type: "Post",
                dataType: "JSON",
                data: { id: pid, add: false },
                success: function (num) {
                    document.getElementById(vdivname).innerHTML = num;
                    document.getElementById(manito).style.color = "gray";
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
//----------------------------------------------------------------------Valoracion de Productos
    function valorap(id, num) {
        votap(id, num);
        var aux1 = "prodchoosestar" + id
        document.getElementById(aux1).style.display = "none";
        document.getElementById(aux1).style.visibility = "hidden";
        var aux2 = "prodranking" + id
        document.getElementById(aux2).style.display = "block";
        document.getElementById(aux2).style.visibility = "visible";



    }

    function activavalorp(id) {
        
        var existe = localStorage.getItem("votap" + id.toString());
    
        if (existe == "" || existe == null) {
            var aux1 = "prodranking" + id
            document.getElementById(aux1).style.display = "none";
            document.getElementById(aux1).style.visibility = "hidden";
            var aux2 = "prodchoosestar" + id
            document.getElementById(aux2).style.display = "block";
            document.getElementById(aux2).style.visibility = "visible";
            setTimeout("release(" + id + ")", 9000);
        }
    }


    function votap(pid, num) {
      
        var tag = 'votap' + pid;
        var existe = localStorage.getItem("votap" + pid.toString());
        if (existe == "" || existe == null) {
            $.ajax({
                url: '/Menus/Votar',
                type: "POST",
                dataType: "JSON",
                data: { id: pid, valor: num },
                success: function (num) {
  
                    localStorage.setItem(tag, num);
                    document.getElementById("Valoracionp" + pid).innerHTML = num;
                    }
            });

        }
    }