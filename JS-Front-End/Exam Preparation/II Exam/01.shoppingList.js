function shoppingList(data){
    let products = data.shift().split('!')

    let commandParser = {
        Urgent:urgentItem,
        Unnecessary:unnecessaryItem,
        Correct:correctItem,
        Rearrange:rearrangeItem
    }

    while(data[0] !== 'Go Shopping!'){

        let commandInfo = data.shift().split(' ')
        let command = commandInfo[0]
        commandParser[command](...commandInfo.slice(1))
    }

    console.log(products.join(', '))

    function urgentItem(item){
        if(!products.includes(item)){
            products.unshift(item)
        }
    }

    function unnecessaryItem(item){
        let index = products.findIndex(x=>x === item)

        if(index!=-1){
            products.splice(index,1)
        }
    }

    function correctItem(oldItem,newItem){
        let index = products.findIndex(x=>x === oldItem)

        if(index!=-1){
            products[index] = newItem
        }
    }

    function rearrangeItem(item){
        let index = products.findIndex(x=>x === item)

        if(index!=-1){
            let currentItem = products[index]
            products.splice(index,1)
            products.push(currentItem)
        }
    }


}

shoppingList((["Milk!Pepper!Salt!Water!Banana",
"Urgent Salt",
"Unnecessary Grapes",
"Correct Pepper Onion",
"Rearrange Grapes",
"Correct Tomatoes Potatoes",
"Go Shopping!"])
)