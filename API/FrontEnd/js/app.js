function carregarCategoria(){

    var tabela = document.getElementById("tb")
    tabela.innerHTML = ""

    var token = localStorage.getItem("token")

    fetch("https://localhost:7193/api/Produtos",{
        headers : {
            "Authorization" : "Bearer" + token
        }
    })
    .then(response => response.json())
    .then(response => response.forEach(element => {
        tabela.innerHTML += 
        `
            <tr>
              <td>${element.id}
              <td>${element.descricao}
              <td>${element.preco}
              <td>${element.estoque}
              <td>${element.categoria.nome}</td>
            </tr>
        `
        console.log(response)
    }))
}

async function adicionarProduto(){
    var idValue = document.getElementById("id").value
    var nome = document.getElementById("nome").value
    var estoque = document.getElementById("estoque").value
    var preco = document.getElementById("preco").value
    var idCategoria = document.getElementById("categoria").value

    let obj = {
        id : idValue,
        descricao : nome,
        estoque : estoque,
        preco : preco,
        idcategoria : idCategoria
    }

    await fetch("https://localhost:7193/api/Produtos",{
        method: "POST",
        headers :{
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(obj)
      }
    )
}

function buscar(){
    var inputValue = document.getElementById("consultar").value
    var msg = document.getElementById("msg")

    fetch(`https://localhost:7193/api/Produtos/${inputValue}`)
    .then(response => response.json())
    .then(response => msg.innerHTML = `Id: ${response.id} Nome: ${response.descricao} Estoque: ${response.preco} Preço: ${response.preco} Categoria: ${response.categoria.nome}`)
}


