function extract(content) {
    const paragraph = document.getElementById(content).textContent
    const pattern = /[\(]{1}[\w ]+[\)]{1}/g
    const allMatched = Array.from(paragraph.match(pattern))
    let array = allMatched.map(x=>{
        x = x.replace('(','')
        x = x.replace(')','')
        return x
    });
    
    return `${array.join('; ')}`
}