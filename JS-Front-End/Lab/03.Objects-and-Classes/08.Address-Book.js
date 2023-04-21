function addressBook(data){
    let book={}

    for (const line of data) {
        let [ name,address] = line.split(':')
        book[name] = address
    }

    let sorted = Object.keys(book).sort((a,b)=>a.localeCompare(b))

    for (const name of sorted) {
        console.log(`${name} -> ${book[name]}`)
    }
}

addressBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
)