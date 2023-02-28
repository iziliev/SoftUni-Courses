function checker(x1,y1,x2,y2){
    
    let numOne = Math.sqrt(Math.pow(0-x1,2)+Math.pow(0-y1,2))
    let numTwo = Math.sqrt(Math.pow(x2-0,2)+Math.pow(y2-0,2))
    let numThree = Math.sqrt(Math.pow(x2-x1,2)+Math.pow(y2-y1,2))

    if(Number.isInteger(numOne)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`) //x2=0 y2=0
    }
    else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`)
    }

    if (Number.isInteger(numTwo)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`) //x1=0 y1=0
    }
    else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }

    if (Number.isInteger(numThree)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    }
    else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }
}

checker(3, 0, 0, 4)
checker(2, 1, 1, 1)

