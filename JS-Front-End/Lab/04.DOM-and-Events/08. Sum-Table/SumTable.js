function sumTable() {
    const tdElements = Array.from(document.querySelectorAll('td:nth-child(even)'))
    console.log(tdElements)
    let sum = 0

    tdElements.forEach(x=>{
        sum+=Number(x.textContent)
    })
    
    const lastRow = document.getElementById('sum')
    lastRow.textContent = sum
}