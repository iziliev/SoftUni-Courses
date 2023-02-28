function sorted(...array){
    array = array[0]
    .sort((a,b)=>a-b)

    let sortedArr = []

    while(array.length > 1){
        let firstNum = array.shift()
        let lastNum = array.pop()
        
        sortedArr.push(firstNum)
        sortedArr.push(lastNum)
    }

    sortedArr.push(array.shift())
    return sortedArr
}

sorted([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])
