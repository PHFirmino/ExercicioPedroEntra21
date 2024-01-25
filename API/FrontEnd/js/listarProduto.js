document.addEventListener("DOMContentLoaded", function () {
    var tabela = document.getElementById("tb");
    tabela.innerHTML = "";

    var token = localStorage.getItem("token")

    fetch("https://localhost:7193/api/Produtos",
         {
            headers : {
                'Authorization' : 'Bearer' + token,
                "Content-Type" : "application/json"
            }
         })
        .then(response => response.json())
        .then(response => response.forEach(element => {
            tabela.innerHTML +=
                `
                    <tr>
                        <td>${element.id}</td>
                        <td>${element.descricao}</td>
                        <td>${element.preco}</td>
                        <td>${element.estoque}</td>
                        <td>${element.categoria.nome}</td>
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
                `;
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
    
    await fetch(`https://localhost:7193/api/Produtos/deletar/${botoesExcluir}`,{
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

    window.open("editarProduto.html")
}

function inspecionar(i){
    var botaoInspecionar = document.getElementsByClassName("inspecionar")[i].id
    localStorage.setItem("idInspecionar", botaoInspecionar)

    window.open("inspecionar.html")
}
