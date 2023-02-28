function reveal(words,text){
    let arr = words.split(', ')
    let texts = text.split(' ')
    for(let i = 0;i < arr.length; i++){
        for (let y = 0; y < texts.length; y++) {
            if(texts[y] === '*'.repeat(arr[i].length)){
                texts[y] = arr[i]
            }
        }
    }
    console.log(texts.join(' '))
}

reveal('great', 'softuni is ***** place for learning new programming languages')
reveal('great, learning', 'softuni is ***** place for ******** new programming languages')
