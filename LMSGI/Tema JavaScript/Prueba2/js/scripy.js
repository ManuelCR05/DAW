function iniciar()
{
    titulo = document.getElementById('cabezera').innerHTML = '<title>' + 'hola' + '</title>'

    var nodoTitle = document.createElement('title')
    var txtTitle = document.createTextNode('Mi página')
    nodoTitle.appendChild(txtTitle)
    document.head.appendChild(nodoTitle)

    var nod = document.getElementsByTagName('title')
    nod[0].remove()

//----------------------------------------------------------------------------

    // var h1 = document.createElement('h1')
    // var txtH1 = document.createTextNode('Mi Título')

    // h1.appendChild(txtH1)
    // document.body.appendChild(h1)

    var titloH1 = document.getElementById('miPagina').innerHTML = '<h1>' + 'Hola' + '</h1>'


//----------------------------------------------------------------------------



    // var parrafo = document.getElementById('myPagina').innerHTML = '<p>' + 'si' + '</p>'

    var txt = document.createTextNode('hola')
    var parrafo = document.createElement('p')
    parrafo.appendChild(txt)
    document.body.appendChild(parrafo)


//----------------------------------------------------------------------------

    var gatito = new Image()
    gatito.src = './img/Captura.PNG'
    var contenedor = document.getElementById('contenedor')

    document.getElementById('generarImagen').addEventListener('click', event => {
        contenedor.textContent = gatito
    })
}