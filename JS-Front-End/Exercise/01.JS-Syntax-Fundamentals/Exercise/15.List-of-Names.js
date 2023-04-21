function names(...listOfNames) {

    listOfNames[0]
    .sort((a, b) => a.localeCompare(b))
    .forEach((element,i) => {
        console.log(`${++i}.${element}`)
    });
    
}

names(["John", "Bob", "Christina", "Ema"])