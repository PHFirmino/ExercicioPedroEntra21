let array = []

document.getElementById("botao").addEventListener("click", function()
{
    let fruta = document.getElementById("fruta").value
    let ul = document.getElementById("ul")
    let li = document.createElement("li")

    let passou = false

    for(let i = 0; i < array.length+1; i++)
    {
        if(fruta == array[i])
        {
            passou= true
            break
        }
    }

    if(passou == false)
    {
        array.push(fruta)
        li.innerHTML = fruta
        ul.appendChild(li)
    }
    else
    {
        alert("Valor Repitido")
    }

})