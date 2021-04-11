import  java.io.*;
import  java.net.URL;

public class ReadWebPage {
   public static void main(String[ ] args) throws IOException  {
       BufferedReader reader;
       reader = new BufferedReader(new InputStreamReader((new  URL("http://java.tomek.it")).openStream() ));
      String s;
       while ( (s=reader.readLine())!=null )
              System.out.println( s );
   }
}