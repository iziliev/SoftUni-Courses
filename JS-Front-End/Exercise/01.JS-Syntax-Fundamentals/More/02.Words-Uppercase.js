function upper(text){
    let atrayText = text.split(/\W+/).filter(element => element)
    let array=[]
    atrayText.forEach(element => {
        array.push(element.toUpperCase())
    });

    console.log(array.join(', '))
}

upper('Hi, how are you?')