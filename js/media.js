function media(){
    let msg = document.getElementById("info")
    let freq = parseFloat(document.getElementById("freq").value)
    let n1 = parseFloat(document.getElementById("n1").value)
    
    let n2 = parseFloat(document.getElementById("n2").value)
    let n3 = parseFloat(document.getElementById("n3").value)

    let media = (n1 + n2 + n3) / 3


    if(n1 < 0 || n1 > 10 || isNaN(n1) || n2 < 0 || n2 > 10 || isNaN(n2) || n3 < 0 || n3 > 10 || isNaN(n3) || freq > 100 || freq < 0 || isNaN(freq)){

        msg.innerHTML = "Algo inválido"
    } 
    else
    {
        if(media >= 7 && freq >= 75)
        {
            msg.innerHTML = "Passou de ano"
        }
        else
        {
            msg.innerHTML = "Reprovou de ano"
        }
    }

}