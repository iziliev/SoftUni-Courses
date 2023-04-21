function pianist(inputData){
    let n = Number(inputData.shift());

    let album = []

    for (let i = 0; i < n; i++) {
        let dataInput = inputData.shift() 
        album.push(addAlbum(dataInput))
    
    }

    while(inputData[0]!=='Stop'){
        let data = inputData.shift().split('|')

         if(data[0] === 'Add'){
            let composer = data[2]
            let key = data[3]
            let piece = data[1]
            let currentPiece = album.find(x=>x.piece === piece)

            if (currentPiece === undefined) {
                album.push({
                    piece,
                    composer,
                    key
                })
                console.log(`${piece} by ${composer} in ${key} added to the collection!`)
            } else {
                console.log(`${piece} is already in the collection!`)
            }

         } else if(data[0] === 'Remove'){
            let piece = data[1]
            let currentPiece = album.find(x=>x.piece === piece)
        
            if (currentPiece === undefined) {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`)
            } else {
                let index = album.findIndex(x=>x.piece === piece)
                album.splice(index,1)
                console.log(`Successfully removed ${piece}!`)
            }
         } else {
            
            let piece = data[1]
            let key = data[2]
            let currentPiece = album.find(x=>x.piece === piece)
        
            if (currentPiece === undefined) {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`)
            } else {
            currentPiece.key = key
            console.log(`Changed the key of ${piece} to ${key}!`)
            }
         }
    }

    print(album)

    function addAlbum(dataInput){
        let pieces = {}
        let dataPiece = dataInput.split('|')
        let piece = dataPiece[0]
        let composer = dataPiece[1]
        let key = dataPiece[2]

        pieces = {
            piece,
            composer,
            key
        }
        return pieces
    }

    function print(album){
        
        for (const piece of album) {
            console.log(`${piece.piece} -> Composer: ${piece.composer}, Key: ${piece.key}`);
        }
    }
}

pianist([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'  
  ]
    
)