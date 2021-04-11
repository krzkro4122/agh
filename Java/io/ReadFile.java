import java.io.*;

public class ReadFile{
    private static BufferedReader reader;
    public static void main(String[] args) throws IOException {        
        reader = new BufferedReader(new FileReader(args[0]));
        String s;
        while ((s = reader.readLine()) != null)
            System.out.println(s);
    }
}