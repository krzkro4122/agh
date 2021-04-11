import java.io.*;
import java.util.Scanner;

public class CopyFileExtended{

    private static BufferedReader bufferedReader;
    private static FileWriter myWriter;
    private static Scanner scanner;

    //  Description: File copying algo implementation
    //  @args - arguments parsed to the program in main
    private static boolean CopyFile(File source, File target) throws IOException {
        
        bufferedReader = new BufferedReader(new FileReader(source));
        String s;
        int countLines = 0; 

        try {                

            myWriter = new FileWriter(target);

            while ((s = bufferedReader.readLine()) != null){
                
                if (countLines != 0)
                    myWriter.write("\n");

                myWriter.write(s);
                countLines++;
            }
            myWriter.close();
            System.out.println(countLines + " lines were copied from " + source + " to " + target);
            return true;
        } 
        catch (IOException e) 
        {
            System.out.println("An error occurred while copying.");
            e.printStackTrace();
            return false;
        }        
    }

    public static void main(String[] args){                    
        
        String source = args[0];
        String target = args[1];

        // Display syntax hint when called with inproper argument count
        if(args.length != 2){

            // Syntax hint
            System.out.println("Correct Syntax: ");
            System.out.println();
            System.out.println("CopyFileExtended.java FILE0.txt FILE1.txt");
            System.out.println();

            return;
        }

        // File objects init
        File sourceFile = new File(source);
        File targetFile = new File(target);

        // Test if source exists
        if(!sourceFile.exists()){

            System.out.println("The given source file does not exist.");
            System.out.println();

            return;
        }

        // Test if source is a file
        if(sourceFile.isDirectory()){

            System.out.println("The given source is a directory, not a file.");
            System.out.println();

            return;
        }

        // Test if source is readable
        if(!sourceFile.canRead()){

            System.out.println("No permission to read from source file.");
            System.out.println();

            return;
        }

        // Test if target exists
        if(targetFile.exists()){

            // If target is writible
            if(!targetFile.canWrite()){

                System.out.println("No permission to write to target file.");
                System.out.println();

                return;
            }

            // Scanner init
            scanner = new Scanner(System.in);
            
            // User prompt
            System.out.println("Target file already exists. Do you want to overwrite it? (Y/N)");
            System.out.println();

            // User input handler
            if(scanner.nextLine() == "N"){

                System.out.println("User chose not to overwrite the target.");
                System.out.println();

                return;
            }

            // Copy
            try{
                // If target is a directory, create the target file in it
                if(targetFile.isDirectory())
                    CopyFile(sourceFile, File.createTempFile("Target", ".txt", targetFile));
                else 
                    CopyFile(sourceFile, targetFile);
                return;
            }
            catch (IOException e) 
            {
                System.out.println("An error occurred while copying.");
                e.printStackTrace();
                return;
            }              
        } 
        else {
            // Create new target file if not existent
            try{
                targetFile.createNewFile();
                System.out.println("Created a new target file.");
            }
            catch (IOException e){
                System.out.println("An error occurred while creating a file.");
                e.printStackTrace();
                return;
            }

            // Copy
            try{
                CopyFile(sourceFile, targetFile);
                return;
            }
            catch (IOException e) 
            {
                System.out.println("An error occurred while copying.");
                e.printStackTrace();
                return;
            }  
        }
    }
}