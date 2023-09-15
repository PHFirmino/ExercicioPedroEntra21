function mostrarIdade(){
    let idade = document.getElementById("idade").value
    let msg = document.getElementById("info")

    if(idade >= 18){
        msg.innerHTML = "Você é de maior"
    }
    else
    {
        msg.innerHTML = "Você é de menor"
    }


}