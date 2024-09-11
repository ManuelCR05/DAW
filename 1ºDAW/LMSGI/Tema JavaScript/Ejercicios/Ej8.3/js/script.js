const areaTexto = document.getElementById('texto')
const iniciar = document.getElementById('cIniciar')
const parar = document.getElementById('cPara')
var contador = 0
var interval

iniciar.addEventListener('click', event => {
    interval = setInterval(event => {
                    areaTexto.textContent += contador + " "
                    contador += 1
               }, 1000) 
})

parar.addEventListener('click', event => {
    clearInterval(interval)
})