function shelf(data){
    class Shelf{
        constructor(id,genre){
            this.id = id
            this.genre = genre
            this.books =[]
        }
    }

    class Book{
        constructor(title,author){
            this.title = title
            this.author = author 
        }
    }

    let shelves = []

    for (const line of data) {
        if(line.includes('->')){
            let info = line.split(' -> ')
            let id = Number(info[0])
            let existShelf = shelves.find(x=>x.id === id)
            if(existShelf === undefined){
                shelves.push(new Shelf(id,info.splice(1,line.length).join(' ')))
            } 
        } else{
            let info = line.split(': ')
            let bookInfo = info[1].split(', ')

            let title = info[0]
            let author = bookInfo[0]
            let genre = bookInfo[1]

            let currentShelve = shelves.find(x=>x.genre === genre)

            if(currentShelve !== undefined){
                currentShelve.books.push(new Book(title,author))
            }
        }
    }

    shelves
    .sort((x,y)=>y.books.length - x.books.length)
    .forEach(x=>x.books.sort(x=>x.title).reverse)
    
    for (const shelf of shelves) {
        console.log(`${shelf.id} ${shelf.genre}: ${shelf.books.length}`)
        for (const book of shelf.books) {
            console.log(`--> ${book.title}: ${book.author}`)
        }
    }

}

shelf(['1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action', 'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history', '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history'])