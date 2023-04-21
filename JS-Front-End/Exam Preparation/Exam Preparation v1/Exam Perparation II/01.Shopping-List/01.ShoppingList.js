function shoppingList(data){
    
    let products = data.shift().split('!')

    let input = data.shift()
    
    while(input !== 'Go Shopping!'){
        
        let [command,item,newItem] = input.split(' ')
        let index = products.indexOf(item)

        if(command === 'Urgent'){

            if(index === -1){
                products.unshift(item)
            }
        } else if(command === 'Unnecessary'){
            
            if(index > -1){
                products.splice(index,1)
            }

        } else if(command === 'Correct'){

            if(index > -1){
                products[index] = newItem
            }

        } else if(command === 'Rearrange'){

            if(index > -1){
                products.splice(index,1)
                products.push(item)
            }
        }

        input = data.shift()
    }

    console.log(products.join(", "))
}

shoppingList((["Milk!Pepper!Salt!Water!Banana",
"Urgent Cat",
"Unnecessary Grapes",
"Correct Pepper Onion",
"Rearrange Grapes",
"Correct Tomatoes Potatoes",
"Go Shopping!"])


)