function solve([arr]){
    let regex = /\W+/;
    let input = [...arr.split(regex)];
    let result =[];
    
    for(let word of input){
        let wordUpper = word.toUpperCase();
        if(word == wordUpper){
            result.push(word);
        }        
    }
    console.log(result.join(', '));
}

solve(['We start by HTML, CSS, JavaScript, JSON and REST. Later we touch some PHP, MySQL and SQL. Later we play with C#, EF, SQL Server and ASP.NET MVC. Finally, we touch some Java, Hibernate and Spring.MVC.']);