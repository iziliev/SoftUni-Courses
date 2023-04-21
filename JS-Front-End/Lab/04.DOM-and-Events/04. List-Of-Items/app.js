function addItem() {
    const inputText = document.getElementById('newItemText')
    const createLi = document.createElement('li')
    const ul = document.getElementById('items')
    createLi.textContent=inputText.value

    ul.appendChild(createLi)
    inputText.value = ''
}