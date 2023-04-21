function sprintReview(data){

    let n = data.shift()

    let commandParser = {
        'Add New': addNew,
        'Change Status': changeStatus,
        'Remove Task': removeTask
    }

    let assignees = {}

    for (let i = 0; i < n; i++) {
        
        let [assignee,taskId,title,status,estimatedPoints] = data.shift().split(':')
        if(!assignees.hasOwnProperty(assignee)){
            assignees[assignee] = []
        }
        assignees[assignee].push({taskId,title,status,estimatedPoints})
    }

    while(data.length > 0){
        let commandInfo = data.shift().split(':')
        let command = commandInfo[0]
        commandParser[command](...commandInfo.slice(1))
    }

    let toDoPoints = 0
    let inProgrPoints = 0
    let codeRewPoints = 0
    let donePoints = 0

    countPoints(assignees)
    
    printResult(toDoPoints,inProgrPoints,codeRewPoints,donePoints)
    
    function printResult(){
        console.log(`ToDo: ${toDoPoints}pts`)
        console.log(`In Progress: ${inProgrPoints}pts`)
        console.log(`Code Review: ${codeRewPoints}pts`)
        console.log(`Done Points: ${donePoints}pts`)

        if(donePoints >= toDoPoints + inProgrPoints + codeRewPoints){
            console.log(`Sprint was successful!`)
        } else {
            console.log(`Sprint was unsuccessful...`)
        }
    }

    function countPoints(assignees){
        for (const key in assignees) {
            for (const task of assignees[key]) {
                switch (task.status) {
                    case 'ToDo':
                        toDoPoints += Number(task.estimatedPoints)
                        break;
                    case 'In Progress':
                        inProgrPoints += Number(task.estimatedPoints)
                        break;
                    case 'Code Review':
                        codeRewPoints += Number(task.estimatedPoints)
                        break;
                    case 'Done':
                        donePoints += Number(task.estimatedPoints)
                        break;
                }
            }
        }   
    }

    function addNew(assignee,taskId,title,status,estimatedPoints){
        if(assignees.hasOwnProperty(assignee)){
            assignees[assignee].push({taskId,title,status,estimatedPoints})
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }

    function changeStatus(assignee,taskId,newStatus){
        if(assignees.hasOwnProperty(assignee)){
            let currentTask = assignees[assignee].find(x => x.taskId === taskId)
            if(currentTask!==undefined){
                currentTask.status = newStatus
            } else {
                console.log(`Task with ID ${taskId} does not exist for ${assignee}!`)
            }
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }

    function removeTask(assignee,index){

        if(assignees.hasOwnProperty(assignee)){
            if(index >= 0 && index < assignees[assignee].length){
                assignees[assignee].splice(index,1)
            } else {
                console.log(`Index is out of range!`)
            }

        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`)
        }
    }
}

sprintReview(    [
    '5',
    'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
    'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
    'Peter:BOP-1211:POC:Code Review:5',
    'Georgi:BOP-1212:Investigation Task:Done:2',
    'Mariya:BOP-1213:New Account Page:In Progress:13',
    'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
    'Change Status:Peter:BOP-1290:ToDo',
    'Remove Task:Mariya:1',
    'Remove Task:Joro:1',
]
)

// sprintReview(  [
//     '4',
//     'Kiril:BOP-1213:Fix Typo:Done:1',
//     'Peter:BOP-1214:New Products Page:In Progress:2',
//     'Mariya:BOP-1215:Setup Routing:ToDo:8',
//     'Georgi:BOP-1216:Add Business Card:Code Review:3',
//     'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
//     'Change Status:Georgi:BOP-1216:Done',
//     'Change Status:Will:BOP-1212:In Progress',
//     'Remove Task:Georgi:3',
//     'Change Status:Mariya:BOP-1215:Done',
// ]
// )