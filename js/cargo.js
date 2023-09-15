function cargos(){
    let infoCargo =  parseInt(document.getElementById("cargo").value)
    let salarioAntigo
    let porc
    let salarioAtual
    let msg = document.getElementById("info")

    console.log(infoCargo)

    if(infoCargo > 4)
    {
        msg.innerHTML = "Não existe esse cargo"
    }
    else
    {
        switch(infoCargo)
        {
            case 1:
                cargo = "Gerente"
                salarioAntigo = 500
                porc = salarioAntigo / 100 * 5
                salarioAtual = salarioAntigo + porc
                break;
            case 2:
                cargo = "Supervisor"
                salarioAntigo = 400
                porc = salarioAntigo / 100 * 8
                salarioAtual = salarioAntigo + porc
                break;
            case 3:
                cargo = "Operador"
                salarioAntigo = 300
                porc = salarioAntigo / 100 * 9
                salarioAtual = salarioAntigo + porc
            break;
            default:
                cargo = "Colaborador"
                salarioAntigo = 200
                porc = salarioAntigo / 100 * 10
                salarioAtual = salarioAntigo + porc
                break;
        }

        msg.innerHTML = 
        `Cargo: ${cargo}, </br> 
        Salário Antigo: ${salarioAntigo}R$, </br> 
        Salário Atual: ${salarioAtual}R$, </br>
        Aumento: ${porc}R$`
    }
}