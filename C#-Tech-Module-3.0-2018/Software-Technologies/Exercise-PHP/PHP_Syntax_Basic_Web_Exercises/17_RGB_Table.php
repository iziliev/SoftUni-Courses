<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
	<style>
		table * {
			border: 1px solid black;
			width: 50px;
			height: 50px;
		}
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
<!--Write your PHP Script here-->
    <?php
        $rgbcolor = 51;
        for ($i=1; $i <= 5; $i++) { 
            echo "<tr>";
                echo "<td style='background-color: rgb($rgbcolor,0,0)'></td>";
                echo "<td style='background-color: rgb(0,$rgbcolor,0)'></td>";
                echo "<td style='background-color: rgb(0,0,$rgbcolor)'></td>";
            echo "</tr>";

            $rgbcolor += 51;
        }
    ?>
</table>
</body>
</html>