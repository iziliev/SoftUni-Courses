function palindrome(...numbers){
    String(numbers).split(',').forEach(element => {
        let numStr = element
        let reversedNumStr = numStr.split('').reverse().join('')
        if(Number(numStr)===Number(reversedNumStr)){
            console.log(true)
        }
        else{
            console.log(false)
        }
    });
}

palindrome([123,323,421,121])
palindrome([32,2,232,1010])