document.addEventListener("DOMContentLoaded", async function(){
    var idCategoria = localStorage.getItem("idInspecionar")
    var msg = document.getElementById("msg")

    var token = localStorage.getItem("token")

    await fetch(`https://localhost:7193/api/Categorias1/${idCategoria}`, {
        method : "GET",
        headers : {
            "Authorization" : "Bearer " + token,
            "Content-Type" : "application/json"
        },
    })
         .then(response => response.json())
         .then(response => msg.innerHTML =  `<span>Id</span>: ${response.id} <br>
                                             <span>Categoria</span>: ${response.nome}
                                            `)
})