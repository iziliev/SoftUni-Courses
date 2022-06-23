<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1" />
		M: <input type="text" name="num2" />
        <input type="submit" />
    </form>

	<!--Write your PHP Script here-->

    <?php 
        if (isset($_GET['num1']) && isset($_GET['num2'])) {
            $numOne = intval($_GET['num1']);
            $numTwo = intval($_GET['num2']);
            if ($numOne<=$numTwo) {
                echo $numOne * $numTwo;
            }
            else {
                if ($numTwo>0) {
                    echo $numOne / $numTwo;
                }
                else {
                    echo "Can't be devide by ZERO!";
                }
            }
        } 
    ?>

</body>
</html>