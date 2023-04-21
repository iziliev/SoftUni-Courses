function oddOccurrences(data){
    let words = {}
    let text = data.split(' ')
    for (const word of text) {
        let currentWord = word.toLowerCase()
        if(!words.hasOwnProperty(currentWord)){
            words[currentWord] = 1
        } else {
            words[currentWord]+=1
        }
    }

    let filteredWord = Object.entries(words)
    .filter(([word,count]) => count % 2 !== 0)
    .map(x=>x[0])
    

    console.log(filteredWord.join(' '))


//with class    
//     class Word{
//         constructor(word,count){
//             this.word = word
//             this.count = count
//         }
//     }

//     let words = []

//     let info = data.split(' ')

//     for (const word of info) {
//         let currentWord = words.find(x=>x.word === word.toLowerCase())
        
//         if(currentWord !== undefined){
//             currentWord.count++
//         } else{
//             words.push(new Word(word.toLowerCase(),1))
//         }
//     }

//     let filteredWord = []

//     for (const word of words.filter(x=>x.count%2!==0)) {
//         filteredWord.push(word.word)
//     }

//     console.log(filteredWord.join(' '))
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')