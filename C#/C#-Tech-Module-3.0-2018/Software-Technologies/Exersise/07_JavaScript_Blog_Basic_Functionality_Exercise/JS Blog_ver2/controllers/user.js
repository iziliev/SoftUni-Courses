const encryption = require("../utilities/encryption");
const User = require('../models').User;
const Article = require('../models').Article;

module.exports = {
    registerGet: (req, res) => {
        res.render('user/register');
    },

    registerPost: (req, res) => {
        let registerArgs = req.body;

        User.findOne({where: {email: registerArgs.email}}).then(user => {
            let errorMsg = '';
            if (user) {
                errorMsg = 'User with the same username exists!';
            } else if (registerArgs.password !== registerArgs.repeatedPassword) {
                errorMsg = 'Passwords do not match!'
            }

            if (errorMsg) {
                //registerArgs.error = errorMsg;
                res.render('user/register', {error: errorMsg})
                return;
            } else {

                let salt = encryption.generateSalt();
                let passwordHash = encryption.hashPassword(registerArgs.password, salt);

                let userObject = {
                    email: registerArgs.email,
                    passwordHash: passwordHash,
                    fullName: registerArgs.fullName,
                    salt: salt
                };

                User.create(userObject).then(user => {
                    req.logIn(user, (err) => {
                        if (err) {
                            registerArgs.error = err.message;
                            res.render('user/register', registerArgs.dataValues);
                            return;
                        }
                        res.redirect('/')
                    })
                })
            }
        })
    },

    loginGet: (req, res) => {
        res.render('user/login');
    },

    loginPost: (req, res) => {
        let loginArgs = req.body;
        let errorMsg = false;

        User.findOne({where: {email: loginArgs.email}}).then(user => {
            if (!user || !user.authenticate(loginArgs.password)) {
                errorMsg = 'Either username or password is invalid!';
                res.render('user/login', {error: errorMsg});
                return;
            } 
            
            req.logIn(user, (err) => {
                if (err) {
                    res.redirect('/user/login', {error: err.message});
                    return;
                }

                res.redirect('/');
            })
        })
    },

    userInfo: (req, res) => {
        let userId = req.user.id;

        User.findById(userId).then(user => {
            res.render('user/details', {user: user});
        });
    },

    logout: (req, res) => {
        req.logOut();
        res.redirect('/');
    }
};