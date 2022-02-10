package P22_Intersection_of_Circles;

import java.util.Scanner;

public class Intersection_of_Circles {

    public static boolean intersect (Circle first, Circle second){
        double firstPartDistance = Math.pow(first.getCenter().getX() - second.getCenter().getX(),2);

        double secondPartDistance = Math.pow(first.getCenter().getY() - second.getCenter().getY(),2);

        double distance = Math.sqrt(firstPartDistance+secondPartDistance);

        return distance<=first.getRadius() + second.getRadius();
    }


    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        Circle first = new Circle(
          new Point(scan.nextInt(),scan.nextInt()),
          scan.nextInt()
        );

        Circle second = new Circle(
                new Point(scan.nextInt(),scan.nextInt()),
                scan.nextInt()
        );

        if (intersect(first,second)){
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}
