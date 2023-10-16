$(document).ready(() => {

    $(".btn").click(() => {
        try
        {
            if($("#qnt").val() == "")
            {
                throw "Preencha o campo"
            }
            else
            {
                $(".h3").html(`<h3 class="text-center">Quantidade de cadeiras sobrando ${$("#qnt").val()}</h3>`)
                $(".h4").html(`<h3 class="text-center">Quantidade de cadeiras ocupadas 0</h3>`)
                $(".assentos").html('')

                for(let i = 0; i < $("#qnt").val(); i++)
                {
                    $(".assentos").append("<img src='images/baixados.jfif' class='col-4' alt=''>")

                    console.log($(".assentos"))
                }

                let qnt = $("#qnt").val()
                let qnt2 = 0
                $("img").click((item) => {
                    $(item.target).addClass('deletar')
                    qnt --
                    qnt2++
                    $(".h3").html(`<h3 class="text-center">Quantidade de cadeiras sobrando ${qnt}</h3>`)
                    $(".h4").html(`<h3 class="text-center">Quantidade de cadeiras ocupadas ${qnt2}</h3>`)
                })
            }
        }
        catch(error)
        {
            $("p").text(error)
        }
    })
})