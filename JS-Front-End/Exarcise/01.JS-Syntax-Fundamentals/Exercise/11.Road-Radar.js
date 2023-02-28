function radar(speed,place){
    if (place==='motorway') {
        if(speed <= 130){
            console.log(`Driving ${speed} km/h in a 130 zone`)
        } else {
            if(speed - 130 >= 1 && speed-130 <= 20){
                console.log(`The speed is ${speed-130} km/h faster than the allowed speed of 130 - speeding`)
            } else if(speed - 130 >= 21 && speed-130<=40){
                console.log(`The speed is ${speed-130} km/h faster than the allowed speed of 130 - excessive speeding`)
            }
            else{
                console.log(`The speed is ${speed-130} km/h faster than the allowed speed of 130 - reckless driving`)
            }
        }
    } else if (place==='interstate'){
        if(speed<=90){
            console.log(`Driving ${speed} km/h in a 90 zone`)
        } else {
            if(speed - 90 >= 1 && speed-90<=20){
                console.log(`The speed is ${speed-90} km/h faster than the allowed speed of 90 - speeding`)
            } else if(speed - 90 >= 21 && speed-90<=40){
                console.log(`The speed is ${speed-90} km/h faster than the allowed speed of 90 - excessive speeding`)
            }
            else{
                console.log(`The speed is ${speed-90} km/h faster than the allowed speed of 90 - reckless driving`)
            }
        }
        
    } else if (place==='city'){
        if(speed<=50){
            console.log(`Driving ${speed} km/h in a 50 zone`)
        } else {
            if(speed - 50 >= 1 && speed-50<=20){
                console.log(`The speed is ${speed-50} km/h faster than the allowed speed of 50 - speeding`)
            } else if(speed - 50 >= 21 && speed-50<=40){
                console.log(`The speed is ${speed-50} km/h faster than the allowed speed of 50 - excessive speeding`)
            }
            else{
                console.log(`The speed is ${speed-50} km/h faster than the allowed speed of 50 - reckless driving`)
            }
        }
    } else if (place==='residential'){
        if(speed<=20){
            console.log(`Driving ${speed} km/h in a 20 zone`)
        } else {
            if(speed - 20 >= 1 && speed-20<=20){
                console.log(`The speed is ${speed-20} km/h faster than the allowed speed of 20 - speeding`)
            } else if(speed - 20 >= 21 && speed-20<=40){
                console.log(`The speed is ${speed-20} km/h faster than the allowed speed of 20 - excessive speeding`)
            }
            else{
                console.log(`The speed is ${speed-20} km/h faster than the allowed speed of 20 - reckless driving`)
            }
        }
    }
}

radar(40, 'city')
radar(21, 'residential')
radar(120, 'interstate')
radar(200, 'motorway')