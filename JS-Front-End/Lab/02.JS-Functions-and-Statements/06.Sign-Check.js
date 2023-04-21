function signCheck(...numbers){
    let negativeCount = 0
    for (let i = 0; i < numbers.length; i++) {
        if(numbers[i] < 0){
            negativeCount++
        }
    }

    if(negativeCount > 0 && negativeCount%2 !==0){
        console.log(`Negative`)
    } else {
        console.log(`Positive`)
    }
}

signCheck(5,12,-15)
signCheck(-6,-12,14)
signCheck(-1,-2,-3)
signCheck(-5,1,1)