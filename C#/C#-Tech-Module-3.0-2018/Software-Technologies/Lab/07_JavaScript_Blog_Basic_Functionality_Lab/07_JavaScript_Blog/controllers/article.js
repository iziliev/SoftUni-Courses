const Article = require('../models').Article;
const User = require('../models').User;

module.exports = {
    createGet: (req,res) => {
        res.render('article/create');
    },

    createPost: (req, res) => {
        //take values from request
        const title = req.body.title;
        const content = req.body.content;
        
        let errorMsg = false;
        // validate input
        if (!req.isAuthenticated()) {
            errorMsg = 'You should be logged in to make articles!';
        } else if (!title) {
            errorMsg = 'Invalid title!';
        } else if (!content) {
            errorMsg = "Invalid content!";
        }

        if (errorMsg) {
            res.render('article/create', {error: errorMsg, title, content});
            return;
        }

        //find author
        const authorId = req.user.id;

        const article = {
            title,
            content,
            authorId
        };

        //record values

        Article.create(article).then(article =>{
            res.redirect('/');
        }).catch(e => {
            console.log(e.message);
            res.render('article/create', {error: e.message});
        });
    },

    details: (req, res) => {
        // get id article
        const articleId = Number(req.params.id);

        // get from DB by Id
        Article.findById(articleId, {
            include: [{
                model: User
            }]
        }).then(article => {
            if (article === null) {
                throw new Error('Article not found: ' + articleId);
            }
            res.render('article/details', article.dataValues)
        }).catch(e => {
            console.log(e.message);
            res.redirect('/404')            
        });
    }
};