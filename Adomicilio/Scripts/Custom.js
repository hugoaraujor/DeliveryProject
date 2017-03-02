function megusta(empresaid) {
    
    if (localStorage.getItem("howmanylikes" + empresaid.toString()) == "" || localStorage.getItem("howmanylikes" + empresaid.toString()) == null)
    {
        $.ajax({
            url: '/Empresas/Likes',
            type: "Post",
            dataType: "JSON",
            data: { id: empresaid,add:true },
            success: function (num) {
                document.getElementById("howmanylikes" + empresaid).innerHTML = num;
                document.getElementById("likehand" + empresaid).style.color = "darkorange";
            }
        });
        localStorage.setItem("howmanylikes" + empresaid.toString(), "1");
        } else
            {
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




