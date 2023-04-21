function subtract() {
    const first = document.getElementById('firstNumber')
    const second = document.getElementById('secondNumber')
    const result = document.getElementById('result')

    result.textContent = Number(first.value) - Number(second.value)
}