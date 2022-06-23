const Sequelize = require('sequelize');
const Op = Sequelize.op;
const Article = require('../models').Article;
const User = require('../models').User;

module.exports = {
    createGet: (req, res) => {
        res.render('article/create');
    },

    createPost: (req, res) => {
        let articleArgs = req.body;

        let errorMsg = false;

        if (!req.isAuthenticated()) {
            errorMsg = 'You should be logged in to make articles!';
        } else if (!articleArgs.title) {
            errorMsg = 'Invalid. title!';
        } else if (!articleArgs.content) {
            errorMsg = 'Invalid content!';
        }

        if (errorMsg) {
            res.render('article/create', {error: errorMsg});
            return;
        }

        articleArgs.authorId = req.user.id;

        Article.create(articleArgs).then(artcle => {
            res.redirect('/');
        }).catch(err => {
            console.log(err.message);
            res.render('article/create', {error: err.message});
        });
    },

    details: (req, res) => {
        let id = req.params.id;
        
        Article.findById(id, {include: [{
            model: User
        }]
    }).then( article => {
        res.render('article/details', article.dataValues)
    });
    },

    detailsArticle: (req,res) =>{
        let userId = req.user.id;
        
        Article.findAll({/*limit: 1500,*/ include:[{
            model:User
        }], where: {
            authorId: /*{
                [Op.eq] : [1]*/userId
            }
        
    }).then(articles => {
        let errorMsgArticles = '';
            if(articles){
                res.render('user/details', {articles : articles});     
            } else {
                errorMsgArticles = 'You have not write article yet!';
                res.render('user/details', {error: errorMsgArticles});
                return;
            }   
    })
    }
};