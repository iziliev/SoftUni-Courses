function extractText() {
    const items = Array.from(document.getElementById('items').children)
    console.log(items)
    let text = ''

    for (const item of items) {
        text += item.textContent + '\n'
    }

    const area = document.getElementById('result')
    area.textContent=text
}