function area(num){
    if(typeof(num) === 'number'){
        let areaCircle = Math.pow(num,2) * Math.PI
        console.log(areaCircle.toFixed(2))
    } else {
        console.log('We can not calculate the circle area, because we receive a string.')
    }
}

area(5)
area('number')