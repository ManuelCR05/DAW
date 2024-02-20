const tabla = document.getElementById('tabla')
var texto = document.getElementById('txt').value
const cambiarTexto = document.getElementById('cambiarTxt')
const insertarFila = document.getElementById('insertarFila')
const borrarFila = document.getElementById('borrarFila')

cambiarTexto.addEventListener('click', event => {
    modificarTexto()
})

insertarFila.addEventListener('click', event => {
    añadirFila()
})

borrarFila.addEventListener('click', event => {
    eliminarFila()
})

function modificarTexto() {
    let nuevoTexto = texto
    let indiceFila = parseInt(prompt('¿Qué fila quieres modificar?') - 1)
    let indiceColumna = parseInt(prompt('¿Qué columna quieres modificar?') - 1)

    // let rows = tabla.rows[fila]
    // let cells = rows.cells[columna]

    // cells.inenerText = nuevoTexto

    // console.dir(cells)

    /*let filas = tabla.rows[indiceFila - 1]
    let celdas = filas.cells

    celdas[indiceColumna].textContect = prompt('texto')*/

    debugger
    let filaTR = document.getElementsByTagName('tr')
    let fila = filaTR[indiceFila]

    let columnaTD = document.getElementsByTagName('td')
    let columna = columnaTD[indiceColumna]

    
}

function añadirFila() {
    let fila = document.createElement('tr')
    let columna = document.createElement('td')
    let numColumnas = prompt('Inserta el número de columnas que quieres añadir')
    let txtNode

    for (let i = 1; i <= numColumnas; i++)
    {
        txtNode = document.createTextNode('Columna ' + i)
        columna.appendChild(txtNode)
        columna.innerHTML += '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp' 
        fila.appendChild(columna)
    }

    tabla.appendChild(fila)
}

function eliminarFila() {
    let posicionFila = prompt("Inserta el número de la fila que quieres eliminar") - 1

    tabla.deleteRow(posicionFila)
}