function store(stock,order){

    let products = {}
    for (let i = 0; i < stock.length - 1; i+=2) {
        let[name,quantity ] = [stock[i],Number(stock[i+1])]
        products[name] = quantity
    }

    for (let i = 0; i < order.length -1; i+=2) {
        let [name,quantity] = [order[i],order[i+1]]
        if(products.hasOwnProperty(name)){
            products[name]+=Number(quantity)
        } else {
            products[name]=Number(quantity)
        }
    }

    for (const product in products) {
        console.log(`${product} -> ${products[product]}`)
    }
}

store([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ])