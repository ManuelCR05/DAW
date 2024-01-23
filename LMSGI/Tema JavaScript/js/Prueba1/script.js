var edad
var nombre

edad = prompt('Introduce tu edad')
nombre = prompt('Introduce tu nombre').toLowerCase()


if (edad >= 18 && nombre == 'pepe') {
    alert('Eres mayor de edad y eres Pepe')
}
else if (edad >= 18 || nombre == 'pepe') {
    if (edad >= 18) {
        alert('Eres mayor de edad pero no eres Pepe')
    }
    else {
        alert('Eres Pepe pero no eres mayor de edad')
    }
}

// var x = 1

// while (x <= 100) {
//     document.write(x)
//     document.write('<br>')
//     x++
// }

// for (let i = 1; i <= 100; i++) {
//     document.write(i)
//     document.write('<br>')
// }