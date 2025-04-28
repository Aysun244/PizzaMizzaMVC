using Dapper;
using Microsoft.Data.SqlClient;
using PizzaMizzaMVC.Model;


namespace PizzaMizzaMVC.Repositories
{
    public class PizzaRepository
    {
        private const string connStr = "Server=.\\SQLEXPRESS;Database=PizzaMizzaMVC;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection _conn => new SqlConnection(connStr);

        public List<Pizza> GetAll()
        {
            using (var conn = _conn)
            {
                return conn.Query<Pizza>("SELECT * FROM Pizzas").ToList();
            }
        }

        public Pizza GetById(int id)
        {
            using (var conn = _conn)
            {
                return conn.QueryFirstOrDefault<Pizza>("SELECT * FROM Pizzas WHERE Id = @Id", new { Id = id });
            }
        }

        public List<Ingredient> GetIngredients(int pizzaId)
        {
            using (var conn = _conn)
            {
                return conn.Query<Ingredient>("SELECT * FROM Ingredients WHERE PizzaId = @PizzaId", new { PizzaId = pizzaId }).ToList();
            }
        }

        public void Delete(int id)
        {
            using (var conn = _conn)
            {
                conn.Execute("DELETE FROM Ingredients WHERE PizzaId = @Id", new { Id = id });
                conn.Execute("DELETE FROM Pizzas WHERE Id = @Id", new { Id = id });
            }
        }
    }
}