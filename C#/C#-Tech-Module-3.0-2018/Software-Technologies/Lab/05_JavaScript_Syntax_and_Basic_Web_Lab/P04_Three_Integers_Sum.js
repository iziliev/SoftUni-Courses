function solve([arr]){
    arr = arr.split(' ').map(n=>Number(n));

    if(arr[0] + arr[1] == arr[2]){
        console.log(`${Math.min(arr[0],arr[1])} + ${Math.max(arr[0],arr[1])} = ${arr[2]}`);
    }
    else if(arr[0] + arr[2] == arr[1]){
        console.log(`${Math.min(arr[0],arr[2])} + ${Math.max(arr[0],arr[2])} = ${arr[1]}`);
    }
    else if(arr[1] + arr[2] == arr[0]){
        console.log(`${Math.min(arr[1],arr[2])} + ${Math.max(arr[1],arr[2])} = ${arr[0]}`);
    }
    else{
        console.log('No');
    }
}

solve(['8 15 7']);
solve(['-5 -3 -2']);
solve(['3 8 12']);