let arrayContato = []
let nomes = []
let emails = []
let telefones = []

document.getElementById("botao").addEventListener("click", function()
{
    let nome = document.getElementById("nome").value
    let email = document.getElementById("email").value
    let telefone = document.getElementById("telefone").value
    let div = document.getElementById("tabela")
    let lista = document.createElement("table")
    let passouNome = false
    let passouEmail = false
    let passouTelefone = false

    for(let i = 0; i < nomes.length+1; i++)
    {
        if(nome == nomes[i])
        {
            passouNome = true
            break
        }
    }
    
    for(let i = 0; i < emails.length+1; i++)
    {
        if(email == emails[i])
        {
            passouEmail = true
            break
        }
    }

    for(let i = 0; i < telefones.length+1; i++)
    {
        if(telefone == telefones[i])
        {
            passouTelefone = true
            break
        }
    }
    
    console.log(email)

    if(passouNome == false || passouEmail == false || passouTelefone == false)
    {
        nomes.push(nome)
        emails.push(email)
        telefones.push(telefone)

        let objContato = 
        {
            nome:nome,
            email:email,
            telefone:telefone
        }

        arrayContato.push(objContato)

        div.innerHTML = ""

        lista.innerHTML = 
        `<table>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Email</th>
                <th>Telefone</th>
            </tr>
        </table>`
    
        div.appendChild(lista)
        
        for(let i = 0; i < arrayContato.length; i++)
        {
            lista.innerHTML += 
                            `<tr>
                                <td>${i}</td>
                                <td>${arrayContato[i].nome}</td>
                                <td>${arrayContato[i].email}</td>
                                <td>${arrayContato[i].telefone}</td>
                            </tr>`
        }
    }
    else
    {
        alert("Esse contato já possui na lista")
    }

    console.log(arrayContato)
})


document.getElementById("remover").addEventListener("click", function()
{
    console.log("idg")
    let remover = parseInt(document.getElementById("removerNumero").value)
    let div = document.getElementById("tabela")
    let lista = document.createElement("table")
    let apagou = false

    
    for(let i = 0; i < arrayContato.length; i++)
    {
        if(remover == i)
        {
            console.log(`valor removedor ${remover}`)
            arrayContato.splice(i, 1)
            
            apagou = true
            break
        }
    }
    
    if(apagou == true)
    {
        div.innerHTML = ""
    
        lista.innerHTML = 
        `<table>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Email</th>
                <th>Telefone</th>
            </tr>
        </table>`
    
        div.appendChild(lista)
        for(let i = 0; i < arrayContato.length; i++)
        {
            lista.innerHTML += 
                            `<tr>
                                <td>${i}</td>
                                <td>${arrayContato[i].nome}</td>
                                <td>${arrayContato[i].email}</td>
                                <td>${arrayContato[i].telefone}</td>
                            </tr>`
        }
    }
    else
    {
        alert("Essa posição não existe")
    }
})

document.getElementById("botao3").addEventListener("click", function()
{
    let escrita = document.getElementById("mudar").value
    let numero = parseInt(document.getElementById("numero").value)
    let email = document.getElementById("email2").value
    let telefone2 = document.getElementById("telefone2").value


    let div = document.getElementById("tabela")
    let lista = document.createElement("table")

    let passou = false
    
    for(let i = 0; i < arrayContato.length; i++)
    {
        if(numero == i && escrita != "" && email != "" && telefone2 !="")
        {
            arrayContato[i].email = email
            arrayContato[i].nome = escrita;
            arrayContato[i].telefone = telefone2
            passou = true
            break
        }
        else if(numero == i && escrita != "" && telefone2 =="" && email == "")
        {
            arrayContato[i].nome = escrita;
            passou = true
            break
        }
        else if(numero == i && escrita != "" && telefone2 =="" && email != "")
        {
            arrayContato[i].nome = escrita;
            arrayContato[i].email = email
            passou = true
            break
        }
        else if(numero == i && escrita != "" && telefone2 !="" && email == "")
        {
            arrayContato[i].nome = escrita;
            arrayContato[i].telefone = telefone2
            passou = true
            break
        }
        else if(numero == i && email != "" && telefone2 == "" && escrita =="")
        {
            arrayContato[i].email = email
            passou = true
            break
        }
        else if(numero == i && email != "" && telefone2 == "" && escrita !="")
        {
            arrayContato[i].email = email
            arrayContato[i].nome = escrita;
            passou = true
            break
        }
        else if(numero == i && email != "" && telefone2 != "" && escrita =="")
        {
            arrayContato[i].email = email
            arrayContato[i].telefone = telefone2
            passou = true
            break
        }
        else if(numero == i && telefone2 !="" && escrita == "" && email == "")
        {   
            arrayContato[i].telefone = telefone2
            passou = true
            break
        }
        else if(numero == i && telefone2 !="" && escrita == "" && email != "")
        {   
            arrayContato[i].telefone = telefone2
            arrayContato[i].email = email
            passou = true
            break
        }
        else if(numero == i && telefone2 !="" && escrita != "" && email == "")
        {   
            arrayContato[i].telefone = telefone2
            arrayContato[i].nome = escrita;
            passou = true
            break
        }
    }

    
    if(passou == true)
    {
        div.innerHTML = ""
    
        lista.innerHTML = 
        `<table>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Email</th>
                <th>Telefone</th>
            </tr>
        </table>`
    
        div.appendChild(lista)
        console.log("ishgu")
        for(let i = 0; i < arrayContato.length; i++)
        {
            lista.innerHTML += `<tr><td>${i}</td>
                            <td>${arrayContato[i].nome}</td>
                            <td>${arrayContato[i].email}</td>
                            <td>${arrayContato[i].telefone}</td>
                            </tr>`
        }
    }
    else
    {
        alert("Verifique algo incorreto")
    }
})