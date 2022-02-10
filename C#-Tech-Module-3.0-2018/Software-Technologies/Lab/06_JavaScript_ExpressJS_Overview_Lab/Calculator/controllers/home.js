const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req,res) => {
        let calcultorBody = req.body;
        let CalculatorParams = calcultorBody['calculator'];

        let calculator = new Calculator();

        calculator.leftOperand = Number(CalculatorParams.leftOperand);
        calculator.operator = CalculatorParams.operator;
        calculator.rightOperand = Number(CalculatorParams.rightOperand);

        let result = calculator.calculateResult();

        res.render('home/index', {'calculator': calculator, 'result': result});

    }

};