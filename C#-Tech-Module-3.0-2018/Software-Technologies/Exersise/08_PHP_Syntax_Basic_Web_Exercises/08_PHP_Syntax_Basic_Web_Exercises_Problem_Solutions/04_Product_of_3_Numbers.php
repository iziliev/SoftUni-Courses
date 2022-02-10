<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        X: <input type="text" name="num1" />
		Y: <input type="text" name="num2" />
        Z: <input type="text" name="num3" />
		<input type="submit" />
    </form>

	<!--Write your PHP Script here-->

    <?php
        
        if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
            $numOne = intval($_GET['num1']);
            $numTwo = intval($_GET['num2']);
            $numThree = intval($_GET['num3']);
        
            $countNegative = 0;

            if ($numOne < 0) {
                $countNegative++;
            } 
            if ($numTwo < 0) {
                $countNegative++;
            } 
            if ($numThree < 0) {
                $countNegative++;
            } 
            
            if ($countNegative % 2 == 0 || 
                $numOne == 0 || 
                $numTwo == 0 ||  
                $numThree == 0) {
                echo "Positive";
            } else {
                echo "Negative";
            }
        }
         
    ?>

</body>
</html>