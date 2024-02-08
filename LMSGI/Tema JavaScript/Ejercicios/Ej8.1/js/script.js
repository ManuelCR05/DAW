var buttonImg = document.getElementById('cImagen')
var buttonTitle = document.getElementById('cTitulo')
var buttonIxt = document.getElementById('cTexto')
var imagen = document.getElementById('imagen')
var titulo = document.getElementById('titulo')
var texto = document.getElementById('texto')

buttonImg.addEventListener('onclick', event => {
    imagen.src = 'img/descarga.png'
})

buttonTitle.addEventListener('onclick', event => {
    titulo.innerHTML = 'hola'
})

buttonTxt.addEventListener('onclick', event => {
    texto.innerHTML = 'si'
})