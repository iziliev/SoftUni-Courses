function calc() {
    const numberOne = document.getElementById('num1').value
    const numberTwo = document.getElementById('num2').value
    const sum = document.getElementById('sum')
    
    sum.value = Number(numberOne) + Number(numberTwo)
}
