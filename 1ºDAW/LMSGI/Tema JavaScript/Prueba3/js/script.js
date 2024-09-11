//debugger
var parrafo = document.createElement('p')
parrafo.id = 'parraf'
var txtparrafo = document.createTextNode('Hola')
parrafo.innerHTML = 'hola'
document.body.appendChild(parrafo)

var bton = document.getElementById('boton')
var txt = document.getElementById('txt')
var cuadroTexto = document.getElementById('parraf')

txt.addEventListener('keyup', event => {
    cuadroTexto.innerHTML += 'Hola: ' + (txt.maxLength - txt.value.length)
})