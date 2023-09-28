document.getElementById("botao").addEventListener("click", function()
{
    let cep = document.getElementById("cep").value
    let msg = document.getElementById("msg")

    msg.innerHTML = ""

    fetch(`https://viacep.com.br/ws/${cep}/json/`)
    .then((dados) => dados.json())
    .then((response) => {
        console.log(response)
        msg.innerHTML += `Cidade: ${response.localidade} | Bairro: ${response.bairro} | ${response.logradouro}`
    })
})
