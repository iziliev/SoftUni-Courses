function pyramid(...base){
    let size = base[0]
    let increment = base[1]

    let step = 0

    let stones = 0
    let marble = 0
    let lapis = 0
    let gold = 0

    
    while (size - 2 > 0) {
        step++
        let sizeSquare = size**2
        stones += ((size-=2)**2)*increment

        if(step % 5 !== 0){
            marble += (sizeSquare-(size**2))*increment
        } else {
            lapis += (sizeSquare-(size**2))*increment
        }
    }

    step++

    if(base[0] % 2 == 0){
        gold=4*increment
    }else{
        gold=1*increment
    }

    console.log(`Stone required: ${Math.ceil(stones)}`)
    console.log(`Marble required: ${Math.ceil(marble)}`)
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`)
    console.log(`Gold required: ${Math.ceil(gold)}`)
    console.log(`Final pyramid height: ${Math.floor(step*increment)}`)
}

pyramid(11, 1)
pyramid(11, 0.75)
pyramid(12, 1)
pyramid(23, 0.5)