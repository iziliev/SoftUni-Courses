function students(data){
    
    class Course{
        constructor(name,capacity){
            this.name = name
            this.capacity = capacity
            this.students = []
        }
    }

    class Student{
        constructor(username,credits,email){
            this.username = username
            this.credits = credits
            this.email = email
        }
    }

    let courses = []

    for (const line of data) {
        if(line.includes(': ')){
            let info = line.split(': ')
            let name = info[0]
            let capacity = Number(info[1])
            let currentCourse = courses.find(x=>x.name === name)

            if(currentCourse === undefined){
                courses.push(new Course(name,capacity))
            } else {
                currentCourse.capacity+=capacity
            }
        } else{
            let info = line.replace('with email ','').replace('joins ','').split(' ')
            let infoStudent = info[0].replace('[',' ').replace(']','').split(' ')
            let studentName = infoStudent[0]
            let studentCredit = Number(infoStudent[1])
            let studentEmail = info[1]
            let courseName = info[2]

            let currentCourse = courses.find(x=>x.name === courseName)
            
            if(currentCourse !== undefined && currentCourse.capacity > 0){
                let currentUser = currentCourse.students.find(x=>x.username === studentName)
                if(currentUser === undefined){
                    currentCourse.students.push(new Student(studentName,studentCredit,studentEmail))
                    currentCourse.capacity--
                }
            }
        }
    }

    courses
    .sort((x,y)=>y.students.length - x.students.length)

    for (const course of courses) {
        console.log(`${course.name}: ${course.capacity} places left`)
        for (const student of course.students.sort((x,y)=>y.credits - x.credits)) {
            console.log(`--- ${student.credits}: ${student.username}, ${student.email}`)
        }
    }
    
}

students(['JavaBasics: 15',
'user1[26] with email user1@user.com joins JavaBasics',
'user2[36] with email user11@user.com joins JavaBasics',
'JavaBasics: 5',
'C#Advanced: 5',
'user1[26] with email user1@user.com joins C#Advanced',
'user2[36] with email user11@user.com joins C#Advanced',
'user3[6] with email user3@user.com joins C#Advanced',
'C#Advanced: 1',
'JSCore: 8',
'user23[62] with email user23@user.com joins JSCore']
)