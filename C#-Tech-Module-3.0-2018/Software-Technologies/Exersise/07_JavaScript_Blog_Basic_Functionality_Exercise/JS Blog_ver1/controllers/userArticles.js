const Sequelize = require('sequelize');
const Op = Sequelize.Op;
const Article = require('../models').Article;
const User = require('../models').User;


module.exports = {
    userArticles: (req, res) => {
        let id = req.user.id
        Article.findAll({ include: [{
            model: User
        }], where: {authorId: {
                [Op.eq]:[id]
            }
        }
    }).then(articles => {
            articles.map(a => a.dataValues.content = a.dataValues.content.substring(0,340));            
            res.render('article/userArticles', {articles : articles} /*, {date:date}*/);
        });
    },

    details: (req, res) => {
        let id = req.params.id;
        
        Article.findById(id, {include: [{
            model: User
        }]
    }).then( article => {
        res.render('article/userArticlesDetails', article.dataValues)
    });
    },
};