function solve(arr) {
    let n = Number(arr[0]);
    let array = new Array(n).fill(0);

    for (let i = 1; i < arr.length; i++) {
        let tokens = arr[i].split(' - ').map(n=>Number(n));
        let index = tokens[0];
        let value = tokens[1];

        array[index] = value;
    }
    for (let i = 0; i < array.length; i++) {
        console.log(array[i]);
    }
    
    
    
}solve(['3', '0 - 5', '1 - 6', '2 - 7']);
solve(['2', '0 - 5', '0 - 6', '0 - 7']);
solve(['5', '0 - 3', '3 - -1', '4 - 2']);