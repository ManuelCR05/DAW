var tabla = document.getElementById('tabla')
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
    let texto = document.getElementById('txt').value
    let indiceColumna
    let indiceFila
    let celda

    if (texto == '') {
        alert('No hay ningun texto para intercambiar')
    }
    else {
        indiceFila = parseInt(prompt('¿Qué fila quieres modificar?') - 1)
        while (indiceFila < 0 || indiceFila >= tabla.childNodes.length) {
            alert('La fila indicada no exsiste')
            indiceFila = parseInt(prompt('¿Qué fila quieres modificar?') - 1)
        }
    
        indiceColumna = parseInt(prompt('¿Qué columna quieres modificar?') - 1)
        while (indiceColumna < 0 || indiceColumna >= tabla.childNodes[indiceFila].childNodes.length) {
            alert('La columna indicada no exsiste')
            indiceColumna = parseInt(prompt('¿Qué columna quieres modificar?') - 1)
        }
    
        celda = tabla.childNodes[indiceFila].childNodes[indiceColumna]
        celda.innerHTML = texto
    }
}

function añadirFila() {
    let fila = document.createElement('tr')
    let numColumnas = prompt('Inserta el número de columnas que quieres añadir')

    for (let i = 1; i <= numColumnas; i++)
    {
        let columna = document.createElement('td')
        columna.innerHTML += 'Columna ' + i + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp' 
        fila.appendChild(columna)
    }

    tabla.appendChild(fila)
}

function eliminarFila() {
    let posicionFila = prompt("Inserta el número de la fila que quieres eliminar") - 1

    tabla.deleteRow(posicionFila)
}