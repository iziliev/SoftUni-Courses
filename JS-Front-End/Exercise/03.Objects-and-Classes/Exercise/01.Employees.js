function employees(data){

    Object.entries(data.reduce((data,employee)=>{
        data[employee] = employee.length
        return data
    },{})).forEach(([employee,length])=>console.log(`Name: ${employee} -- Personal Number: ${length}`))
}

employees([
'Silas Butler',
'Adnaan Buckley',
'Juan Peterson',
'Brendan Villarreal'
])