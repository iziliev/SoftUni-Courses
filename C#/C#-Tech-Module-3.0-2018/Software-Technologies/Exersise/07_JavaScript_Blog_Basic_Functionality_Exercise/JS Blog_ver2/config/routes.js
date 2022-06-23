const userController = require('../controllers').user;
const homeController = require('../controllers').home;
const articleController = require('../controllers').article;
const userArticleControllers = require('../controllers').userArticles;

module.exports = (app) =>{
    app.get('/',homeController.index);

    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);
    app.get('/user/login',userController.loginGet);
    app.post('/user/login',userController.loginPost);

    app.get('/user/logout',userController.logout);

    app.get('/article/create', articleController.createGet);
    app.post('/article/create', articleController.createPost);

    app.get('/article/details/:id', articleController.details);

    app.get('/user/details', articleController.detailsArticle);
    
    app.get('/user/details', userController.userInfo);

    app.get('/article/userArticles', userArticleControllers.userArticles);
    app.get('/article/userArticlesDetails/:id', userArticleControllers.details);


    
};
