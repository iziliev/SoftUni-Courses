function modification(number){
    let numberStr = String(number)
    let num = 0
    let countLetter = 0

    for (const element of numberStr) {
        num += Number(element)
        countLetter++
    }
    while(num/countLetter <= 5){
        numberStr = numberStr.concat('9')
        num+=9
        countLetter++
    }

    console.log(numberStr)
}

modification(101)
modification(5835)