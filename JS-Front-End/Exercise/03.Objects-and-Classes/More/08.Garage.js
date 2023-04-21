function garage(data){
    class Garage {
        constructor(name){
            this.name = name
            this.cars = []
        }
    }
    
    let garages = []

    for (const line of data) {
        [name,car] = line.split(' - ')
        let currentGarage = garages.find(x=>x.name === name)
        if(currentGarage !== undefined){
            currentGarage.cars.push(car)
        } else{
            garages.push(new Garage(name))
            currentGarage = garages.find(x=>x.name === name)
            currentGarage.cars.push(car)
        }
    }

    for (const garage of garages) {
        console.log(`Garage № ${garage.name}`)
        for (const car of garage.cars) {
            let carStr = car
            while(carStr.includes(': ')){
                carStr = carStr.replace(': ',' - ')
            }

            console.log(`--- ${carStr}`)
        }
    }
}

garage(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi', '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'])