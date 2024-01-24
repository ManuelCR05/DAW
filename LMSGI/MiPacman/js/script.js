// Mapa, Constantes y Variables Golbales, Objetos y Arrays:
var mapa = [
    [9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9],
    [9,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,9],
    [9,1,9,9,1,9,9,9,1,9,1,9,9,9,1,9,9,1,9],
    [9,1,9,9,1,9,9,9,1,9,1,9,9,9,1,9,9,1,9],
    [9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9],
    [9,1,9,9,1,9,1,9,9,0,9,9,1,9,1,9,9,1,9],
    [9,5,1,1,1,9,1,1,1,9,1,1,1,9,1,1,1,5,9],
    [9,9,9,9,1,9,9,9,1,9,1,9,9,9,1,9,9,9,9],
    [9,5,1,1,1,4,1,4,1,1,1,4,1,4,1,1,1,5,9],
    [9,1,9,9,1,9,1,9,9,9,9,9,1,9,1,9,9,1,9],
    [9,1,9,9,1,9,1,9,9,9,9,9,1,9,1,9,9,1,9],
    [9,1,1,1,1,9,1,1,1,0,1,1,1,9,1,1,1,1,9],
    [9,1,9,9,1,9,1,9,9,9,9,9,1,9,1,9,9,1,9],
    [9,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,9],
    [9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9]
]

const TILEX = 50
const TILEY = 50
const NUMFILAS = 15
const NUMCOLUMNAS = 19
const RESOLUCION = [TILEX * NUMCOLUMNAS, TILEY * NUMFILAS]
const FPS = 60
const NUMFANTASMAS = 4
const COLORFONDO = '#A9A9A9'

var contadorFPS = 0
var updateConteoFPS = 0
var puntuacion = 0
var vidas = 5
var gameover = false
var momentoActual = 1

//------------------------OBJETOS/ARRAYS------------------------//
var laberinto
var pacman
var fantasma
var cereza
var puntito = []
var arrayPuntitos = []
var punto = []
var arrayPuntos = []


// Clases:
class Laberinto {
    constructor() {

    }

    comprobarColision(x, y) {
        if (mapa[y][x] == 9) {
            return true
        }
        else {
            return false
        }
    }

    dibujarLaberinto() {
        for (let y = 0; y < mapa.length; y++) {
            for (let x = 0; x < mapa[0].length; x++) {
                if (mapa[y][x] == 9) {
                    context.drawImage(bloqueImg, 0, 0, bloqueImg.width - 1, bloqueImg.height - 1, x * TILEX, y * TILEY, TILEX, TILEY)
                }
            }
        }
    }
}

class Pacman {
    constructor() {
        this.x = 9 * TILEX
        this.y = 5 * TILEY
        this.ancho = TILEX 
        this.alto = TILEY
        this.movX = 1
        this.movY = 0
        this.sumarAncho = 1
        this.sumarAlto = 0

        this.direccion = {
            right: [1, 0, 1, 0], 
            left: [-1, 0, 0, 0], 
            up: [0, -1, 0, 0],            
            down: [0, 1, 0, 1]
        }

        this.teclaPulsada
    }

    actualizarPosiciones() {
        let x = 0
        let y = 0

        if (this.x % TILEX == 0 && this.y % TILEY == 0) {
            if (this.direccion.hasOwnProperty(this.teclaPulsada)) {
                x = parseInt(this.x / TILEX + this.direccion[this.teclaPulsada][0])
                y = parseInt(this.y / TILEY + this.direccion[this.teclaPulsada][1])

                if (!(laberinto.comprobarColision(x, y))) {
                    this.movX = this.direccion[this.teclaPulsada][0]
                    this.movY = this.direccion[this.teclaPulsada][1]
                    this.sumarAncho = this.direccion[this.teclaPulsada][2]
                    this.sumarAlto = this.direccion[this.teclaPulsada][3]
                }

                for (let i = 0; i < arrayPuntitos.length; i++) {
                    if (puntito[i].comprobarColision(x, y)) {
                        puntito[i].visibilidad = false;
                        puntuacion += puntito[i].puntuacionPuntitos
                        break;
                    }
                }

                for (let i = 0; i < arrayPuntos.length; i++) {
                    if (punto[i].comprobarColision(x, y)) {
                        punto[i].visibilidad = false;
                        puntuacion += punto[i].puntuacionPunto
                        break;
                    }
                }
            }
        }

        x = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        y = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        if (!(laberinto.comprobarColision(x, y))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }
    }

    dibujarPacman() {
        if (momentoActual == 1) {this.actualizarPosiciones()}

        context.drawImage(pacmanImg, 0, 0, pacmanImg.width - 1, pacmanImg.height - 1, this.x, this.y, this.ancho, this.alto)
    }

    arriba() {
        this.teclaPulsada = 'up'
    }

    abajo() {
        this.teclaPulsada = 'down'
    }

    derecha() {
        this.teclaPulsada = 'right'
    }

    izquierda() {
        this.teclaPulsada = 'left'
    }
}

class Fantasmas {
    constructor() {
        
    }
}

class Puntitos {
    constructor(x, y) {
        this.x = x 
        this.y = y 
        this.visibilidad = true
        this.puntuacionPuntitos = 5
        this.dibujarPuntitos()
    }

    comprobarColision(x, y) {
        return this.x === x && this.y === y && this.visibilidad;
    }

    dibujarPuntitos() {
        if (this.visibilidad) {
            context.drawImage(puntitoImg, 0, 0, puntitoImg.width - 1, puntitoImg.height - 1, this.x * TILEX + 20 , this.y * TILEY + 20, TILEX - 40, TILEY - 40);
        }
    }

    dibujarFondo() {
        context.beginPath()
        context.fillStyle = COLORFONDO
        context.fill()
        context.closePath
    }
}

class Puntos {
    constructor(x, y) {
        this.x = x 
        this.y = y 
        this.visibilidad = true
        this.puntuacionPunto = 15
        this.dibujarPuntos()
    }

    comprobarColision(x, y) {
        return this.x === x && this.y === y && this.visibilidad;
    }

    dibujarPuntos() {
        if (this.visibilidad) {
            context.drawImage(puntoImg, 0, 0, puntoImg.width - 1, puntoImg.height - 1, this.x * TILEX + 10 , this.y * TILEY + 10, TILEX - 20, TILEY - 20);
        }
    }

    dibujarFondo() {
        context.beginPath()
        context.fillStyle = COLORFONDO
        context.fill()
        context.closePath
    }
}

class Cereza {
    constructor() {
        
    }
}


// Evento:
window.addEventListener('keydown', (event) => {
    if (event.key == 'w' || event.key == 'W' || event.keyCode == 38) {
        pacman.arriba() 
    }
    else if (event.key == 's' || event.key == 'S' || event.keyCode == 40) {
        pacman.abajo()
    }
    else if (event.key == 'a' || event.key == 'A' || event.keyCode == 37) {
        pacman.izquierda()
    }
    else if (event.key == 'd' || event.key == 'D' || event.keyCode == 39) {
        pacman.derecha()
    }
})


// Funciones:
function instanciarJuego() {
    let contadorPuntitos = 0
    let contadorPuntos = 0
    canvas = document.getElementById('myCanvas')
    context = canvas.getContext('2d')
    canvas.width = RESOLUCION[0]
    canvas.height = RESOLUCION[1]


    bloqueImg = new Image()
    bloqueImg.src = './img/Bloque.png'

    pacmanImg = new Image()
    pacmanImg.src = './img/pacman.png'

    puntitoImg = new Image()
    puntitoImg.src = './img/puntito.png'

    puntoImg = new Image()
    puntoImg.src = './img/punto.png'

    cerezaImg = new Image()
    cerezaImg.src = './img/cereza.png'

    pacman = new Pacman()
    laberinto = new Laberinto()
    fantasma = new Fantasmas()
    cereza = new Cereza()

    //Instanciar Puntitos
    for (let y = 0; y < mapa.length; y++) {
        for (let x = 0; x < mapa[0].length; x++) {
            if (mapa[y][x] == 1) {
                puntito[contadorPuntitos] = new Puntitos(x, y)
                arrayPuntitos.push(puntito[contadorPuntitos])
                contadorPuntitos++
            }
        }
    }

    //Instanciar Puntos
    for (let y = 0; y < mapa.length; y++) {
        for (let x = 0; x < mapa[0].length; x++) {
            if (mapa[y][x] == 5) {
                punto[contadorPuntos] = new Puntos(x, y)
                arrayPuntos.push(punto[contadorPuntos])
                contadorPuntos++
            }
        }
    }

    setInterval(() => {
        iniciarJuego()
    }, 1000 / FPS)

    setInterval(() => {
        updateConteoFPS = contadorFPS
        contadorFPS = 0
    }, 1000)
}

function dibujarCanvas() {
    context.fillStyle = COLORFONDO
    context.fillRect(0, 0, canvas.width, canvas.height)
}

function cargarImagenPuntitos() {
    for (let i = 0; i < arrayPuntitos.length; i++) {
        if (puntito[i].visibilidad) {
            puntito[i].dibujarPuntitos()
        }
        else {
            puntito[i].dibujarFondo()
        }
    }
}

function cargarImagenPuntos() {
    for (let i = 0; i < arrayPuntos.length; i++) {
        if (punto[i].visibilidad) {
            punto[i].dibujarPuntos()
        }
        else {
            punto[i].dibujarFondo()
        }
    }
}

function dibujarFPS() {
    let textoFPS = document.getElementById('fps')

    textoFPS.style.font = '12px calibri'
    textoFPS.style.color = 'white'
    textoFPS.textContent = 'FPS: ' + updateConteoFPS.toString()
}

function dibujarPuntuacion() {
    let textoPuntuacion = document.getElementById('puntuacion')

    textoPuntuacion.style.font = '15px calibri'
    textoPuntuacion.style.color = 'white'
    textoPuntuacion.textContent = 'Puntuación: ' + puntuacion.toString()
}

function dibujarVidas() {
    let textoVidas = document.getElementById('vidas')

    textoVidas.style.font = '15px calibri'
    textoVidas.style.color = 'white'
    textoVidas.textContent = 'Vidas: ' + vidas.toString()
}

//------------------------INICIAR JUEGO------------------------//
function iniciarJuego() {
    dibujarCanvas()

    cargarImagenPuntitos()
    cargarImagenPuntos()
    pacman.dibujarPacman()
    laberinto.dibujarLaberinto()

    dibujarVidas()
    dibujarPuntuacion()
    dibujarFPS()
    contadorFPS++
}