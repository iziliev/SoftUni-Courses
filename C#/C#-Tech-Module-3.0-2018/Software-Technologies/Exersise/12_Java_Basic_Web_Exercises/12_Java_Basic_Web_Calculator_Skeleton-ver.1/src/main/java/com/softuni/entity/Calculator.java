package com.softuni.entity;

public class Calculator {
    private double leftOperand;
    private double rightOperand;
    private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator) {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double getLeftOperand() {
        return leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }

    public String getOperator() {
        return operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }

    public double calculateResult() {

        double result;
		String errorMsg = "";
        switch (this.operator){
            case "+":
                result = this.leftOperand + this.rightOperand;
                break;
				
            case "-":
                result = this.leftOperand - this.rightOperand;
                break;
				
            case "*":
                result = this.leftOperand * this.rightOperand;
                break;
				
            case "/":
				if (this.rightOperand == 0) {
                        errorMsg = "Can't divide by ZERO!";
                        result = "Undefined";
                    }
                    else {
                        result = this.leftOperand / this.rightOperand;
                    }
                break;
				
			case "^":
                result = Math.pow(this.leftOperand, this.rightOperand);
                break;
				
			case "%":
                if (this.rightOperand == 0) {
                        errorMsg = "Can't modulo divide by ZERO!";
                        result = "Undefined";
                    }
                    else {
                        result = this.leftOperand % this.rightOperand;
                    }
                break;
				
			case '&':
                    String pobitLeft = "";
                    String pobitRight = "";
                    
                    while (this.leftOperand > 0) {
                        this.pobitLeft = this.leftOperand % 2 + this.pobitLeft;
                        this.leftOperand = (int)(this.leftOperand / 2);
                    }
                    while (this.rightOperand > 0) {
                        this.pobitRight = this.rightOperand % 2 + this.pobitRight;
                        this.rightOperand = (int)(this.rightOperand / 2);
                    }

                    while (pobitLeft.lenght < 4) {
                        $pobitLeft = '0' . $pobitLeft;
                    }
                    while (strlen($pobitRight) < 4) {
                        $pobitRight = '0' . $pobitRight;
                    }
                    $sum = '';
                    
                    for ($i = 0; $i < 4; $i++) { 
                        
                        if ($pobitLeft[$i] == $pobitRight[$i] && $pobitLeft[$i] == 1 && $pobitRight[$i] == 1) {
                            $sum = $sum . 1;
                        }
                        else
                        {
                            $sum = $sum . 0;
                        }
                    }
                    $resultEnd = 0;

                    for ($i=0; $i < strlen($sum); $i++) { 
                        $numRez = (int)($sum[strlen($sum) - 1 - $i]);
                        $pow = pow(2,$i);
                        $resultEnd += $numRez * $pow;
                    }
                    $result = $resultEnd;
                    break;
                
                case '|':
                    $pobitLeft = '';
                    $pobitRight = '';
                    
                    while ($leftOperand > 0) {
                        $pobitLeft = $leftOperand % 2 . $pobitLeft;
                        $leftOperand = (int)($leftOperand / 2);
                    }
                    while ($rightOperand > 0) {
                        $pobitRight = $rightOperand % 2 . $pobitRight;
                        $rightOperand = (int)($rightOperand / 2);
                    }

                    while (strlen($pobitLeft) < 4) {
                        $pobitLeft = '0' . $pobitLeft;
                    }
                    while (strlen($pobitRight) < 4) {
                        $pobitRight = '0' . $pobitRight;
                    }
                    $sum = '';
                    
                    for ($i = 0; $i < 4; $i++) { 
                        
                        if ($pobitLeft[$i] == 1 || $pobitRight[$i] == 1) 
                        {
                            $sum = $sum . 1;
                        }
                        else
                        {
                            $sum = $sum . 0;
                        }
                    }
                    $resultEnd = 0;

                    for ($i=0; $i < strlen($sum); $i++) { 
                        $numRez = (int)($sum[strlen($sum) - 1 - $i]);
                        $pow = pow(2,$i);
                        $resultEnd += $numRez * $pow;
                    }
                    $result = $resultEnd;
                    break;
                
                    case 'NOR':
                    $pobitLeft = '';
                    $pobitRight = '';

                    while ($leftOperand > 0) {
                        $pobitLeft = $leftOperand % 2 . $pobitLeft;
                        $leftOperand = (int)($leftOperand / 2);
                    }
                    while ($rightOperand > 0) {
                        $pobitRight = $rightOperand % 2 . $pobitRight;
                        $rightOperand = (int)($rightOperand / 2);
                    }

                    while (strlen($pobitLeft) < 4) {
                        $pobitLeft = '0' . $pobitLeft;
                    }
                    while (strlen($pobitRight) < 4) {
                        $pobitRight = '0' . $pobitRight;
                    }
                    $sum = '';
                    
                    for ($i = 0; $i < 4; $i++) { 
                        
                        if ($pobitLeft[$i] == 0 && $pobitRight[$i] == 0) 
                        {
                            $sum = $sum . 1;
                        }
                        else
                        {
                            $sum = $sum . 0;
                        }
                    }
                    $resultEnd = 0;

                    for ($i=0; $i < strlen($sum); $i++) { 
                        $numRez = (int)($sum[strlen($sum) - 1 - $i]);
                        $pow = pow(2,$i);
                        $resultEnd += $numRez * $pow;
                    }
                    $result = $resultEnd;
                    break;    

                case 'XOR':
                    $pobitLeft = '';
                    $pobitRight = '';

                    while ($leftOperand > 0) {
                        $pobitLeft = $leftOperand % 2 . $pobitLeft;
                        $leftOperand = (int)($leftOperand / 2);
                    }
                    while ($rightOperand > 0) {
                        $pobitRight = $rightOperand % 2 . $pobitRight;
                        $rightOperand = (int)($rightOperand / 2);
                    }

                    while (strlen($pobitLeft) < 4) {
                        $pobitLeft = '0' . $pobitLeft;
                    }
                    while (strlen($pobitRight) < 4) {
                        $pobitRight = '0' . $pobitRight;
                    }
                    $sum = '';
                    
                    for ($i = 0; $i < 4; $i++) { 
                        
                        if ($pobitLeft[$i] == 0 && $pobitRight[$i] == 1 || $pobitLeft[$i] == 1 && $pobitRight[$i] == 0) 
                        {
                            $sum = $sum . 1;
                        }
                        else
                        {
                            $sum = $sum . 0;
                        }
                    }
                    $resultEnd = 0;

                    for ($i=0; $i < strlen($sum); $i++) { 
                        $numRez = (int)($sum[strlen($sum) - 1 - $i]);
                        $pow = pow(2,$i);
                        $resultEnd += $numRez * $pow;
                    }
                    $result = $resultEnd;
                    break;	
				
				
				
				
				
					
            default:
                result = 0;
                break;
        }
        return result;
    }
}
