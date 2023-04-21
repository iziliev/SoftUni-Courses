function shoppingList(data) {
    let products = data.shift().split('!');

    const commandParser = {
        'Urgent': urgentProduct,
        'Unnecessary':unnecessaryProduct,
        'Correct':correctProduct,
        'Rearrange': rearrangeProduct
    }

    for (const commandInfo of data) {
        if(commandInfo === 'Go Shopping!'){
            break
        }

        let commandToken = commandInfo.split(' ');
        let command = commandToken[0]
        commandParser[command](...commandInfo.split(' ').slice(1))
    }

    console.log(products.join(', '))

    function urgentProduct(product){
        if(!products.includes(product)){
            products.unshift(product)
        }
    }

    function unnecessaryProduct(product){
        if(products.includes(product)){
            let index = products.indexOf(product)
            products.splice(index,1)
        }
    }

    function correctProduct(oldProduct,newProduct){
        if(products.includes(oldProduct)){
            let index = products.indexOf(oldProduct)
            products[index] = newProduct
        }
    }

    function rearrangeProduct(product){
        if(products.includes(product)){
            let index = products.indexOf(product)
            let tempItem = products[index]
            products.splice(index,1)
            products.push(tempItem)
        }
    }
    
}

shoppingList(
    (["Milk!Pepper!Salt!Water!Banana",
"Urgent Salt",
"Unnecessary Grapes",
"Correct Pepper Onion",
"Rearrange Grapes",
"Correct Tomatoes Potatoes",
"Go Shopping!"])
)