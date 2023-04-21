function register(data){
    let students = [{}]
    let differentGrade = []
    for (const line of data) {
        let info = line.split(', ')
        let studentName = info[0].split(': ')[1]
        let studentGradeCount=Number(info[1].split(': ')[1])
        let studentGradeAverage=Number(info[2].split(': ')[1])
        if(studentGradeAverage >=3){
            students.push({
                studentName,
                studentGradeCount,
                studentGradeAverage
            })
            if(!differentGrade.includes(studentGradeCount)){
                differentGrade.push(studentGradeCount)
            }
        }
    }

    students.sort((studentA,studentB)=>studentA.studentGradeCount-studentB.studentGradeCount)
    differentGrade.sort((a,b) => a-b)
    for (const gradeCount of differentGrade) {
        let filteredStudents = students.filter(x=>x.studentGradeCount === gradeCount)
        
        filteredStudents.map(x=>x.studentName).join(', ')
        let sum = filteredStudents.map(x=>x.studentGradeAverage).reduce((a, b) => a + b, 0) / filteredStudents.length
        console.log(`${gradeCount+1} Grade`)
        console.log(`List of students: ${filteredStudents.map(x=>x.studentName).join(', ')}`)
        console.log(`Average annual score from last year: ${sum.toFixed(2)}\n`)

    }

 


    //with class
    // class Student{
    //     constructor(name,gradeCount, averageGrade){
    //         this.name = name
    //         this.gradeCount = gradeCount
    //         this.averageGrade = averageGrade
    //     }
    // }
    
    // let students = []

    // for (const student of data) {
    //     let dataStudent = student.split(',')
    //     let name = ''
    //     let gradeCount = 0
    //     let averageGrade = 0.00
    //     for (let i = 0; i < dataStudent.length; i++) {
    //         let info = dataStudent[i].split(': ')
    //         if(i===0){
    //             name = info[1]
    //         }else if(i===1){
    //             gradeCount = info[1]
    //         }else{
    //             averageGrade = info[1]
    //         }
    //     }
        
    //     students.push(new Student(name,gradeCount,averageGrade))
    // }
    
    // let sortedStudent = students.filter(x=>x.averageGrade>=3.00).sort((x,y)=>x.gradeCount-y.gradeCount)


    // function groupBy(objectArray, property) {
    //     return objectArray.reduce(function (acc, obj) {
    //       var key = obj[property];
    //       if (!acc[key]) {
    //         acc[key] = [];
    //       }
    //       acc[key].push(obj);
    //       return acc;
    //     }, {});
    //   }

    //   let groupedStudent = groupBy(sortedStudent,'gradeCount')
    //   for (const iterator in groupedStudent){
    //     console.log(`${Number(iterator)+1} Grade`)
    //     let names = []
    //     let sumGrade = 0
    //     let count = 0    
    //     for (let i = 0; i < groupedStudent[iterator].length; i++) {
    //         names.push(groupedStudent[iterator][i].name)
    //         sumGrade+=Number(groupedStudent[iterator][i].averageGrade)
    //         count++
    //     }
    //     console.log(`List of students: ${names.join(', ')}`)
    //     console.log(`Average annual score from last year: ${(sumGrade/count).toFixed(2)}\n`)
            
    //   }
}


register([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
        "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
        "Student name: George, Grade: 8, Graduated with an average score: 2.83",
        "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
        "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
        "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
        "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
        "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
        "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
        "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
        "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
        "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ])