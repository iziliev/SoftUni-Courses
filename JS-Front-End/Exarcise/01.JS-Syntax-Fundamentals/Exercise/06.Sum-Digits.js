function sum(number){
    let array = String(number).split("")
    let sum = 0
    for(let i = 0; i < array.length; i++){
        sum += parseInt(array[i])
    }
    console.log(sum)
}

sum(245678)
sum(97561)
sum(543)