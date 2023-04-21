function solve() {
    const output = document.getElementById('output')
    const area = document.getElementById('input')
    let input = area.value
    let sentences = input.split('.')
    sentences.pop()

    while(sentences.length > 0){
        const p = document.createElement('p')
        p.textContent = sentences.splice(0,3)+ '.'
        output.appendChild(p)
    }

    area.value=''
}