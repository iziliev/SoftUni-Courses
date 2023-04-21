function horseRacing(data){
    let horses = data.shift().split('|')

    const commandParser = {
        Retake:retake,
        Trouble:trouble,
        Rage:rage,
        Miracle:miracle
    }

    while(data[0] !== 'Finish'){
        let commandInfo = data.shift().split(' ')
        let command = commandInfo[0]

        commandParser[command](...commandInfo.slice(1))
    }

    console.log(horses.join('->'))
    console.log(`The winner is: ${horses[horses.length - 1]}`)

    function retake(overTakingHorse,overTakenHorse){

        let indexOverTaking = horses.findIndex(x=>x === overTakingHorse)
        let indexOverTaken = horses.findIndex(x=>x === overTakenHorse)

        if(indexOverTaking < indexOverTaken && indexOverTaken > -1 && indexOverTaking > -1){
            horses[indexOverTaken] = overTakingHorse
            horses[indexOverTaking] = overTakenHorse

            console.log(`${overTakingHorse} retakes ${overTakenHorse}.`)
        }
    }

    function trouble(horseName){
        let index = horses.findIndex(x=>x === horseName)

        if(index > 0 && index > -1){
            let prevHorse = horses[index - 1]
            horses[index] = prevHorse
            horses[index-1] = horseName

            console.log(`Trouble for ${horseName} - drops one position.`)
        }
    }

    function rage(horseName){
        let index = horses.findIndex(x=>x === horseName)
        
        if(horses.length - 2 === index && index > -1){
            let firstHorse = horses[index + 1]
            horses[index] = firstHorse
            horses[index + 1] = horseName

            console.log(`${horseName} rages 2 positions ahead.`)
        } else if(horses.length - 3 >= index && index > -1){
            let secondHorse = horses[index + 1]
            let firstHorse = horses[index + 2]

            horses[index] = secondHorse
            horses[index + 1]=firstHorse
            horses[index + 2]=horseName

            console.log(`${horseName} rages 2 positions ahead.`)
        } else if(index === horses.length-1){
            console.log(`${horseName} rages 2 positions ahead.`)
        }
    }

    function miracle(){
        if(horses.length > 1){
            let lastHorse = horses.shift()
            horses.push(lastHorse)
            console.log(`What a miracle - ${lastHorse} becomes first.`)
        }
    }
}


horseRacing((['Bella|Alexia|Sugar',
'Retake Alexia Sugar',
'Rage Bella',
'Trouble Bella',
'Finish'])

)