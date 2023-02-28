function login(text) {
    let username = text[0]
    let count=0
    for (let i = 1; i < text.length; i++) {
        let password = text[i].split('').reverse().join('')

        if (username !== password) {
            
            count++
            
            if (count === 4) {
                console.log(`User ${username} blocked!`)
                break
            } else{
                console.log(`Incorrect password. Try again.`)
            }
            
        } else{
            console.log(`User ${username} logged in.`)
            break
        }
    }
}

login(['Acer','login','go','let me in','recA'])
//login(['momo','omom'])
//login(['sunny','rainy','cloudy','sunny','not sunny'])