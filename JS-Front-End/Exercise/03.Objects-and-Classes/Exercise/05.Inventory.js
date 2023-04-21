function inventory(data){
    let heroes = []
    
    for (const line of data) {
        let [hero,level,items] = line.split(' / ')
        heroes.push({hero,level:Number(level),items})
    }

    heroes
    .sort((a,b)=>a.level - b.level)
    .forEach(x=>{
        console.log(`Hero: ${x.hero}`)
        console.log(`level => ${x.level}`)
        console.log(`items => ${x.items}`)
    })
    
    
    //with class
    // class Hero{
    //     constructor(name,level,items){
    //         this.name = name
    //         this.level=level
    //         this.items=items
    //     }
    // }

    // let heroes=[]

    // for (const line of data) {
    //     let heroInfo = line.split(' / ')
    //     let heroItems = heroInfo[2].split(', ')

    //     heroes.push(new Hero(heroInfo[0],heroInfo[1],heroItems))
    // }

    // heroes
    // .sort((x,y)=>x.level-y.level)
    // .forEach((x)=>console.log(`Hero: ${x.name}\nlevel => ${x.level}\nItems => ${x.items.join(', ')}`))
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ])