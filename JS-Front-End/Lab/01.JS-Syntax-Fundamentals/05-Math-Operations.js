function operations(firstNum,secondNum,operator){
    switch (operator) {
        case '+':
            console.log(firstNum+secondNum)
            break;
        case '-':
            console.log(firstNum-secondNum)
            break;
        case '*':
            console.log(firstNum*secondNum)
            break;
        case '/':
            console.log(firstNum/secondNum)
            break;
        case '%':
            console.log(firstNum%secondNum)
            break;
        case '**':
            console.log(firstNum**secondNum)
            break;
        default:
            console.log('Error!')
            break;
    }
}

operations(5,6,'+')
operations(3,5.5,'*')
operations(3,3,'**')
