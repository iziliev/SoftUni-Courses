<?php

namespace CalculatorBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use CalculatorBundle\Entity\Calculator;
use CalculatorBundle\Form\CalculatorType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class CalculatorController extends Controller
{
    /**
     * @param Request $request
     *
     * @Route("/", name="index")
     *
     * @return \Symfony\Component\HttpFoundation\Response
     *
     */
    public function index(Request $request)
    {
        // TODO add $form and calculation logic;
        $calculator = new Calculator();

        $form = $this->createForm(CalculatorType::class, $calculator);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $leftOperand = $calculator->getLeftOperand();
            $rightOperand = $calculator->getRightOperand();
            $operator = $calculator->getOperator();
        
            $result = 0;
            $errorMsg="";
            switch ($operator) {
                case '+':
                    $result = $leftOperand + $rightOperand;
                    break;

                case '-':
                    $result = $leftOperand - $rightOperand;
                    break;
                
                case '*':
                    $result = $leftOperand * $rightOperand;
                    break;
                case '/':
                                        
                    if ($rightOperand == 0) {
                        $errorMsg = "Can't devide by ZERO!";
                        $result = "Undefined";
                    }
                    else {
                        $result = $leftOperand / $rightOperand;
                    }
                    
                    break;
                case '^':
                    $result = pow($leftOperand, $rightOperand);
                    break;
                case '%':
                    if ($rightOperand == 0) {
                        $errorMsg = "Can't modulo devide by ZERO!";
                        $result = "Undefined";
                    }
                    else {
                        $result = $leftOperand % $rightOperand;
                    }
                    break;

                case '&':
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

            }
            if ($errorMsg == "") {
                return $this->render('calculator/index.html.twig', ['result' => $result, 'errorMsg' => $errorMsg, 'calculator' => $calculator, 'form' => $form->createView()]);
            } 
            else {
                return $this->render('calculator/index.html.twig', ['result' => $result, 'errorMsg' => $errorMsg, 'calculator' => $calculator, 'form' => $form->createView()]);
            }
        }

        return $this->render('calculator/index.html.twig', ['form' => $form->createView()]);
    }
}
