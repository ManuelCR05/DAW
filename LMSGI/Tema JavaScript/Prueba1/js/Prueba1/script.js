// var edad
// var nombre

// edad = prompt('Introduce tu edad')
// nombre = prompt('Introduce tu nombre').toLowerCase()


// if (edad >= 18 && nombre == 'pepe') {
//     alert('Eres mayor de edad y eres Pepe')
// }
// else if (edad >= 18 || nombre == 'pepe') {
//     if (edad >= 18) {
//         alert('Eres mayor de edad pero no eres Pepe')
//     }
//     else {
//         alert('Eres Pepe pero no eres mayor de edad')
//     }
// }

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


// do {
//     num = prompt('Introduce un número')
// } while (num != 0)


//Ej1: Imprimir los números pares

//var num = prompt('hasta que número quieres mostrar ?')

// for (let i = 1; i <= num; i++) {
//     if (i % 2 === 0) {
//         document.write(i)
//         document.write('<br>')
//     }
// }

// for (let i = 0; i <= num; i += 2) {
//     document.write(i)
//     document.write('<br>')
// }


//Ej2: Sumar números del 1 al 100

// var num = 0

// for (let i = 1; i <= 100; i++) {
//     num += i
// }

// document.write(num)


//Ej3: adivinar un número, tienes 3 intentos, si no lo aciertas avisas de cual era el número aleatorio
//debugger --> Para hacer debug
// const numRandom = Math.floor(Math.random() * 10 + 1)
// var i = 0
// var encontrado = false
// var intentos = 3

// do {
//     num = prompt('Introduce un número')

//     if (num == numRandom) {
//         alert('Encontraste el número')
//         encontrado = true
//     }
//     else {
//         intentos--
        
//         if (intentos != 0) {
//             alert('Te quedan ' + intentos + ' intentos')
//         }
//         else {
//             alert('No te quedan intentos, el número random era: ' + numRandom)
//         }
//     }
// } while (intentos != 0 && !encontrado)

// persona = new Array()
// persona[0] = 1
// persona[1] = 2
// persona[2] = 3
// res = ''

// for (let num in persona) {
//     res += num + ' '
// }

// console.log(res)


//Crea una función que devuelva el ultimo elemento de un vector

var vector = [1, 2, 3, 4]

function sacarUltimoElementoVector(v) {
    return v[v.length - 1]
}

alert(sacarUltimoElementoVector(vector))


//Crea una función que devuelva el primer elemento de un vector

function sacarPrimerElementoVector(v) {
    return v[0]
}

alert(sacarPrimerElementoVector(vector))


//Sumar todos los elementos de un vector

function sumarVector(v) {
    var suma = 0

    for (let i = 0; i < v.length; i++) {
        suma += v[i]
    }

    return suma
}

alert(sumarVector(vector))