function carWash(...strings) {
    
    let value = 0
    for (let i = 0; i < strings[0].length; i++) {
        let current = strings[0][i]
        switch (current) {
            case 'soap':
                value+=10
                break;
            case 'water':
                value *= 1.2
                break;
            case 'vacuum cleaner':
                value *= 1.25
                break;
            case 'mud':
                value *= 0.90
                break;
        }
    }
    console.log(`The car is ${value.toFixed(2)}% clean.`)
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water'])
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"])