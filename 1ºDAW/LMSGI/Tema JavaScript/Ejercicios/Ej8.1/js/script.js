const buttonImg = document.getElementById('cImagen')
const buttonTitle = document.getElementById('cTitulo')
const buttonTxt = document.getElementById('cTexto')
const volverImg = document.getElementById('vImagen')
const volverTitle = document.getElementById('vTitulo')
const volverTxt = document.getElementById('vTexto')
var imag = document.getElementById('imagen')
var titulo = document.getElementById('titulo')
var texto = document.getElementById('texto')
const URLDADOS = 'img/PNG_transparency_demonstration_1.png'
const URLPICACHU = 'img/descarga.png'
const TITULO1 = 'Práctica de JavaScript'
const TITULO2 = 'hola'
const TXT1 = 'Lorem ipsum dolor sit amet consectetur adipisicing elit. <br>' + 
             'Deserunt vero doloribus autem numquam ipsum vitae facere. <br>' + 
             'Labore sit quisquam numquam odit amet nam eveniet. <br>' + 
             'Laborum nihil aperiam possimus ipsa quasi?'
const TXT2 = 'si'

buttonImg.addEventListener('click', event => {
    imag.src = URLPICACHU
})

buttonTitle.addEventListener('click', event => {
    titulo.textContent = TITULO2
})

buttonTxt.addEventListener('click', event => {
    texto.textContent = TXT2
})

volverImg.addEventListener('click', event => {
    imag.src = URLDADOS
})

volverTitle.addEventListener('click', event => {
    titulo.textContent = TITULO1
})

volverTxt.addEventListener('click', event => {
    texto.innerHTML = TXT1
})