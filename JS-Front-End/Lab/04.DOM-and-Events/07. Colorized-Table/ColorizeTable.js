function colorize() {
    const trElements = Array.from(document.querySelectorAll('tr'))
    for (let i = 1; i < trElements.length; i++) {
        if(i % 2 !== 0){
            trElements[i].style = 'background-color:teal' 
        }
    }
}