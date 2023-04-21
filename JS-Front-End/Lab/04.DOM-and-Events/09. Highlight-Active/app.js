function focused() {
    const elements = Array.from(document.getElementsByTagName('input'))
    console.log(elements)
    for (const element of elements) {
        element.addEventListener('focus',onFocus)
        element.addEventListener('blur',nonFocus)
    }

    function onFocus(e){
        e.target.parentNode.classList.add('focused')
    }

    function nonFocus(e){
        e.target.parentNode.classList.remove('focused')
    }
}