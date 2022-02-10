import java.util.Scanner;

public class P16_URL_Parser {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String line = scan.nextLine();

        String protocol="";
        String address="";
        String pages="";

        String[] input = line.split("([^\\.\\w|:]+)");
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.length; i++) {
            if (input[i].contains(":")){
                protocol = input[i].substring(0,input[0].length()-1);
                continue;
            }
            if (input[i].contains(".")){
                address = input[i];
                continue;
            }
            if (!input[i].contains(":") && !input[i].contains(".")){
                sb.append(input[i] + "/");
            }
        }
        if (sb.length()>0){
            pages = sb.toString().substring(0,sb.length()-1);
        }

        System.out.printf("[protocol] = \"%s\"",protocol);
        System.out.println();
        System.out.printf("[server] = \"%s\"",address);
        System.out.println();
        System.out.printf("[resource] = \"%s\"",pages);
        System.out.println();
    }
}

/*import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        if (input.contains("://")){
            String[] prot = input.split("://");
             System.out.println("[protocol] = "+"\""+prot[0]+"\"");
             if (!prot[1].equals("")){
                 String[] serv = prot[1].split("/+?");
                  System.out.println("[server] = "+"\""+serv[0]+"\"");
                  if (serv.length!=1){
                      String[] res = prot[1].split("^([^\\/]+)\\/");
                       System.out.println("[resource] = "+"\""+res[1]+"\"");
                  }
                  else {
                       System.out.println("[resource] = \"\"");
                  }
             }
        }
        else {
             System.out.println("[protocol] = \"\"");
            if (input.contains("/")){
                String[] serv = input.split("/+?");
                System.out.println("[server] = "+"\""+serv[0]+"\"");
                if (serv.length!=1){
                    String[] res = input.split("^([^\\/]+)\\/");
                    System.out.println("[resource] = "+"\""+res[1]+"\"");
                }
            }
            else {
                 System.out.println("[server] = "+"\""+input+"\"");
                  System.out.println("[resource] = \"\"");
            }
        }

    }
}*/
