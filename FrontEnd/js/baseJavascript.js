

const Upload = async () => {
    let formData = new FormData();
    var files = document.querySelectorAll(".form input[type=file]");
    for (let t = 0; t < files.length; t++) {
        var dataFile = files[t].files
        var file = dataFile[0]
        formData.append("arquivos", file)
    }
    let xmlRequest = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");
    xmlRequest.onreadystatechange = (e) => {
        if (xmlRequest.readyState == 4 && xmlRequest.status == 200) {
            var res = JSON.parse(xmlRequest.responseText)
        }
    }
    xmlRequest.open("POST", "https://localhost:5001/gerarMovimento", true)
    xmlRequest.send(formData)
}

const BuscarMovimento = async () => {

    let html=""
    let xmlRequest = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");
    xmlRequest.onreadystatechange = (e) => {
        if (xmlRequest.readyState == 4 && xmlRequest.status == 200) {
            var res = JSON.parse(xmlRequest.responseText)
            
            res.map((element)=>{
                html+="<tr>"
                html+=`<td>${element.loja.proprietario.cpf}</td>`
                html+=`<td>${element.loja.proprietario.nome}</td>`
                html+=`<td>${element.loja.nome}</td>`
                html+=`<td>${element.transacao.descricao}</td>`
                html+=`<td>${element.data}</td>`
                html+=`<td>${element.valor}</td>`
               
                html+=`<td>${element.cartao}</td>`
                html+=`<td>${element.hora}</td>`
                
                

                html+="</tr>"
            })
            $("tbody").append(html);
        }
    }
    xmlRequest.open("GET", "https://localhost:5001/gerarMovimento", true)
    xmlRequest.send()
}
