function browser(object,array){
    let data={
        'Browser Name':object['Browser Name'],
        'Open Tabs':[...object['Open Tabs']],
        'Recently Closed':[...object['Recently Closed']],
        'Browser Logs':[...object['Browser Logs']]
    }

    for (const line of array) {
        let info = line.split(' ')
        let command = info[0]
        let site = info.slice(1)[0]

        if(command === 'Open'){
            data['Open Tabs'].push(`${site}`)
            data['Browser Logs'].push(`Open ${site}`)
        } else if(command === 'Close'){
            if(data['Open Tabs'].includes(site)){
                let indexSite = data['Open Tabs'].indexOf(site)
                data['Open Tabs'].splice(indexSite,1)
                data['Recently Closed'].push(`${site}`)
                data['Browser Logs'].push(`Close ${site}`)
            }
        } else {
            data['Open Tabs'] = []
            data['Recently Closed'] = []
            data['Browser Logs'] = []
        }
    }

    console.log(data['Browser Name'])
    console.log(`Open Tabs: ${data['Open Tabs'].join(', ')}`)
    console.log(`Recently Closed: ${data['Recently Closed'].join(', ')}`)
    console.log(`Browser Logs: ${data['Browser Logs'].join(', ')}`)
}

browser({
    "Browser Name":"Google Chrome",
"Open Tabs":["Facebook","YouTube","Google Translate"],
"Recently Closed":["Yahoo","Gmail"],
"Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
["Close Facebook", "Open StackOverFlow", "Open Google"])