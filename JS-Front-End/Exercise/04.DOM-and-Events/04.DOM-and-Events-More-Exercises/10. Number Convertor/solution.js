function solve() {
    let result = document.getElementById('result')
    const select = document.getElementById('selectMenuTo')
    const firstToOption = document.createElement('option')
    firstToOption.value = 'binary'
    firstToOption.textContent = 'Binary'
    select.appendChild(firstToOption)
    const secondToOption = document.createElement('option')
    secondToOption.value = 'hexadecimal'
    secondToOption.textContent = 'Hexadecimal'
    select.appendChild(secondToOption)
    
    document.getElementsByTagName('button')[0].addEventListener('click',calculate)
    let numInput = document.getElementById('input')   

    function calculate(){
        if(select.value === 'binary'){
            result.value = Number(numInput.value).toString(2);
        } else if(select.value === 'hexadecimal'){
            result.value = Number(numInput.value).toString(16).toUpperCase();
        }
    }    
}