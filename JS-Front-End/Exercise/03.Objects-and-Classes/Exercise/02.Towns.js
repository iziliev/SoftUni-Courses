function towns(input){
    
    //with reduce
    input.reduce((data,input)=>{
        let [town,latitude,longitude] = input.split(' | ')
        data = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }
        console.log(data)
        return data
    },{})
    
    //with for
    for (const line of input) {
        let [town,latitude,longitude] = line.split(' | ')
        let townObj = {town,latitude:Number(latitude).toFixed(2),longitude:Number(longitude).toFixed(2)}
        console.log(townObj)
    }
    // with class
    class Town {
        constructor(town,latitude,longitude){
            this.town=town,
            this.latitude=latitude,
            this.longitude=longitude
        }
    }

    let townsInfo = []

    for (const line of data) {
        let [town,latitude,longitude] = line.split(' | ')

        townsInfo.push(new Town(town,Number(latitude),Number(longitude)))
    }

    for (const town of townsInfo) {
        console.log(`{ town: '${town.town}', latitude: '${town.latitude.toFixed(2)}', longitude: '${town.longitude.toFixed(2)}' }`)
    }
}

towns(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)