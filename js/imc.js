function calcIMC(){
    let peso = parseFloat(document.getElementById("peso").value)
    let altura = parseFloat(document.getElementById("altura").value)
    let msg = document.getElementById("info")

    let altura2 = altura * altura

    let imc = peso / altura2
    

    if(imc < 17)
    {
        msg.innerHTML = "Muito abaixo do peso"
    }
    else if(imc >= 17 && imc <= 18.49)
    {
        msg.innerHTML = "Abaixo do peso"
    }
    else if(imc >= 18.49 && imc <= 24.99)
    {
        msg.innerHTML = "Peso normal"
    }
    else if(imc >= 25 && imc <= 29.99)
    {
        msg.innerHTML = "Acima do peso"
    }
    else if(imc >= 30 && imc <= 34.99)
    {
        msg.innerHTML = "Obesidade I"
    }
    else if(imc >= 35 && imc <= 39.99)
    {
        msg.innerHTML = "Obesidade II (severa)"
    }
    else
    {
        msg.innerHTML = "Obesidade II (severa)"
    }


}