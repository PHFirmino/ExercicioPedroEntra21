async function registrar(){
    var idValue = document.getElementById("codigo").value
    var nome = document.getElementById("userNome").value
    var senha = document.getElementById("userSenha").value
    var funcao = document.getElementById("funcao").value

    let obj = {
        id : idValue,
        username : nome,
        password : senha,
        role : funcao
    }

    await fetch("https://localhost:7193/api/Users",
    {
        method : "POST",
        headers : {
            "Content-Type": "application/json"
        },
        body : JSON.stringify(obj)
    }).then(window.open("loginUser.html"))
}