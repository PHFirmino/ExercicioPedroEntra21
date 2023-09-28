let escrita = document.getElementById("escrita")

function soma(n)
{
    escrita.innerHTML += n
}

function calcular()
{
    escrita.innerHTML = eval(escrita.innerHTML)
}


function apagar(){
    escrita.innerHTML = ""
}