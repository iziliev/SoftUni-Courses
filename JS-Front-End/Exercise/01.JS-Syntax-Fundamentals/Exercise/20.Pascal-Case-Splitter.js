function pascal(text){
    let words = []
    let startIndex = -1
    let lastIndex = -1
    for(let i=0; i<text.length;i++){
        if(text[i].toUpperCase() === text[i] && startIndex < 0){
            startIndex = i
        } else if(text[i].toUpperCase() === text[i] && startIndex >= 0){
            lastIndex = i
        }
        if(startIndex >= 0 && lastIndex >= 0){
            words.push(text.substring(startIndex,lastIndex))
            startIndex = -1
            lastIndex = -1
            i-=1
        }

        if(startIndex>=0 && i == text.length -1){
            words.push(text.substring(startIndex,text.length))
        }
    }

    console.log(words.join(', '))
}

pascal('SplitMeIfYouCanHaHaYouCantOrYouCan')
pascal('HoldTheDoor')
pascal('ThisIsSoAnnoyingToDo')