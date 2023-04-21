function catalogue(data){
    let products = {}

    for (const line of data) {
        let [name,quantity] = line.split(' : ')
        if(name.charCodeAt(0) >= 65 && name.charCodeAt(0)<=90){
            products[name] = quantity
        }
    }

    let sortedObj = Object.entries(products).sort((productA,productB)=>{
        let [nameA,quantityA] = productA
        let [nameB,quantityB] = productB

        return nameA.localeCompare(nameB)
    })

    let startLetter = 0
    for (const [name,quantity] of sortedObj) {
        let asciiIndex = name.charCodeAt(0)
        if(startLetter!==asciiIndex){
            console.log(name[0])
            startLetter = asciiIndex
        }
        console.log(`  ${name}: ${quantity}`)

    }
    
    // with class
    // class Product{
    //     constructor(name, price){
    //         this.name = name
    //         this.price = price
    //     }
    // }

    // let products = []

    // for (const line of data) {
    //     [name,quantity] = line.split(' : ')
    //     products.push(new Product(name,quantity))
    // }

    // let sorted = products.sort((a,b) => a.name.localeCompare(b.name));
    // let firstLetter = 0
    // for (const product of sorted) {
    //     let asciiIndex = product.name.charCodeAt(0)
    //     if(asciiIndex !== firstLetter){
    //         console.log(String.fromCharCode(asciiIndex))
    //         firstLetter = asciiIndex
    //     }
    //     console.log(`  ${product.name}: ${product.price}`)
    // }
}

catalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ])