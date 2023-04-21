function comment(data){
    class Article{
        constructor(name){
            this.name = name
            this.users = []
            this.countComments = 0
        }
    }

    class User{
        constructor(name,comment){
            this.name = name
            this.comment = comment
        }
    }

    let articles = []
    let users = []

    for (const line of data) {
        let info = line.split(' ')
        if(info[0] === 'user'){
            users.push(new User(info.splice(1,info.length).join(' ')))
        } else if(info[0] === 'article'){
            articles.push(new Article(info.splice(1,info.length).join(' ')))
        } else {
            let infoPost = line.split(': ')
            let infoData = infoPost[0].split(' posts on ')
            let username = infoData[0]
            let articleName = infoData[1]
            let comment = infoPost[1].replace(', ',' - ')

            let currentArticle = articles.find(x=>x.name === articleName)
            let currentUser = users.find(x=>x.name === username)

            if(currentArticle !== undefined && currentUser !== undefined){
                currentArticle.users.push(new User(username,comment))
                currentArticle.countComments++
            }
        }
    }

    articles = articles.sort((x,y)=>y.countComments-x.countComments)
    
    for (const article of articles) {
        console.log(`Comments on ${article.name}`)
        for (const user of article.users.sort().reverse()) {
            console.log(`--- From user ${user.name}: ${user.comment}`)
        }
    }
}

comment(['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much'])