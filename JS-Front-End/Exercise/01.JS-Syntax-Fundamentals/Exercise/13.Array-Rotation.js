function rotation(array,times){

    for(let i=0; i<times; i++){
        var num = array.shift()
        array.push(num)
    }

    console.log(array.join(" "))
}

rotation([51, 47, 32, 61, 21], 2)
rotation([32, 21, 61, 1], 4)
rotation([2, 4, 15, 31], 5)