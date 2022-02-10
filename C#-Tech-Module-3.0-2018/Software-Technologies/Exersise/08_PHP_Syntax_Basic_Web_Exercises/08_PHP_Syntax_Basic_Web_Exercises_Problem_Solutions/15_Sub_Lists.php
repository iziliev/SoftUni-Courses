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
	<ul>
        <!--Write your PHP Script here-->
        <?php
            if (isset($_GET['num1']) && isset($_GET['num2'])){
                $numOne = intval($_GET['num1']);
                $numTwo = intval($_GET['num2']);
                for ($i=1; $i <=$numOne ; $i++) { 
                    echo "<li> List $i";
                        echo "<ul>";
                        for ($j=1; $j <=$numTwo ; $j++) { 
                            echo "<li> Element $i.$j </li>"; 
                        }
                        echo"</ul>";
                    echo "</li>";
                }
            }
            
        ?>
	</ul>
</body>
</html>