function sprint(data){

    let sprints = {}

    let statusCode = {
        'ToDo':0,
        'In Progress':0,
        'Code Review':0,
        'Done':0
    }

    let commandParser = {
        'Add New': addNew,
        'Change Status': changeStatus,
        'Remove Task': removeTask
    }

    let n = data.shift()
    for (let i = 0; i < n; i++) {
        let [assignee,taskId,title,status,estimatedPoints] = data.shift().split(':')

        if(!sprints.hasOwnProperty(assignee)){
            sprints[assignee] = []
        }

        sprints[assignee].push({taskId,title,status,estimatedPoints})
    }

    while(data.length > 0){
        let commandInfo = data.shift().split(':')
        
        let command = commandInfo[0]
        commandParser[command](...commandInfo.slice(1))
    }

    let donePoints = 0
    let otherPoints = 0

    for (const key in sprints) {
        for (const sprint of sprints[key]) {
            if (sprint.status === 'Done') {
                donePoints += Number(sprint.estimatedPoints)
            } else{
                otherPoints += Number(sprint.estimatedPoints)
            }

            statusCode[sprint.status] += Number(sprint.estimatedPoints)

        }
    }

    for (const key in statusCode) {
        if(key === 'Done'){
            console.log(`${key} Points: ${statusCode[key]}pts`)
        } else {
            console.log(`${key}: ${statusCode[key]}pts`)
        }
    }

    if(donePoints>=otherPoints){
        console.log('Sprint was successful!')
    } else{
        console.log('Sprint was unsuccessful...')
    }

    function addNew(assignee,taskId,title,status,estimatedPoints){
        if(sprints.hasOwnProperty(assignee)){
            sprints[assignee].push({taskId,title,status,estimatedPoints})
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }

    function changeStatus(assignee,taskId,newStatus){
        if(sprints.hasOwnProperty(assignee)){
            let currentTask = sprints[assignee].find(x=>x.taskId === taskId)
            if(currentTask !== undefined){
                currentTask.status = newStatus
            } else {
                console.log(`Task with ID ${taskId} does not exist for ${assignee}!`)
            }
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }

    function removeTask(assignee,index){
        if(sprints.hasOwnProperty(assignee)){
            if(index >= 0 && index <= sprints[assignee].length){
                sprints[assignee].splice(index,1)
            } else {
                console.log(`Index is out of range!`)
            }
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }
}

sprint(     [
    '4',
    'Kiril:BOP-1213:Fix Typo:Done:1',
    'Peter:BOP-1214:New Products Page:In Progress:2',
    'Mariya:BOP-1215:Setup Routing:ToDo:8',
    'Georgi:BOP-1216:Add Business Card:Code Review:3',
    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
    'Change Status:Georgi:BOP-1216:Done',
    'Change Status:Will:BOP-1212:In Progress',
    'Remove Task:Georgi:3',
    'Change Status:Mariya:BOP-1215:Done',
]

)