function validator(password){
    const isValidLength = (password) => password.length >=6 && password.length<=10
    const isOnlyLettersAndDigits = (password) => /^[A-Za-z0-9]+$/g.test(password)
    const hasTwoOrMoreDigits = (password)=>[...password.matchAll(/\d/g)].length >=2

    let isValid = true

    if (!isValidLength(password)) {
        console.log(`Password must be between 6 and 10 characters`)
        isValid = false
    }
    
    if (!isOnlyLettersAndDigits(password)) {
        console.log(`Password must consist only of letters and digits`)
        isValid = false
    }

    if (!hasTwoOrMoreDigits(password)){
        console.log('Password must have at least 2 digits')
        isValid = false
    }

    if (isValid) {
        console.log('Password is valid')
    }

}

//validator('logIn')
validator('MyPass123')
//validator('Pa$s$s')