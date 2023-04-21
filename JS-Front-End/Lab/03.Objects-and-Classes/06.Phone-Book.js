function phoneBook(data){
    let book={}
    for (const line of data) {
        let [ name,phone ] = line.split(' ')
        book[name]=phone
    }

    for (const key in book) {
        console.log(`${key} -> ${book[key]}`)
    }
}

phoneBook(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
)