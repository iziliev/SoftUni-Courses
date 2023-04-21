function editElement(element,textToReplace,replacer) {
    while(element.textContent.includes(textToReplace)){
        element.textContent = element.textContent.replace(textToReplace,replacer)
    }  
}