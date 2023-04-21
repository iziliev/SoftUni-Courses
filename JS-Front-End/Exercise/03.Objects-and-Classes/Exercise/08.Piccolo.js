function piccolo(data){

    let parking = []

    for (const info of data) {
        let [command,carNumber] = info.split(', ')
        let currentCar = parking.findIndex(x=>x === carNumber)
        if(command === 'IN' && currentCar < 0){
            parking.push(carNumber)
        } else if(command === 'OUT' && currentCar > -1) {
            let outIndex = parking.findIndex(x=>x === carNumber)
            parking.splice(outIndex,1)
        }
    }

    parking.length===0 ? console.log(`Parking Lot is Empty`):parking.sort().forEach(x => console.log(x))
}

piccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
)