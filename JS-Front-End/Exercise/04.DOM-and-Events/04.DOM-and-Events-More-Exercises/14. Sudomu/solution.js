function solve() {
    let inputs = document.querySelectorAll('input');
    const quickCheckBtn = document.querySelectorAll('button')[0]
    const clearBtn =document.querySelectorAll('button')[1]

    const table = document.querySelector('table')
    const checkP = document.querySelector('#check p')
    
    quickCheckBtn.style.cursor = 'pointer';
    clearBtn.style.cursor = 'pointer';

    clearBtn.addEventListener('click',clear)
    quickCheckBtn.addEventListener('click',check)
    
    function clear(){
        [...inputs].forEach(x => (x.value = ''))
        table.style.border = 'none'
        checkP.textContent = ''
    }
    
    function check(){
       let matrix = [
        [inputs[0].value , inputs[1].value ,inputs[2].value],
        [inputs[3].value , inputs[4].value ,inputs[5].value],
        [inputs[6].value , inputs[7].value ,inputs[8].value]
       ]

        notSuccess = true

        for (let i = 1; i < matrix.length; i++) {
            let row = matrix[i]
            let col = matrix.map(row => row[i]);

            if (col.length != [...new Set(col)].length || row.length != [...new Set(row)].length) {
                notSuccess = false;
                break;
            }
        }

        if(notSuccess){
            table.style.border = '2px solid green'
            checkP.style.color = 'green'
            checkP.textContent = "You solve it! Congratulations!" 
        } else {
            table.style.border = '2px solid red'
            checkP.style.color = 'red'
            checkP.textContent = "NOP! You are not done yet..." 
        }
    }

}