function largeNum(firstNum,secondNum,thirdNum){
    let num = ''
    if(firstNum > secondNum){
        if(firstNum > thirdNum){
            num=firstNum
        } else {
            num = thirdNum
        }
    } else if(secondNum > thirdNum){
        num=secondNum
    } else {
        num=thirdNum
    }

    console.log(`The largest number is ${num}.`)
}

largeNum(5, -3, 16)
largeNum(-3, -5, -22.5)