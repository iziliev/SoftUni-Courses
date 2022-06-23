function solve(arr) {
    arr = [...arr.map(Number)].reverse();
    
    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
}

solve(['10', '15', '20']);
solve(['5', '5.5', '24', '-3']);
solve(['20', '1', '20', '1', '20']);