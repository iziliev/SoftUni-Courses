function dna(len) {
    let sequence = 'ATCGTTAGGG'.split('')
    let row = 0
    let symbolCount = 2
    let lettersCount = 0

    for (let i = 0; i < len; i++) {
        if(row>4){
            row=1
        }
        if(lettersCount === 10){
            lettersCount=0
        }
        if(row === 0){
            console.log('*'.repeat(symbolCount-row).concat(sequence[lettersCount],sequence[lettersCount+1],'*'.repeat(symbolCount-row)))
        } else if(row===1){
            console.log('*'.repeat(symbolCount-row).concat(sequence[lettersCount],'-'.repeat(symbolCount),sequence[lettersCount+1],'*'.repeat(symbolCount-row)))
        } else if(row===2){
            console.log(sequence[lettersCount].concat('-'.repeat(symbolCount*row),sequence[lettersCount+1]))
        } else if(row===3){
            console.log('*'.concat(sequence[lettersCount],'-'.repeat(symbolCount),sequence[lettersCount+1],'*'))
        } else if(row===4){
            console.log('*'.repeat(symbolCount).concat(sequence[lettersCount],sequence[lettersCount+1],'*'.repeat(symbolCount)))
        }

        row++
        lettersCount+=2
    }
}

//dna(4)
dna(10)