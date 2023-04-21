function pianist(data){
    let n = data.shift()
    
    let pieces = {}

    let commandParser = {
        'Add':addPiece,
        'Remove':removePiece,
        'ChangeKey':changeKeyPiece
    }

    for (let i = 0; i < n; i++) {
        let [piece,composer,key] = data.shift().split('|');
        pieces[piece] = { composer, key }
    }

    for (const commandInfo of data) {
        if(commandInfo === 'Stop'){
            break
        }
        let commandTokens = commandInfo.split('|')
        let command = commandTokens[0]
        commandParser[command](...commandTokens.slice(1))
    }

    for (const key in pieces) {
        console.log(`${key} -> Composer: ${pieces[key].composer}, Key: ${pieces[key].key}`)
    }

    function addPiece(piece,composer,key){
        if (!pieces.hasOwnProperty(piece)) {
            piece[piece] = { composer, key }
            console.log(`${piece} by ${composer} in ${key} added to the collection!`)
        } else {
            console.log(`${piece} is already in the collection!`)
        }
    }

    function removePiece(piece,newKey){
        if (!pieces.hasOwnProperty(piece)) {
            piece[piece].key = newKey
            console.log(`Changed the key of ${piece} to ${newKey}!`)
        } else {
            console.log(`$Invalid operation! ${piece} does not exist in the collection.`)
        }
    }

    function changeKeyPiece(piece){
        if (!pieces.hasOwnProperty(piece)) {
            delete piece[piece]
            console.log(`Successfully removed ${piece}!`)
        } else {
            console.log(`$Invalid operation! ${piece} does not exist in the collection.`)
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