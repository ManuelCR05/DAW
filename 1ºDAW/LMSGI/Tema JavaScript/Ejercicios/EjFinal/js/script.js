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
        if (tabla.childNodes.length == 0) {
            alert('No hay ninguna fila ni columna a las que modificarles el texto')
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
}

function añadirFila() {
    let fila = document.createElement('tr')
    let numColumnas = prompt('Inserta el número de columnas que quieres añadir')
    while (numColumnas <= 0) {
        alert('Cantidad de columnas indicadas no valida')
        numColumnas = prompt('Inserta el número de columnas que quieres añadir')
    }

    for (let i = 1; i <= numColumnas; i++)
    {
        let columna = document.createElement('td')
        columna.innerHTML += 'Columna ' + i + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp' 
        fila.appendChild(columna)
    }

    tabla.appendChild(fila)
}

function eliminarFila() {
    let posicionFila

    if (tabla.childNodes.length == 0) {
        alert('No hay ninguna fila creada')
    }
    else {
        posicionFila = prompt("Inserta el número de la fila que quieres eliminar")
        while (posicionFila <= 0 || posicionFila > tabla.childNodes.length) {
            alert('La fila indicada no existe')
            posicionFila = prompt("Inserta el número de la fila que quieres eliminar")
        }

        tabla.deleteRow(posicionFila - 1)
    }
}