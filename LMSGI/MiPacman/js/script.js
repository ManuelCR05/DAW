// Constantes y Variables Golbales, Objetos y Arrays:
const TILEX = 50
const TILEY = 50
const NUMFILAS = 15
const NUMCOLUMNAS = 19
const RESOLUCION = [TILEX * NUMCOLUMNAS, TILEY * NUMFILAS]
const FPS = 60
const NUMFANTASMAS = 5
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
var blinky
var inky
var pinky
var clyde
var arrayFantasmas = []
var arrayElementos = []
var fantasmasImg = []

// Clases:
class Game {

}

//------------------------LABERINTO------------------------//
class Laberinto {
    constructor(map) {
        this.mapa = map
        this.numColumnas = map[0].length
        this.numFilas = map.length
    }

    getNumFilas() {
        return this.numFilas
    }

    getNumColumnas() {
        return this.numColumnas
    }

    estaEnElTablero(x, y) {
        if (y < 0 || y >= this.numFilas)
            return false

        if (x < 0 || x >= this.numColumnas)
            return false

        return true
    }

    getCellAt(x, y) {
        if (this.estaEnElTablero(x, y))
            return this.mapa[y][x]

        return 9
    }

    comprobarColision(x, y) {
        return this.getCellAt(x, y) == 9
    }

    dibujarLaberinto(ctx) {
        for (let y = 0; y < this.numFilas; y++) {
            for (let x = 0; x < this.numColumnas; x++) {
                if (this.comprobarColision(x, y)) {
                    ctx.drawImage(bloqueImg, 0, 0,
                                  bloqueImg.width, bloqueImg.height,
                                  x * TILEX, y * TILEY,
                                  TILEX, TILEY)
                }
            }
        }
    }
}

//------------------------PERSONAJE------------------------//
class Character {
    constructor(x, y) {
        this.x = x * TILEX
        this.y = y * TILEY
        this.ancho = TILEX
        this.alto = TILEY
        this.movX = 1
        this.movY = 0
        this.sumarAncho = 1
        this.sumarAlto = 0
        this.visibilidad = true

        this.direccion = {
            right:  [1, 0, 1, 0],
            left:   [-1, 0, 0, 0],
            up:     [0, -1, 0, 0],
            down:   [0, 1, 0, 1],
            noMove: [0, 0, 0, 0]
        }
    }
}

//------------------------PACMAN------------------------//
class Pacman extends Character{
    constructor(x, y) {
        super(x, y)
        this.constX = this.x
        this.constY = this.y
        this.teclaPulsada = 'left'
        this.powerUp = false
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
            }
        }

        x = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        y = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        for (let i = 0; i < arrayElementos.length; i++) {
            if (arrayElementos[i].comprobarColision(x, y)) {
                arrayElementos[i].visibilidad = false;
                puntuacion += arrayElementos[i].puntuacionElemento
                if (laberinto.getCellAt(x, y) === 5 && !(this.powerUp)) {
                    this.powerUp = true
                    setTimeout(() => {this.powerUp = false}, 10000)
                }
            }
        }

        if (!(laberinto.comprobarColision(x, y))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }

        for (let i = 0; i < arrayFantasmas.length; i++) {            
            if (arrayFantasmas[i].comprobarColision(this.x, this.y)) {
                if (!(this.powerUp)) {
                    this.visibilidad = false
                    this.teclaPulsada = 'noMove'
                    this.x = this.constX
                    this.y = this.constY
                    setTimeout(() => {this.visibilidad = true}, 3000)
                    vidas--
                }
                else {
                    puntuacion += arrayFantasmas[i].puntuacionFantasma
                    arrayFantasmas[i].visibilidad = false
                    arrayFantasmas[i].nuevaDireccion = 'noMove'
                    arrayFantasmas[i].x = arrayFantasmas[i].constX
                    arrayFantasmas[i].y = arrayFantasmas[i].constY
                    setTimeout(() => {arrayFantasmas[i].visibilidad = true}, 3000)
                }
            }
        }
    }

    dibujarPacman(ctx) {
        if (momentoActual == 1) {this.actualizarPosiciones()}

        if (this.visibilidad) {
            ctx.drawImage(pacmanImg, 0, 0,
                          pacmanImg.width, pacmanImg.height,
                          this.x, this.y,
                          this.ancho, this.alto)
        }
    }

    arriba() {this.teclaPulsada = 'up'}

    abajo() {this.teclaPulsada = 'down'}

    derecha() {this.teclaPulsada = 'right'}

    izquierda() {this.teclaPulsada = 'left'}
}

//------------------------FANTASMAS------------------------//
class Fantasma extends Character {
    constructor(x, y) {
        super(x, y)
        this.constX = this.x
        this.constY = this.y
        this.puntuacionFantasma = 200
        this.orientacion = ['right', 'left', 'up', 'down']
        this.nuevaDireccion
    }

    actualizarPosiciones() {
        let newX
        let newY
        let nuevaDireccion
        let indiceOrientacion

        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            indiceOrientacion = Math.floor(Math.random() * 4)
            nuevaDireccion = this.orientacion[indiceOrientacion]

            newX = parseInt(this.x / TILEX + this.direccion[nuevaDireccion][0])
            newY = parseInt(this.y / TILEY + this.direccion[nuevaDireccion][1])

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0 &&
            (this.movX !== -this.direccion[nuevaDireccion][0] || this.movY !== -this.direccion[nuevaDireccion][1])) {
                this.movX = this.direccion[nuevaDireccion][0]
                this.movY = this.direccion[nuevaDireccion][1]
                this.sumarAncho = this.direccion[nuevaDireccion][2]
                this.sumarAlto = this.direccion[nuevaDireccion][3]
            }
        }
    }

    seAsusta(direccionPacman) {
        let newX
        let newY

        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            newX = parseInt(this.x / TILEX + (-this.direccion[direccionPacman][0]))
            newY = parseInt(this.y / TILEY + (-this.direccion[direccionPacman][1]))

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0) {
                this.movX = -this.direccion[direccionPacman][0]
                this.movY = -this.direccion[direccionPacman][1]
                this.sumarAncho = -this.direccion[direccionPacman][2]
                this.sumarAlto = -this.direccion[direccionPacman][3]
            }
            else {
                this.actualizarPosiciones()
            }
        }
    }

    comprobarColision(x, y) {
        return this.x < x + TILEX / 2 && this.x + TILEX / 2 > x &&
               this.y < y + TILEY / 2 && this.y + TILEY / 2 > y && this.visibilidad
    }

    dibujarFantasma(ctx, indiceFantasma) {
        ctx.drawImage(fantasmasImg[indiceFantasma], 0, 0,
                      fantasmasImg[indiceFantasma].width, fantasmasImg[indiceFantasma].height,
                      this.x, this.y, this.ancho, this.alto)
    }
}

//------------------------BLINKY: Fantasma que ataca activamente a Pacman------------------------//
class Blinky extends Fantasma {
    constructor(x, y) {
        super(x, y)
    }

    atacar(x, y) {
        let diferenciaX = x - this.x
        let diferenciaY = y - this.y
        let newX
        let newY
        let nuevaDireccion
        
        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            if (Math.abs(diferenciaX) > Math.abs(diferenciaY)) {
                nuevaDireccion = diferenciaX > 0 ? 'right' : 'left'
            }
            else {
                nuevaDireccion = diferenciaY > 0 ? 'down' : 'up'
            }

            newX = parseInt(this.x / TILEX + this.direccion[nuevaDireccion][0])
            newY = parseInt(this.y / TILEY + this.direccion[nuevaDireccion][1])

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0 &&
                (this.movX !== -this.direccion[nuevaDireccion][0] || this.movY !== -this.direccion[nuevaDireccion][1])) {
                this.movX = this.direccion[nuevaDireccion][0]
                this.movY = this.direccion[nuevaDireccion][1]
                this.sumarAncho = this.direccion[nuevaDireccion][2]
                this.sumarAlto = this.direccion[nuevaDireccion][3]
            }
            else {
                this.actualizarPosiciones()
            }
        }

        newX = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        newY = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        if (!(laberinto.comprobarColision(newX, newY))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }
    }
}

//------------------------INKY: Fantasma que colabora con Blinky para acorralar a Pacman------------------------//
class Inky extends Fantasma {
    constructor(x, y) {
        super(x, y)
    }

    colaborar(blinkyX, blinkyY, pacmanX, pacmanY) {
        let newX
        let newY
        let nuevaDireccion
        let distancia  = Math.sqrt(Math.pow((pacmanX - blinkyX), 2) + Math.pow((pacmanY - blinkyY), 2))
        let ubiPacmanX  = pacmanX + (2 * distancia)
        let ubiPacmanY  = pacmanY + (2 * distancia)
        let x = ubiPacmanX - this.x
        let y = ubiPacmanY - this.y

        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            nuevaDireccion = x > 0 ? 'right' : 'left'
            nuevaDireccion = y > 0 ? 'down' : 'up'

            newX = parseInt(this.x / TILEX + this.direccion[nuevaDireccion][0])
            newY = parseInt(this.y / TILEY + this.direccion[nuevaDireccion][1])

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0 &&
                (this.movX !== -this.direccion[nuevaDireccion][0] || this.movY !== -this.direccion[nuevaDireccion][1])) {
                this.movX = this.direccion[nuevaDireccion][0]
                this.movY = this.direccion[nuevaDireccion][1]
                this.sumarAncho = this.direccion[nuevaDireccion][2]
                this.sumarAlto = this.direccion[nuevaDireccion][3]
            }
            else {
                this.actualizarPosiciones()
            }
        }

        newX = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        newY = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        if (!(laberinto.comprobarColision(newX, newY))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }
    }
}

//------------------------PINKY: Fantasma que intenta acorralar a Pacaman------------------------//
class Pinky extends Fantasma {
    constructor(x, y) {
        super(x, y)
    }

    modificarPosiciones(direccion) {
        let newX
        let newY
        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            newX = parseInt(this.x / TILEX + this.direccion[direccion][0])
            newY = parseInt(this.y / TILEY + this.direccion[direccion][1])

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0 &&
                (this.movX !== -this.direccion[direccion][0] || this.movY !== -this.direccion[direccion][1])) {
                this.movX = this.direccion[direccion][0]
                this.movY = this.direccion[direccion][1]
                this.sumarAncho = this.direccion[direccion][2]
                this.sumarAlto = this.direccion[direccion][3]
            }
            else {
                this.actualizarPosiciones()
            }
        }

        newX = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        newY = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        if (!(laberinto.comprobarColision(newX, newY))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }
    }

    acorralar(direccionPacman) {
        let siguienteDireccion

        switch (direccionPacman) {
            case 'up':
                siguienteDireccion = 'left'
                break
            case 'down':
                siguienteDireccion = 'right'
                break
            case 'right':
                siguienteDireccion = 'down'
                break
            case 'left':
                siguienteDireccion = 'up'
                break
        }

        this.modificarPosiciones(direccionPacman, () => {
            this.modificarPosiciones(direccionPacman, () => {
                this.modificarPosiciones(siguienteDireccion, () => {})
            })
        })
    }
}

//------------------------CLYDE: Fantasma que sigue a Pacman a no ser que se hacerque a menos de 8 bloques de el------------------------//
class Clyde extends Fantasma {
    constructor(x, y) {
        super(x, y)
    }

    seguir(x, y) {
        let diferenciaX = x - this.x
        let diferenciaY = y - this.y
        let newX
        let newY
        let nuevaDireccion
        
        if (Math.abs(diferenciaX) >= 400 || Math.abs(diferenciaY) >= 400) {
            if (Math.abs(diferenciaX) > Math.abs(diferenciaY)) {
                nuevaDireccion = diferenciaX > 0 ? 'right' : 'left'
            }
            else {
                nuevaDireccion = diferenciaY > 0 ? 'down' : 'up'
            }
        }
        else {
            if (Math.abs(diferenciaX) > Math.abs(diferenciaY)) {
                nuevaDireccion = diferenciaX > 0 ? 'left' : 'right'
            }
            else {
                nuevaDireccion = diferenciaY > 0 ? 'up' : 'down'
            }
        }

        if (this.x % TILEX == 0 && this.y % TILEY == 0 && this.visibilidad) {
            newX = parseInt(this.x / TILEX + this.direccion[nuevaDireccion][0])
            newY = parseInt(this.y / TILEY + this.direccion[nuevaDireccion][1])

            if (!(laberinto.comprobarColision(newX, newY)) && laberinto.getCellAt(newX, newY) !== 0 &&
                (this.movX !== -this.direccion[nuevaDireccion][0] || this.movY !== -this.direccion[nuevaDireccion][1])) {
                this.movX = this.direccion[nuevaDireccion][0]
                this.movY = this.direccion[nuevaDireccion][1]
                this.sumarAncho = this.direccion[nuevaDireccion][2]
                this.sumarAlto = this.direccion[nuevaDireccion][3]
            }
            else {
                this.actualizarPosiciones()
            }
        }

        newX = parseInt((this.x + this.movX + this.ancho * this.sumarAncho) / TILEX)
        newY = parseInt((this.y + this.movY + this.alto * this.sumarAlto) / TILEY)

        if (!(laberinto.comprobarColision(newX, newY))) {
            this.x += this.movX * 2
            this.y += this.movY * 2
        }
    }
}

//------------------------ELEMENTO------------------------//
class Elemento {
    constructor(x, y) {
        this.x = x
        this.y = y
        this.modificadorPos = 0
        this.modificadorTam = 0
        this.visibilidad = true
        this.imagen
        this.puntuacionElemento
    }

    comprobarColision(x, y) {
        return this.x === x && this.y === y && this.visibilidad
    }

    dibujarElemento(ctx) {
        ctx.drawImage(this.imagen, 0, 0,
            this.imagen.width, this.imagen.height,
            this.x * TILEX + this.modificadorPos, this.y * TILEY + this.modificadorPos,
            TILEX - this.modificadorTam, TILEY - this.modificadorTam)
    }
}

//------------------------PUNTO------------------------//
class Punto extends Elemento {
    constructor(x, y) {
        super(x, y)
    }
}

//------------------------CEREZA------------------------//
class Cereza extends Elemento {
    constructor(x, y) {
        super(x, y)
        this.imagen = cerezaImg
        this.puntuacionElemento = 100
    }
}

// Evento:
window.addEventListener('keydown', event => {
    if (pacman.visibilidad) {
        if (event.key == 'w' || event.key == 'W' || event.keyCode == 38) {
            pacmanImg.src = './img/pacman4.png'
            pacman.arriba()
        }
        else if (event.key == 's' || event.key == 'S' || event.keyCode == 40) {
            pacmanImg.src = './img/pacman2.png'
            pacman.abajo()
        }
        else if (event.key == 'a' || event.key == 'A' || event.keyCode == 37) {
            pacmanImg.src = './img/pacman3.png'
            pacman.izquierda()
        }
        else if (event.key == 'd' || event.key == 'D' || event.keyCode == 39) {
            pacmanImg.src = './img/pacman1.png'
            pacman.derecha()
        }
    }
})

function getDefaultMap() {
    return [
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
        [9,1,1,1,1,9,1,1,1,7,1,1,1,9,1,1,1,1,9],
        [9,1,9,9,1,9,1,9,9,9,9,9,1,9,1,9,9,1,9],
        [9,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,9],
        [9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9]
    ]
}

document.getElementById('archivo').addEventListener('change', event => {
    var archivo = event.target.files[0]
    instanciarJuego(archivo)
})

// Funciones:
//------------------------Función principal que instancia el Juego------------------------//
function instanciarJuego(map) {
    canvas = document.getElementById('myCanvas')
    context = canvas.getContext('2d')
    canvas.width = RESOLUCION[0]
    canvas.height = RESOLUCION[1]

    bloqueImg = new Image()
    bloqueImg.src = './img/Bloque.png'

    pacmanImg = new Image()
    pacmanImg.src = './img/pacman1.png'

    puntitoImg = new Image()
    puntitoImg.src = './img/puntito.png'

    puntoImg = new Image()
    puntoImg.src = './img/punto.png'

    cerezaImg = new Image()
    cerezaImg.src = './img/cereza.png'

    for (let i = 1; i <= NUMFANTASMAS; i++) {
        fantasmasImg[i] = new Image()
        fantasmasImg[i].src = './img/Fantasma' + i.toString() + '.png'
    }

    //Instanciar Objetos
    laberinto = new Laberinto(map)

    let contadorFantasmas = 1
    for (let y = 0; y < laberinto.numFilas; y++) {
        for (let x = 0; x < laberinto.numColumnas; x++) {
            if (laberinto.getCellAt(x, y) == 5 || laberinto.getCellAt(x, y) == 1) {
                let punto = new Punto(x, y)
                arrayElementos.push(punto)
                if (laberinto.getCellAt(x, y) == 1) {
                    punto.puntuacionElemento = 5
                    punto.imagen = puntitoImg
                    punto.modificadorPos = 20
                    punto.modificadorTam = 40
                }
                else {
                    punto.puntuacionElemento = 15
                    punto.imagen = puntoImg
                    punto.modificadorPos = 10
                    punto.modificadorTam = 20
                }
            }
            else if (laberinto.getCellAt(x, y) == 4) {
                switch (contadorFantasmas) {
                    case 1:
                        blinky = new Blinky(x, y)
                        arrayFantasmas.push(blinky)
                        contadorFantasmas++
                        break
                    case 2:
                        inky = new Inky(x, y)
                        arrayFantasmas.push(inky)
                        contadorFantasmas++
                        break
                    case 3:
                        pinky = new Pinky(x, y)
                        arrayFantasmas.push(pinky)
                        contadorFantasmas++
                        break
                    case 4:
                        clyde = new Clyde(x, y)
                        arrayFantasmas.push(clyde)
                        break
                }
            }
            else if (laberinto.getCellAt(x, y) == 0) {
                pacman = new Pacman(x, y)
            }
            else if (laberinto.getCellAt(x, y) == 7) {
                let cereza = new Cereza(x, y)
                arrayElementos.push(cereza)
            }
        }
    }

    setInterval(() => {
        dibujarJuego()
    }, 1000 / FPS)

    setInterval(() => {
        updateConteoFPS = contadorFPS
        contadorFPS = 0
    }, 1000)

    if (!(pacman.powerUp)) {
        setInterval(() => {
            blinky.atacar(pacman.x, pacman.y)
        }, 1000 / FPS)
    
        setInterval(() => {
            inky.colaborar(blinky.x, blinky.y, pacman.x, pacman.y)
        }, 1000 / FPS)
    
        setInterval(() => {
            pinky.acorralar(pacman.teclaPulsada)
        }, 1000 / FPS)
    
        setInterval(() => {
            clyde.seguir(pacman.x, pacman.y)
        }, 1000 / FPS)
    }
    else {
        setInterval(() => {
            blinky.seAsusta(pacman.teclaPulsada)
        }, 1000 / FPS)
    
        setInterval(() => {
            inky.seAsusta(pacman.teclaPulsada)
        }, 1000 / FPS)
    
        setInterval(() => {
            pinky.seAsusta(pacman.teclaPulsada)
        }, 1000 / FPS)
    
        setInterval(() => {
            clyde.seAsusta(pacman.teclaPulsada)
        }, 1000 / FPS)
    }
}

//------------------------Funciones de dibujado de los elementos del Juego------------------------//
function dibujarFondo() {
    context.fillStyle = COLORFONDO
    context.fillRect(0, 0, canvas.width, canvas.height)
}

function dibujarElementos() {
    for (let i = 0; i < arrayElementos.length; i++) {
        if (arrayElementos[i].visibilidad == true) {
            arrayElementos[i].dibujarElemento(context)
        }
    }
}

function dibujarFantasmas() {
    if (pacman.powerUp == false) {
        for (let i = 0; i < arrayFantasmas.length; i++) {
            arrayFantasmas[i].dibujarFantasma(context, (i + 1))
        }
    }
    else {
        for (let i = 0; i < arrayFantasmas.length; i++) {
            if (arrayFantasmas[i].visibilidad == true) {
                arrayFantasmas[i].dibujarFantasma(context, 5)
            }
        }
    }
}

//------------------------Funciones de dibujado de datos------------------------//
function dibujarFPS() {
    let textoFPS = document.getElementById('fps')

    textoFPS.style.font = '15px calibri'
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

//------------------------DIBUJAR JUEGO------------------------//
function dibujarJuego() {
    dibujarFondo()
    laberinto.dibujarLaberinto(context)
    dibujarElementos()
    dibujarFantasmas()
    pacman.dibujarPacman(context)

    dibujarVidas()
    dibujarPuntuacion()
    dibujarFPS()
    contadorFPS++
}