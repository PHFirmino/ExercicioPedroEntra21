document.addEventListener("DOMContentLoaded", async function(){
    var idProduto = localStorage.getItem("idInspecionar")
    var msg = document.getElementById("msg")

    var token = localStorage.getItem("token")

    await fetch(`https://localhost:7193/api/Produtos/${idProduto}`, {
        method : "GET",
        headers : {
            "Authorization" : "Bearer " + token,
            "Content-Type" : "application/json"
        },
    })
         .then(response => response.json())
         .then(response => msg.innerHTML =  `<span>Id</span>: ${response.id} <br>
                                             <span>Nome</span>: ${response.descricao} <br>
                                             <span>Estoque</span>: ${response.estoque} <br>
                                             <span>Preço</span>: ${response.preco} <br>
                                             <span>Categoria</span>: ${response.categoria.nome}
                                            `)
})