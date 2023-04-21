function calculator(numOne,numTwo,operator){
    switch(operator){
        case 'multiply':
            console.log(numOne*numTwo)
            break
        case 'divide':
            console.log(numOne/numTwo)
            break
        case 'add':
            console.log(numOne+numTwo)
            break
        case 'subtract':
            console.log(numOne-numTwo)
            break
    }
}

calculator(5,5,'multiply')
calculator(40, 8,'divide')
calculator(12,19,'add')
calculator(50, 13,'subtract')
