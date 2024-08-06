using System.Data;
//using System.Data.SqlClient;
using Npgsql;
namespace AdoNetDemo
{
    public class ProductDal
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=adonet;Username=postgres;Password=test";
        NpgsqlConnection _connection = new NpgsqlConnection(connectionString);

        public List<Product> GetAll()
        {
            //SqlConnection connection = new SqlConnection("server=");
            ConnectionControl();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.\"Products\"", _connection);

            NpgsqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(
                    new Product{
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                        StockAmount = Convert.ToInt32(reader["StockAmount"])
                    });
            }
            
            reader.Close();
            _connection.Close();
            
            return products;
        }
        
        public DataTable GetAll2()
        {
            //SqlConnection connection = new SqlConnection("server=");

            ConnectionControl();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.\"Products\"", _connection);

            NpgsqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            
            return dataTable;

        }

        public void Add(Product newProduct)
        {
            ConnectionControl();
            NpgsqlCommand command = new NpgsqlCommand(
                "Insert Into public.\"Products\" (\"Name\", \"UnitPrice\", \"StockAmount\") VALUES(@Name, @UnitPrice, @StockAmount)", _connection);
            command.Parameters.AddWithValue("@Name", newProduct.Name);
            command.Parameters.AddWithValue("@UnitPrice", newProduct.UnitPrice);
            command.Parameters.AddWithValue("@StockAmount", newProduct.StockAmount);
            command.ExecuteNonQuery();
            
            _connection.Close();
        }

        public void Update(Product updatedProduct)
        {
            ConnectionControl();
            NpgsqlCommand command = new NpgsqlCommand(
                "Update public.\"Products\" SET \"Name\"=@Name, \"UnitPrice\"=@UnitPrice, \"StockAmount\"=@StockAmount WHERE \"Id\" = @Id", _connection);
            command.Parameters.AddWithValue("@Name", updatedProduct.Name);
            command.Parameters.AddWithValue("@UnitPrice", updatedProduct.UnitPrice);
            command.Parameters.AddWithValue("@StockAmount", updatedProduct.StockAmount);
            command.Parameters.AddWithValue("@Id", updatedProduct.Id);
            int rowsAffected = command.ExecuteNonQuery();
            
            if (rowsAffected == 0)
            {
                Console.WriteLine("No rows were updated. Check if the Id exists. ID: {0}", updatedProduct.Id);
            }
            
            _connection.Close();
        }
        
        public void Delete(int id)
        {
            ConnectionControl();
            NpgsqlCommand command = new NpgsqlCommand(
                "Delete from public.\"Products\" WHERE \"Id\" = @Id", _connection);
            
            command.Parameters.AddWithValue("@Id", id);
            int rowsAffected = command.ExecuteNonQuery();
            
            if (rowsAffected == 0)
            {
                Console.WriteLine("No rows were deleted. Check if the Id exists. ID: {0}", id);
            }
            
            _connection.Close();
            
        }
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}

