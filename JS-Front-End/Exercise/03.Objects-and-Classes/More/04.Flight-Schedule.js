function flight(data){
    
    let flights = [{}]
    for (const flight of data[0]) {
        let [number,destination] = flight.split(' ')
        flights.push({
            Number:number,
            Destination:destination,
            Status:null
        })
    }

    for (const flight of data[1]) {
        let [number,status] = flight.split(' ')
        let currentFlights = flights.find(x=>x.Number === number)
        
        if(currentFlights){
            let index = flights.indexOf(currentFlights)
            flights[index].Status = status
        }
    }

    if(data[2][0] === 'Ready to fly'){
        let filtered = flights.filter(x => x.Status === null)

        for (const flight of filtered) {
            flight.Status = 'Ready to fly'
            console.log(`{ Destination: '${flight.Destination}', Status: '${flight.Status}' }`)
        }
    } else {
        flights.filter(x => x.Status === data[2][0]) .forEach(x=>console.log(`{ Destination: '${x.Destination}', Status: '${x.Status}' }`))
    }




    //with class
    // class Flight{
    //     constructor(number, destination, status){
    //         this.number = number
    //         this.destination = destination
    //         this.status = status
    //     }
    // }

    // let flights = []

    // for (const flight of data[0]) {
    //     let info = flight.split(' ')
    //     let number = info[0]
    //     let destination = info.slice(1).join(' ')
    //     flights.push(new Flight(number,destination,null))
    // }

    // for (const statusInfo of data[1]) {
    //     let info = statusInfo.split(' ')
    //     let number = info[0]
    //     let status = info.slice(1).join(' ')

    //     let currentFlight = flights.find(x=>x.number === number)
        
    //     if(currentFlight !== undefined){
    //         currentFlight.status = status
    //     }
    // }

    // if(data[2][0] === 'Ready to fly'){
    //     flights.filter(x=>x.status === null).forEach(x=>x.status = 'Ready to fly')
    // }
    
    // flights.filter(x=>x.status === data[2][0])
    // .sort((x,y)=>x.destination === y.destination)
    // .forEach(x=>console.log(`{ Destination: '${x.destination}', Status: '${x.status}' }`))

    //flights.filter(x=>x.status === data[2][0])
    //.sort((x,y)=>x.destination === y.destination)
    //.forEach(x=>{
    //    let obj = {
    //        Destination:x.destination,
    //        Status:x.status
    //    }
    //    console.log(JSON.stringify(obj))
    //})
}

flight([['WN269 Delaware',
'FL2269 Oregon',
 'WN498 Las Vegas',
 'WN3145 Ohio',
 'WN612 Alabama',
 'WN4010 New York',
 'WN1173 California',
 'DL2120 Texas',
 'KL5744 Illinois',
 'WN678 Pennsylvania'],
 ['DL2120 Cancelled',
 'WN612 Cancelled',
 'WN1173 Cancelled',
 'SK430 Cancelled'],
 ['Cancelled']
]

)