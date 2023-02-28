function hashtag(text){
    let words = []
    let textsWord = text.split(' ')

    for(let i = 0; i < textsWord.length; i++){
        
        let currentWord = textsWord[i]
        let sliceWord = currentWord.slice(1)
        
        if(currentWord.startsWith('#') && currentWord.length>1 && !isWord(sliceWord.toLowerCase())){
            words.push(sliceWord)
        }
    }

    function isWord(sliceWord){
        
        let hasItNonChar = false
        
        for (const symbol of sliceWord) {
            
            let charCode = symbol.charCodeAt(0)
            
            if(!(charCode >= 97 && charCode <= 122)){
                hasItNonChar = true
                return hasItNonChar
            }
        }
        return hasItNonChar
    }

    words.forEach(element => {
        console.log(element)
    });
}

hashtag('Nowadays everyone uses # to tag a #special word in #socialMedia')
//hashtag('The symbol # is known #variously in English-speaking #regions as the #number sign')
