function addItem() {
    const ul = document.getElementById('items')
    const text = document.getElementById('newItemText')
    let li = document.createElement('li')
    let a = document.createElement('a')
    a.textContent = '[Delete]'
    a.href = '#'
    li.textContent = text.value
    text.value = ''
    li.appendChild(a)
    ul.appendChild(li)

    a.addEventListener('click',deleteElement)

    function deleteElement(e){
        e.currentTarget.parentNode.remove()
    }
}