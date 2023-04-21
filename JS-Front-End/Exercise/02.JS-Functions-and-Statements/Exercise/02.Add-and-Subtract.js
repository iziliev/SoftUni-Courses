function addAndSubtract(...number){
    
    console.log(subtract(sum(number[0],number[1]),number[2]))
    
    function sum(numberOne,numberTwo){
        return numberOne + numberTwo
    }

    function subtract(numberOne,numberTwo){
        return numberOne-numberTwo
    }
}

addAndSubtract(23,6,10)
addAndSubtract(1,17,30)
addAndSubtract(42,58,100)