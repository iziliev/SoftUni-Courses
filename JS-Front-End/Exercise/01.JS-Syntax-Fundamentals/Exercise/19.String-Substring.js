function stringSub(word,text){
    let compareWord= word.toLowerCase()
    text = text.toLowerCase().split(' ')
    let isContain=false
    
    for (const element of text) {
        if(element === compareWord){
            isContain = true
            break
        }
    }

    if (isContain) {
        console.log(word)
    } else {
        console.log(`${word} not found!`)
    }
}

stringSub('javascript', 'JavaScript is the best programming language')
stringSub('python', 'JavaScript is the best programming language')