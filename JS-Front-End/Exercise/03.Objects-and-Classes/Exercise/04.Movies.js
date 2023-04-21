function movie(data){
    
    //with object

    let movies = []

    for (const line of data) {
        if(line.includes('addMovie')){
            let infoMovie = line.split('addMovie ')
            let name = infoMovie[1]
            addMovie(name)
        }else if(line.includes('directedBy')){
            let infoDirector = line.split(' directedBy ')
            let name = infoDirector[0]
            let director = infoDirector[1]
            directedBy(name,director)
        }else if(line.includes('onDate')){
            let infoDate = line.split(' onDate ')
            let name = infoDate[0]
            let date = infoDate[1]
            onDate(name,date)
        }
    }

    for (const movie of movies) {
        if(movie.hasOwnProperty('name') && movie.hasOwnProperty('date') && movie.hasOwnProperty('director')){
            console.log(JSON.stringify(movie))
        }
    }


    function addMovie(name){
        movies.push({name})
    }

    function directedBy(name,director){
        let currentMovie = movies.find(x=>x.name === name)
        if(currentMovie){
            currentMovie.director = director
        }
    }

    function onDate(name,date){
        let currentMovie = movies.find(x=>x.name === name)
        if(currentMovie){
            currentMovie.date = date
        }
    }
    
    //with class
    // class Movie{
    //     constructor(name,director,date){
    //         this.name = name
    //         this.director = director
    //         this.date = date
    //     }
    // }

    // let movies = []
    
    // for (const line of data) {
    //     if (line.includes('addMovie')) {
    //         let name = line.split(' ').slice(1).join(' ')
    //         movies.push(new Movie(name,null,null))
    //     } else if (line.includes('directedBy')){
    //         let info = line.split(' ')
    //         let index = info.findIndex(x=>x==='directedBy')
    //         let name = info.slice(0,index).join(' ')
    //         let directorName = info.slice(2).join(' ')
    //         let currentMovie = movies.find(x=>x.name === name)
    //         if(currentMovie !== undefined){
    //             currentMovie.director = directorName
    //         }
    //     } else if (line.includes('onDate')) {
    //         let info = line.split(' ')
    //         let index = info.findIndex(x=>x==='onDate')
    //         let name = info.slice(0,index).join(' ')
    //         let date = info.slice(index+1,line.length)
    //         let currentMovie = movies.find(x=>x.name === name)

    //         if(currentMovie !== undefined){
    //             currentMovie.date = date[0]
    //         }
    //     }
    // }
    
    // movies.forEach(m => m.director !== null && m.name !==null && m.date !== null ? console.log(JSON.stringify(m)) : null )

}

movie([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
])