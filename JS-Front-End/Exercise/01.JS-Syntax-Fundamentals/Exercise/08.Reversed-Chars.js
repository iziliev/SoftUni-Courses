function reversChar(charOne,charTwo,charThree) {
    let str = charOne+charTwo+charThree
    let arr = str.split('')
    let newArr = arr.reverse()
    console.log(newArr.join(' '))
}

reversChar('A','B','C')
reversChar('1','L','&')