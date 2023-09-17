function cargos(){
    let infoCargo =  document.getElementById("select").value

    let salarioAntigo
    let porc
    let salarioAtual
    let msg = document.getElementById("info")
    let caiu

    console.log(infoCargo)

    switch(infoCargo)
    {
        case "gerente":
            cargo = "Gerente"
            salarioAntigo = 500
            porc = salarioAntigo / 100 * 5
            salarioAtual = salarioAntigo + porc
            break;
        case "supervisor":
            cargo = "Supervisor"
            salarioAntigo = 400
            porc = salarioAntigo / 100 * 8
            salarioAtual = salarioAntigo + porc
            break;
        case "operador":
            cargo = "Operador"
            salarioAntigo = 300
            porc = salarioAntigo / 100 * 9
            salarioAtual = salarioAntigo + porc
        break;
        case "colaborador":
            cargo = "Colaborador"
            salarioAntigo = 200
            porc = salarioAntigo / 100 * 10
            salarioAtual = salarioAntigo + porc
            break;
        default:
            caiu = true
            break;
    }

    if(caiu == true){
        msg.innerHTML = "Algo inválido"
    }
    else{
        msg.innerHTML = 
        `Cargo: ${cargo}</br> 
        Salário Antigo: ${salarioAntigo}R$</br> 
        Salário Atual: ${salarioAtual}R$</br>
        Aumento: ${porc}R$`
    }

}