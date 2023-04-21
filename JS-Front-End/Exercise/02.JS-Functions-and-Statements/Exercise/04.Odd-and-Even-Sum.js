function oddEven(number){
    let oddSum = 0
    let evenSum = 0
    
    let numberString = String(number)
    
    for (const element of numberString) {
        let currentNumber = Number(element)
        if(currentNumber%2!==0){
            oddSum+=currentNumber
        } else{
            evenSum+=currentNumber
        } 
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`)
}

oddEven(1000435)
oddEven(3495892137259234)