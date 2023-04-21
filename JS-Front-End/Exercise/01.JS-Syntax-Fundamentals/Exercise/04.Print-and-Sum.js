function sum(firstNum,secondNum){
    var array = []
    var index = 0
    var sum=0
    for (let i = firstNum; i <= secondNum; i++) {
        array[index] = i;
        sum+=i
        index++
    }

    console.log(array.join(' '))
    console.log(`Sum: ${sum}`)
}

sum(5,10)
sum(0,26)
sum(50,60)