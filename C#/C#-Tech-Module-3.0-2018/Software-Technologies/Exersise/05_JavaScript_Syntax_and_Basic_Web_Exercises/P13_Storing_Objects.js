function solve(arr) {

    let students = new Array();

    for(let item of arr){
        let tockens = item.split(' -> ');
        let name = tockens[0];
        let age = Number(tockens[1]);
        let grade = Number(tockens[2]);

        students.push({
            Name: name,
            Age: age,
            Grade: grade.toFixed(2)
        });
    }
    for(let stud of students){
        console.log(`Name: ${stud.Name}`);
        console.log(`Age: ${stud.Age}`);
        console.log(`Grade: ${stud.Grade}`);
    }
    
}

solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);