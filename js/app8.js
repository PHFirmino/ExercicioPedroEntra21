document.getElementById("botao").addEventListener("click", function()
{
    let foto = document.getElementById("foto")
    foto.innerHTML = ""

    fetch('https://api.thecatapi.com/v1/images/search?limit=10 ')
    .then((dados) => dados.json())
    .then((response) => 
    {
        for(let i = 0; i < response.length; i++)
        {
            foto.innerHTML += `<img src="${response[i].url}">`
        }
    }
)})