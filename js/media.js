function media(){
    let msg = document.getElementById("info")
    let freq = parseFloat(document.getElementById("freq").value)
    let n1 = parseFloat(document.getElementById("n1").value)
    
    let n2 = parseFloat(document.getElementById("n2").value)
    let n3 = parseFloat(document.getElementById("n3").value)

    let media = (n1 + n2 + n3) / 3

    console.log(media)

    if(media >= 7 && freq >=75)
    {
        msg.innerHTML = "PASSOU"
    }
    else
    {
        msg.innerHTML = "REPROVOU"
    }
}