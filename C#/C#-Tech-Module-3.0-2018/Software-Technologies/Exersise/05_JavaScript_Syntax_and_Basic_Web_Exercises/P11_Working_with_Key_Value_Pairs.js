function solve(arr) {

    let kvp = {};

    for (let i = 0; i < arr.length - 1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];
        
        kvp[key] = value
    }
    let search = arr[arr.length - 1];
    if (search in kvp) {
        console.log(kvp[search]);
    } else {
        console.log('None');
    }
    
}

solve(['key value', 'key eulav', 'test tset', 'key'])
solve(['3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4']);
solve(['3 bla', '3 alb', '2']);