function countWord(text,word){
    let words=text.split(' ')
    let count = 0
    words.forEach(currentElement=>{
        if(currentElement === word) {
            count++
        }
    });
    console.log(count)
}

countWord('This is a word and it also is a sentence','is')
countWord('softuni is great place for learning new programming languages','softuni')