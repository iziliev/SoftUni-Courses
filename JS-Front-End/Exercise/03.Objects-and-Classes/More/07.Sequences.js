function sequences(data){
    data = data.map(el => JSON.parse(el).sort((a,b)=> b - a));
    let indexNotPrint =[]
    for (let i = 0; i < data.length-1; i++) {
        for (let y = i+1; y < data.length; y++) {
            if(data[i].length === data[y].length){
                let isSame = true
                for (let z = 0; z < data[i].length; z++) {
                    if(data[i][z] !== data[y][z]){
                        isSame = false
                        break
                    }
                }

                if(isSame){
                    indexNotPrint.push(y)
                }
            }
        }
    }

    let arrays = []

    for (let i = 0; i < data.length; i++) {
        if(!indexNotPrint.includes(i)){
            let print = data[i]
            arrays.push(print)
        }
    }

    arrays.sort((x,y) =>x.length - y.length).forEach(x=>console.log(`[${x.join(', ')}]`))

}

sequences(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]

)