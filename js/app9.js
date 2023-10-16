$(document).ready(() => {
    let ps = $("p")
    alert(ps[0].innerHTML)

    // $('button').click(() => {
    //     alert("olá")
    // })

    $('#btn').click(() => {
        alert("olá")
    })

    $(".enviar3").click(()=> {
        $("p.p").html("<b>olá</b>")
    })

    $(".enviar3").click(()=> {
        $("p.p").text("olá")
    })

    $(".enviar4").click(() => {
        $("p.p").text($("#input").val())
    })

    $(".enviar4").click(() => {
        $("p.p2").css({"color": "red"})
    })
})