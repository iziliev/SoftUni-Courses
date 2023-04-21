function radio(...numbers){
    let numbersArray = numbers[0]
    let thicknessArray = numbersArray.slice(1)
    let target = numbersArray[0]
    
    for (let i = 0; i < thicknessArray.length; i++) {
        let currentThickness = thicknessArray[i]

        console.log(`Processing chunk ${thicknessArray[i]} microns`)

        let arrayResult =[0,0,0,0,0]

        while(target !== currentThickness){
            while (currentThickness / 4 >= target){
                currentThickness /= 4
                arrayResult[0]++
            }

            if(arrayResult[0]>0){
                console.log(`Cut x${arrayResult[0]}`)
                console.log(`Transporting and washing`)
                currentThickness = Math.floor(currentThickness)
            }

            while (currentThickness * 0.8 >= target){
                currentThickness*=0.8
                arrayResult[1]++
            } 
            
            if(arrayResult[1]>0){
                console.log(`Lap x${arrayResult[1]}`)
                console.log(`Transporting and washing`)
                currentThickness = Math.floor(currentThickness)
            }

            while (currentThickness - 20 >= target){
                currentThickness -= 20
                arrayResult[2]++
            } 
            if(arrayResult[2]>0){
                console.log(`Grind x${arrayResult[2]}`)
                console.log(`Transporting and washing`)
            }

            while (currentThickness - 2 >= target-1){
                currentThickness-=2
                arrayResult[3]++
            } 
            if(arrayResult[3]>0){
                console.log(`Etch x${arrayResult[3]}`)
                console.log(`Transporting and washing`)
            }
            if(currentThickness < target){
                currentThickness++
                arrayResult[4]++
                console.log(`X-ray x${arrayResult[4]}`)
            }

        }
        console.log(`Finished crystal ${target} microns`)
    }
}

//radio([1375, 50000])
radio([1000, 4000, 8100])

