function pianist(data){
    let n = data.shift()

    let commandParser = {
        Add:addPiece,
        Remove:removePiece,
        ChangeKey:changeKeyPiece
    }

    let pieces = []

    for (let i = 0; i < n; i++) {
        let [piece,composer,key] = data.shift().split('|')
        pieces.push({piece,composer,key})
    }

    while(data[0] !== 'Stop'){
        let commandInfo = data.shift().split('|')
        let command = commandInfo[0]
        commandParser[command](...commandInfo.slice(1))
    }

    for (const piece of pieces) {
        console.log(`${piece.piece} -> Composer: ${piece.composer}, Key: ${piece.key}`)
    }

    function addPiece(piece,composer,key){
        let index = pieces.findIndex(x=>x.piece === piece)
        if(index === -1){
            pieces.push({piece,composer,key})
            console.log(`${piece} by ${composer} in ${key} added to the collection!`)
        } else {
            console.log(`${piece} is already in the collection!`)
        }
    }

    function removePiece(piece){
        let index = pieces.findIndex(x=>x.piece === piece)
        if(index !== -1){
            pieces.splice(index,1)
            console.log(`Successfully removed ${piece}!`)
            
        } else {
            console.log(`Invalid operation! ${piece} does not exist in the collection.`)
        }
    }

    function changeKeyPiece(piece,newKey){
        let index = pieces.findIndex(x=>x.piece === piece)
        if(index != -1){
            pieces[index].key = newKey
            console.log(`Changed the key of ${piece} to ${newKey}!`)
        } else {
            console.log(`Invalid operation! ${piece} does not exist in the collection.`)
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