function cargos(){
    let infoCargo =  document.getElementById("select").value
    let salarioAntigo = parseFloat(document.getElementById("salario").value)

    let salarioAtual
    let porc
    let msg = document.getElementById("info")
    let caiu

    console.log(infoCargo)

    switch(infoCargo)
    {
        case "gerente":
            cargo = "Gerente"
            porc = salarioAntigo / 100 * 5
            salarioAtual = salarioAntigo + porc
            break;
        case "supervisor":
            cargo = "Supervisor"
            porc = salarioAntigo / 100 * 8
            salarioAtual = salarioAntigo + porc
            break;
        case "operador":
            cargo = "Operador"
            porc = salarioAntigo / 100 * 9
            salarioAtual = salarioAntigo + porc
        break;
        case "colaborador":
            cargo = "Colaborador"
            porc = salarioAntigo / 100 * 10
            salarioAtual = salarioAntigo + porc
            break;
        default:
            caiu = true
            break;
    }

    if(caiu == true || salarioAntigo <= 0 || isNaN(salarioAntigo)){
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