function sprintReview(data){
    let n = data.shift()
    let assignees = {}
    
    let commandParser = {
        'Add New':addNew,
        'Change Status':changeStatus,
        'Remove Task':removeTask
    }

    let points = {
        ToDo:0,
        'In Progress':0,
        'Code Review':0,
        'Done':0
    }

    for (let i = 0; i < n; i++) {
        let [assignee,taskId,title,status,estimatedPoints] = data.shift().split(':')

        if(!assignees.hasOwnProperty(assignee)){
            assignees[assignee] = []
        }
        assignees[assignee].push({
            taskId,
            title,
            status,
            estimatedPoints
        })
    }

    while(data.length > 0){
        let commandInfo = data.shift().split(':')
        let command = commandInfo[0]
        commandParser[command](...commandInfo.slice(1))
    }

    for (const key in assignees) {
        for (const task of assignees[key]) {
            points[task.status] += Number(task.estimatedPoints)
        }
    }

    for (const key in points) {
        if(key === 'Done'){
            console.log(`${key} Points: ${points[key]}pts`)
        } else {
            console.log(`${key}: ${points[key]}pts`)
        }
    }

    if(points['ToDo'] + points['Code Review']+points['In Progress'] > points['Done']){
        console.log('Sprint was unsuccessful...')
    } else {
        console.log('Sprint was successful!')
    }



    function addNew(assignee,taskId,title,status,estimatedPoints){
        if(!assignees.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`)
        } else {
            assignees[assignee].push({
                taskId,
                title,
                status,
                estimatedPoints
            })
        }
    }

    function changeStatus(assignee,taskId,newStatus){
        if(!assignees.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`)
        } else {
            let currentTask = assignees[assignee].find(x=>x.taskId ===taskId)

            if(currentTask === undefined){
                console.log(`Task with ID ${taskId} does not exist for ${assignee}!`)
            } else {
                currentTask.status = newStatus
            }
        }
    }

    function removeTask(assignee,index){
        if(!assignees.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`)
        } else {
            if(index >= 0 && index < assignees[assignee].length){
                assignees[assignee].splice(index,1)
            } else {
                console.log(`Index is out of range!`)
                
            }
        }
    }



}

sprintReview(    [
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