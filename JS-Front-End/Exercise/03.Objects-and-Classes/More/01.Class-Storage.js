function storage(){
    class Storage{
        constructor(capacity){
            this.capacity = capacity
            this.products = [{}]
            this.totalCost = 0
        }

        addProduct(product){
            this.capacity-=product.quantity
            this.totalCost += (product.quantity * product.price)
            this.products.push(product)
        }

        getProducts(){
            let output =[]
            
            for (const product of this.products) {
                output.push(JSON.stringify(product));
            }
            return output.join('\n')
        }; 

    }

    let productOne = {name: 'Cucamber', price: 1.50, quantity: 15};
    let productTwo = {name: 'Tomato', price: 0.90, quantity: 25};
    let productThree = {name: 'Bread', price: 1.10, quantity: 8};
    let storage = new Storage(50);
    storage.addProduct(productOne);
    storage.addProduct(productTwo);
    storage.addProduct(productThree);
    console.log(storage.getProducts());
    console.log(storage.capacity);
    console.log(storage.totalCost);
}

storage()