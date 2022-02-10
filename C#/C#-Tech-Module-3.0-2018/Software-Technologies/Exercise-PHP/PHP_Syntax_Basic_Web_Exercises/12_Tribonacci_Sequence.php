<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
	<!--Write your PHP Script here-->

    <?php
        
        if(isset($_GET['num'])){

            $first = 1;
            $second = 1;
            $third = 2;
            $tribonacci = 0;

            echo $first . " " . $second . " " . $third . " ";
            
            $num = intval($_GET['num']);
            for ($i = 3; $i < $num ; $i++) { 
                $tribonacci = $first + $second + $third;
                echo $tribonacci . " ";
                $first = $second;
                $second = $third;
                $third = $tribonacci;
            }
        }
    ?>
</body>
</html>