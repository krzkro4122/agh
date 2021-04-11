import java.sql.*;

/**
 * AirTravel
 */
public class AirTravel {

    // JDBC driver name and database URL
    static final String MYSQL_DRIVER = "com.mysql.cj.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://mysql.agh.edu.pl/krkrol1";

    // Database credentials
    static final String USER = "krkrol1";
    static final String PASS = "jX0nfDtzPjC8101B";

    // Extract Data from result set
    private static String[] ExtractData( ResultSet resultSet ){
        try{
            while(resultSet.next()){
                //Retrieve by column name
                int client_id  = resultSet.getInt("Client_ID");            
                String full_name = resultSet.getString("Full_name");
                String login = resultSet.getString("Login");

                //Display values <- TODO Log4J
                System.out.print("Client_ID: " + client_id);            
                System.out.print(", Full_name: " + full_name);
                System.out.println(", Login: " + login);
            }
        } catch(SQLException se){
            //Handle errors for JDBC
            se.printStackTrace();
        }
    }

    public static void main(String[] args) {

        Connection connection = null;
        Statement statement = null;

    try{
        // Register JDBC driver
        Class.forName(MYSQL_DRIVER);

        // Open a connection
        System.out.println("Connecting to database..."); // <- TODO Log4J 
        connection = DriverManager.getConnection(DB_URL, USER, PASS);

        // Execute a query
        System.out.println("Creating statement..."); // <- TODO Log4J
        statement = connection.createStatement();
        String sql;
        sql = "SELECT * FROM clients";
        ResultSet resultSet = statement.executeQuery(sql);

        // Extract data from result set
        ExtractData(resultSet);

        // Clean-up leftover resources
        resultSet.close();
        statement.close();
        connection.close();
    } catch(SQLException se){
        // Handle errors for JDBC
        se.printStackTrace();
    } catch(Exception e){
        // Handle errors for Class.forName
        e.printStackTrace();
    } finally{
        // A "finally" block used for closing leftover resources
        try{

            if(statement != null)
                statement.close();

        } catch(SQLException se2){} // Nothing can be done

        try{

            if(connection!=null)
                connection.close();

        } catch(SQLException se){
            se.printStackTrace();
        }//end inner try
    }//end try
    
    System.out.println("Done working with database."); // <- TODO Log4J
        
    }
    
}