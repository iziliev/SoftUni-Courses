function addItem() {
    const select = document.getElementById('menu')
    const createOption = document.createElement('option')
    const inputText = document.getElementById('newItemText')
    const inputValue = document.getElementById('newItemValue')

    createOption.textContent = inputText.value
    createOption.value = inputValue.value
    inputText.value=''
    inputValue.value=''
    select.appendChild(createOption)
}