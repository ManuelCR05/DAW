const lista = document.getElementById('listaDesordenada')
const añandir = document.getElementById('cAñadir')
const eliminar = document.getElementById('cEliminar')
var etiqueta
var texto
var txt

añandir.addEventListener('click', event => {
    texto = document.getElementById('txt').value
    etiqueta = document.createElement('li')
    txt = document.createTextNode(texto)
    etiqueta.appendChild(txt)
    lista.appendChild(etiqueta)
})

eliminar.addEventListener('click', event => {
    lista.removeChild(lista.lastChild)
})