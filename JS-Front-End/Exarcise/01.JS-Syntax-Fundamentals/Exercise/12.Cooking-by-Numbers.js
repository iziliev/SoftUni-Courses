function cook(num,operOne,operTwo,operThree,operFour,operFive) {
    let number = parseInt(num)
    let operations = [operOne,operTwo,operThree,operFour,operFive]

    for (let i = 0; i < operations.length; i++) {
        if(operations[i]==='chop'){
            console.log(number/=2)
        } else if(operations[i]==='dice'){
            number = Math.sqrt(number)
            console.log(number)
        } else if(operations[i]==='spice'){
            console.log(number+=1)
        } else if(operations[i]==='bake'){
            console.log(number*=3)
        }else if(operations[i]==='fillet'){
            console.log((number*=0.8).toFixed(1))
        }
    }
}


cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet')