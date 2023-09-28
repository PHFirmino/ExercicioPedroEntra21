document.getElementById("botao").addEventListener("click", function()
{
    let foto = document.getElementById("foto")
    
    fetch(`https://api.thecatapi.com/v1/images/search`)
    .then((dados) => dados.json())
    .then((response) => foto.innerHTML = `<img src="${response[0].url}">`)

})