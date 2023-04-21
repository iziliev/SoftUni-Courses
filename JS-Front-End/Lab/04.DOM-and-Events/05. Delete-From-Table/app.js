function deleteByEmail() {
    const tds = Array.from(document.querySelectorAll('td:nth-child(even)'))
    const emailToDelete = document.querySelector('input')
    const result = document.getElementById('result')

    const findElement = tds.find(x=>x.textContent === emailToDelete.value)
    if(findElement){
        findElement.parentElement.remove()
        result.textContent='Deleted.'
    } else {
        result.textContent='Not found.'
    }
    emailToDelete.value = ''
}