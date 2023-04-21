function cats(data){
    let catsAll=[]
    class Cat {
        constructor(name, age) {
          this.name = name;
          this.age = age;
        }
    
        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`)
        }
    }

    for (const line of data) {
        let [ name,age] = line.split(' ')
        let cat = new Cat(name,age)
        catsAll.push(cat)
    }

    for (const cat of catsAll) {
        cat.meow()
    }

}

cats(['Mellow 2', 'Tom 5'])