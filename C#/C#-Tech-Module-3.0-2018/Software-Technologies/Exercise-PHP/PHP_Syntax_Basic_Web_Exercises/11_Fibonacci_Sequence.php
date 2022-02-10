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
        $first = 1;
        $second = 1;
        $fibon = 0;

        echo $first . " " . $second ." ";
        if(isset($_GET['num'])){
            $num = intval($_GET['num']);
            for ($i = 2; $i < $num ; $i++) { 
                $fibon = $first + $second;
                echo $fibon . " ";
                $first = $second;
                $second = $fibon;
            }
        }
    ?>
</body>
</html>