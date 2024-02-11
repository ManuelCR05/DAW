var buttonImg = document.getElementById('cImagen')
var buttonTitle = document.getElementById('cTitulo')
var buttonTxt = document.getElementById('cTexto')
var imag = document.getElementById('imagen')
var titulo = document.getElementById('titulo')
var texto = document.getElementById('texto')

buttonImg.addEventListener('click', event => {
    imag.src = 'img/descarga.png'
})

buttonTitle.addEventListener('click', event => {
    titulo.textContent = 'hola'
})

buttonTxt.addEventListener('click', event => {
    texto.textContent = 'si'
})