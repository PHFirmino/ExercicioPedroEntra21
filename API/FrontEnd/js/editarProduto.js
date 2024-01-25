document.addEventListener("DOMContentLoaded", async function () {
    document.getElementById("id").value = localStorage.getItem("idEditar")

    var token = localStorage.getItem("token")
    var select = document.getElementById("select")

    await fetch("https://localhost:7193/api/Categorias1", {
        headers : {
            "Content-Type" : "application/json",
            "Authorization" : "Bearer " + token
        }
    }).then(response => response.json())
    .then(response => {
        select.innerHTML = `<option selected>Selecione</option>`
        response.forEach(element => {
            select.innerHTML += `<option value="${element.id}">${element.nome}</option>`
        })
    })
})

async function editarProduto(){
    var id = document.getElementById("id").value
    var nome = document.getElementById("nome").value
    var estoque = document.getElementById("estoque").value
    var preco = document.getElementById("preco").value
    var idCategoria = document.getElementById("select").value

    let obj = {
        id : id,
        descricao : nome,
        estoque : estoque,
        preco : preco,
        idcategoria : idCategoria
    }

    var token = localStorage.getItem("token")

    await fetch(`https://localhost:7193/api/Produtos/editar/${id}`, {
        method : "PUT",
        headers : {
            "Authorization" : "Bearer " + token,
            "Content-Type" : "application/json",
        },
        body : JSON.stringify(obj),
        
    }).then(window.open("listarProduto.html"))
}