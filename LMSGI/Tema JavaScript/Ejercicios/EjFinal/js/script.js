var tabla = document.getElementById('tabla')
var cambiarTexto = document.getElementById('cambiarTxt')
var insertarFila = document.getElementById('insertarFila')
var borrarFila = document.getElementById('borrarFila')

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
    let posicionFila = prompt("Inserta el número de la fila que quieres eliminar")

    tabla.removeChild()
}