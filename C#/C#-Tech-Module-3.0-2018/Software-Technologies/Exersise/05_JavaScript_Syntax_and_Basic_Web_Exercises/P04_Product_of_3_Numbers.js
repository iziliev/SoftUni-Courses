function solve(arr){
    arr = [...arr.map(n=>Number(n))];

    let negative = 0;
    
    for (let i = 0; i < arr.length; i++) {
        if (arr[i]<0) {
            negative+=1;
        }
    }
    
    if (negative % 2 == 0) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}
solve(['2', '3', '-1']);
solve(['4', '4', '3']);
solve(['-3', '-4', '5']);