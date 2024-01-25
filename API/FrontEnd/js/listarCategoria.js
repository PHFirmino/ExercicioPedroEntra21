document.addEventListener("DOMContentLoaded", function () {

    var tabela = document.getElementById("tb")
    tabela.innerHTML = ""

    var token = localStorage.getItem("token")
    console.log(token)

    fetch("https://localhost:7193/api/Categorias1",{
        headers : {
            "Authorization" : "Bearer " + token,
            "Content-Type" : "application/json"
        }
    })
    .then(response => response.json())
    .then(response => response.forEach(element => {
        tabela.innerHTML += 
        `
            <tr>
              <td>${element.id}
              <td>${element.nome}
              <td class="acoes">
                        <form>
                        <button type="submit" class="btn text-white bg-danger excluir" id="${element.id}">Excluir</button>
                        </form>
                        <div>
                        <button class="editar btn text-white bg-success" id="${element.id}">Editar</button>
                        <button class="inspecionar btn text-white bg-primary" id="${element.id}">Inspecionar</button>
                        </div>
                        </td>
            </tr>
        `
        console.log(response)
    }))
    .then(() => {
        var botoesExcluir = document.getElementsByClassName("excluir");
        var botoesEditar = document.getElementsByClassName("editar");
        var botoesInspecionar = document.getElementsByClassName("inspecionar");

        Array.from(botoesExcluir).forEach(function (botao, i) {
            botao.addEventListener("click", function () {
                excluir(i);
            });
        });

        Array.from(botoesEditar).forEach(function (botao, i) {
            botao.addEventListener("click", function () {
                editar(i);
            });
        });

        Array.from(botoesInspecionar).forEach(function (botao, i) {
            botao.addEventListener("click", function () {
                inspecionar(i);
            });
        });
    });
});

async function excluir(i){
    var botoesExcluir = document.getElementsByClassName("excluir")[i].id;

    var obj = {
        id : botoesExcluir
    }

    var token = localStorage.getItem("token")

    await fetch(`https://localhost:7193/api/Categorias1/deletar/${botoesExcluir}`,{
        method : "DELETE",
        headers : {
            "Authorization" : "Bearer " + token,
            "Content-Type" : "application/json"
        },
        body : JSON.stringify(obj)
    })
}

function editar(i){
    var botaoEditar = document.getElementsByClassName("editar")[i].id
    localStorage.setItem("idEditar", botaoEditar)

    window.open("editarCategoria.html")
}

function inspecionar(i){
    var botaoInspecionar = document.getElementsByClassName("inspecionar")[i].id
    localStorage.setItem("idInspecionar", botaoInspecionar)

    window.open("inspecionarCategoria.html")
}
