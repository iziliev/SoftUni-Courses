function solve([num]){
    num = Number(num);

    for(let i=1; i<=num; i++){
        let numberAsString = '' + i;
        
        if(numberAsString == [...numberAsString].reverse().join('')){
            console.log(i);
        }
    }
}

solve(['750']);