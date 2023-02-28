function solve(numbers) {
    var str = String(numbers).split('')
    var isSame = true
    var sum = 0

    for(let i = 0; i < str.length; i++){
        if(isSame === true && i + 1 < str.length && str[i] !== str[i+1]){
            isSame = false
        }
        sum += parseInt(str[i])
    }

    console.log(isSame)
    console.log(sum)
}

solve(2222222)
solve(1234)