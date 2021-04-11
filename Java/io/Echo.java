import  java.io.*;

public class Echo {
   public static void main(String[] args) throws IOException  {

      Reader reader = new InputStreamReader(System.in);
      int value;
      while ( (value=reader.read())!=-1 ) System.out.print( (char) value);       
   }
}
