function solve(arr) {
    let students = {};
    for (items of arr){
        let tokens = items.split(' -> ');
        let propName= tokens[0];
        let value = isNaN(tokens[1]) ? tokens[1] : Number(tokens[1])

        students[propName] = value;
             
    }
    console.log(JSON.stringify(students));
    
}

solve(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia']);