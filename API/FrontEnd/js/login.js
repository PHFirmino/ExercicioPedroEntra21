async function buscarUser(){
    var inputValue = document.getElementById("userNome").value
    var inputValue2 = document.getElementById("userSenha").value
    var msg = document.getElementById("msg2")

    let obj = {
        username :  inputValue,
        password : inputValue2
    }

    let valor

    await fetch(`https://localhost:7193/api/Users/login`, {
        method : "POST",
        headers : {
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(obj),
    }).then(response => response.json())
    .then(response => {
        valor = response.token
        localStorage.setItem("token", valor)
        window.location.href="home.html"
    })

}
