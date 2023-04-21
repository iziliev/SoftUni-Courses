function generateReport() {
    const columnNames = Array.from(document.querySelectorAll('input[type="checkbox"]'))
    const allCheckedBox =  Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
    let indexChecked = []
    let names = []
    let result=[{}]
    
    for (let i = 0; i < columnNames.length; i++) {
        if(columnNames[i].checked){
            indexChecked.push(i)
            names.push(columnNames[i].getAttribute('name'))
        }
    }

    const allTbodyTr = Array.from(document.querySelectorAll('tbody > tr'))

    for (let i = 0; i < allTbodyTr.length; i++) {

        let children = Array.from(allTbodyTr[i].children)
        let obj = names.reduce((o, key) => ({ ...o, [key]: ''}), {})
        for (let y = 0; y < indexChecked.length; y++) {
            
            obj[names[y]] = children[indexChecked[y]].textContent
            
        }
        result.push(obj)
    }
    result.shift()
    
    let resultArea = document.getElementById('output')
    resultArea.value = JSON.stringify(result)
}
    
