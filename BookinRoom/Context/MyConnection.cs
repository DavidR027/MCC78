using System.Data.SqlClient;

namespace BasicConnection.Context;

public class MyConnection
{
    private static readonly string connectionString =
       "Data Source=LAPTOP-FTO3M4EL;Database=booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection Get()
    {
        /*var connection = new SqlConnection(connectionString);
        try {
            connection.Open();
            Console.WriteLine("Connection Open!");
        }
        catch (Exception e){
            Console.WriteLine("Error in connection" + e.Message);
        }
        finally {
            connection.Close();
        }
        return connection;*/

        return new SqlConnection(connectionString);
    }
}
