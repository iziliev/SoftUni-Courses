function factorialDivision(numOne,numTwo){
    
    console.log((getFactorial(numOne)/getFactorial(numTwo)).toFixed(2))

    function getFactorial(number){
        if(number===1){
            return number
        }
        return number*getFactorial(number-1)
    }
}

factorialDivision(5,2)
factorialDivision(6,2)