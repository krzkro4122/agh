import java.io.*;

public class CopyFile{
    private static BufferedReader bufferedReader;
    private static FileWriter myWriter;
    public static void main(String[] args) throws IOException {
        bufferedReader = new BufferedReader(new FileReader(args[0]));
        String s;
        int countLines = 0;
    
        try{
            myWriter = new FileWriter(args[1]);
            while ((s = bufferedReader.readLine()) != null){
                if (countLines != 0)
                    myWriter.write("\n");
                myWriter.write(s);
                countLines++;
            }
            myWriter.close();
            System.out.println(countLines + " lines were copied from " + args[0] + " to " + args[1]);
        } catch (IOException e) {
            System.out.println("An error occurred while reading/writing.");
            e.printStackTrace();
        }
    }
}