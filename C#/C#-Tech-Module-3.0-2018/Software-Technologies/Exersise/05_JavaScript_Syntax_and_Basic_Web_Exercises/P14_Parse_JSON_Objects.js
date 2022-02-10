function solve(arr) {
    
    let students = arr.map(JSON.parse);

    for(let item of students){
        console.log(`Name: ${item.name}`);
        console.log(`Age: ${item.age}`);
        console.log(`Date: ${item.date}`);
    }
}

solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}',
       '{"name":"Tosho","age":11,"date":"04/04/2005"}'
]);