function mostrarIdade(){
    let idade = parseInt(document.getElementById("idade").value)
    let msg = document.getElementById("info")

    if(idade < 0 || isNaN(idade)){
        msg.innerHTML = "Algo inválido"
    }
    else if( idade >= 18)
    {
        msg.innerHTML = "Você é de Maior"
    }
    else
    {
        msg.innerHTML = "Você é de menor"
    }
}