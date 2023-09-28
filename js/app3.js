document.getElementById("botao").addEventListener("click", function()
{
    let n1 = parseFloat(document.getElementById("n1").value)
    let n2 = parseFloat(document.getElementById("n2").value)
    let operador = document.getElementById("operador").value
    let soma

    switch(operador)
    {
        case "*":
            soma = n1 * n2
            alert(soma)
            break
        case "/":
            soma = n1 / n2
            alert(soma)
            break
        case "-":
            soma = n1 - n2
            alert(soma)
            break 
        case "+":
            soma = n1 + n2
            alert(soma)
            break
        default:
            alert("Digite um operador válido")   

    }
})