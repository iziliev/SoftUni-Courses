function armies(data){
    class Leader{
        constructor(leaderName){
            this.leaderName = leaderName
            this.armies = []
            this.count = 0
        }
    }

    class Army{
        constructor(name,count){
            this.name = name
            this.count = count
        }
    }

    let leaders = []

    for (const line of data) {
        if(line.includes('arrives')){
            let info = line.split(' ')
            let index = info.indexOf('arrives')
            let leaderName = info.splice(0,index).join(' ')
            let currentLeader = leaders.find(x=>x.leaderName === leaderName)
            if(currentLeader === undefined){
                leaders.push(new Leader(leaderName))
            }
        } else if(line.includes('defeated')){
            let info = line.split(' ')
            let index = info.indexOf('defeated')
            let leaderName = info.slice(0,index).join(' ')
            let currentLeader = leaders.find(x=>x.leaderName === leaderName)
            let indexOfLeader = leaders.indexOf(currentLeader)
            if(indexOfLeader > -1){
                leaders.splice(indexOfLeader,1)
            }
        } else if(line.includes(':')){
            let info = line.split(': ')
            let leaderName = info[0]
            let [armyName, count] = info[1].split(', ')
            let currentLeader = leaders.find(x=>x.leaderName === leaderName)
            if(currentLeader !== undefined){
                currentLeader.armies.push(new Army(armyName,Number(count)))
                currentLeader.count+=Number(count)
            }
        } else if(line.includes('+')){
            let info = line.split(' + ')
            let armyName = info[0]
            let armyCount = Number(info[1])
            for (const leader of leaders) {
                for (const army of leader.armies) {
                    if(army.name === armyName){
                        army.count+=armyCount
                        leader.count+=armyCount
                    }
                }
            }
        }
    }

    leaders.sort((x,y)=>y.count - x.count).forEach(x=>{
        console.log(`${x.leaderName}: ${x.count}`)
        x.armies.sort((z,k)=>k.count-z.count).forEach(z=>console.log(`>>> ${z.name} - ${z.count}`))
    })


}

armies(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423'])