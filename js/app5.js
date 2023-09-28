let array = []
let array2 = []
let ordem = document.getElementById("ordem")


// adicionar valor na array
document.getElementById("botao").addEventListener("click", function()
{
    let n = parseInt(document.getElementById("n").value)
    array.push(n)
    array2.push(n)
    console.log(array)
})

// ordem crescente na array


function crescer(){
    let ascArray = array.sort(function(a, b)
    {
        return a - b
    })

    ordem.innerHTML = ""
    ordem.innerHTML = `Ordem crescente: `
    for(let i = 0; i < ascArray.length; i++)
    {
        ordem.innerHTML += `${ascArray[i]} `
    }
}

function descer(){
    let ascArray = array.sort(function(a, b)
    {
        return b - a
    })

    ordem.innerHTML = ""
    ordem.innerHTML = `Ordem decrescente: `
    for(let i = 0; i < ascArray.length; i++)
    {
        ordem.innerHTML += `${ascArray[i]} `
    }
}

function normal(){
    ordem.innerHTML = ""
    ordem.innerHTML = `Ordem normal: `
    for(let i = 0; i < array2.length; i++)
    {
        ordem.innerHTML += `${array2[i]} `
    }
}


document.getElementById("botao2").addEventListener("click", function()
{
    let n2 = document.getElementById("n2").value
    let msg = document.getElementById("msg")
    let caiu = false

    for(let i = 0; i < array.length; i++)
    {
        if(n2 == array[i])
        {
            msg.innerHTML = `O ${array[i]} está na posição ${i}`
            caiu = true
            break
        }
    }

    
    if(caiu == false)
    {
        alert("Não existe esse número na array")
    }
})


