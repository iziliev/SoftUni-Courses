const Article = require('../models').Article;
const User = require('../models').User;


module.exports = {
    index: (req, res) => {
        Article.findAll({ limit: 12, include: [{
            model: User
        }]}).then(articles => {
            articles.map(a => a.dataValues.content = a.dataValues.content.substring(0,340)); 
            //articles.map(y => article.dataValues.date = y.dataValues.date.toDateString());           
            res.render('home/index', {articles:articles} /*, {date:date}*/);
        });
    }
};