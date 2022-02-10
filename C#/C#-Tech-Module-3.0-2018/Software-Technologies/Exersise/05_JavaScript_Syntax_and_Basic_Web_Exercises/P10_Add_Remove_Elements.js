function solve(arr) {

    let array = [];

    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(' ');
        let command = tokens[0];
        let value = Number(tokens[1]);

        if (command === 'add') {
            array.push(value);
        } else if (command === 'remove'){
            array.splice(value, 1);
        }
    }
    for(let item of array){
        console.log(item);
    }
}

solve(['add 3', 'add 5', 'add 7']);
solve(['add 3', 'add 5', 'remove 1', 'add 2']);
solve(['add 3', 'add 5', 'remove 2', 'remove 0', 'add 7'])