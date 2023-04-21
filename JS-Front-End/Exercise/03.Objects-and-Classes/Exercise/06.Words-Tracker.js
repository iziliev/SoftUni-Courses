function wordsTracker(data){
    let trackWords = data[0].split(' ')
    let text = data.slice(1)

    let words = {}

    for (const trackWord of trackWords) {
        let count = text.filter(x=>x === trackWord).length
        words[trackWord] = count
    }

    let sorted = Object.entries(words)
        .sort((x,y)=>{
            let [_nameA,countA] = x
            let [_nameB,countB] = y
            return countB-countA
        }).forEach(([x,y]) => console.log(`${x} - ${y} `))


    //with class
    // let trackWords = data[0].split(' ')
    // let text = data.slice(1)

    // class Word {
    //     constructor(word,count){
    //         this.word = word
    //         this.count = count
    //     }
    // }

    // let words = []

    // for (const word of trackWords) {
    //     if(!words.find(x=>x.word === word)){
    //         words.push(new Word(word,0))
    //     }
    // }

    // for (const word of text) {
    //     let currentWord = words.find(x=>x.word === word)
    //     if(currentWord!==undefined){
    //         currentWord.count++
    //     }
    // }

    // words
    //     .sort((x,y)=>y.count-x.count)
    //     .forEach(x=>console.log(`${x.word} - ${x.count}`))
}

wordsTracker([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ])