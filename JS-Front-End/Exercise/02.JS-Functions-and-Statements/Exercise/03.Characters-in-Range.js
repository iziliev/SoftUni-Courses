function characters(charOne, charTwo){
    let charsArray=[]
    let startChar = Math.min(charOne.charCodeAt(0),charTwo.charCodeAt(0))
    let lastChar = Math.max(charOne.charCodeAt(0),charTwo.charCodeAt(0))

    for (let i = startChar + 1; i < lastChar; i++) {
        charsArray.push(String.fromCharCode(i))
    }

    console.log(charsArray.join(' '))
}

characters('a','d')
characters('#',':')
characters('C','#')