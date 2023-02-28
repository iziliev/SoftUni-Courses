function spice(yield){
    let extractYeld = 0
    let workers = 26
    let countDays = 0
    
    while(yield >= 100){

        extractYeld += (yield - workers)
        yield -= 10
        countDays++
    }

    if(extractYeld >=workers){
        extractYeld -= workers
    }
    console.log(countDays)
    console.log(extractYeld)
}

spice(111)
spice(450)