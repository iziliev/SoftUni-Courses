function meeting(data){
    let schedule={}

    for (const line of data) {
        let [ day,name ] = line.split(' ')
        if(!schedule.hasOwnProperty(day)){
            schedule[day]=name
            console.log(`Scheduled for ${day}`)
        } else {
            console.log(`Conflict on ${day}!`)
        }
    }

    for (const key in schedule) {
        console.log(`${key} -> ${schedule[key]}`)
    }
}

meeting(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim'])
