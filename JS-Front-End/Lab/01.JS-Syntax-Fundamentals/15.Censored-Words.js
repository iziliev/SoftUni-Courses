function censore(text,word){
    while(text.includes(word)){
        text = text.replace(word,'*'.repeat(word.length))
    }

    console.log(text)
}

censore('A small sentence with some words', 'small')
censore('Find the hidden word', 'hidden')