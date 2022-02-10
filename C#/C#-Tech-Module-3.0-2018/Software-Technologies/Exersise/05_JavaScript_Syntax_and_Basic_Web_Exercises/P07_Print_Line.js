function solve(arr){
    arr = [...arr];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] != 'Stop') {
            console.log(arr[i]);
        }
        else{
            break;
        }        
    }
}

solve(['Line1', 'Line2', 'Line3', 'Stop']);
solve(['3', '6', '5', '4', 'Stop', '10', '12']);