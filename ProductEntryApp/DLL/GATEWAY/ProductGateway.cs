using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntryApp.DLL.DAO;

namespace ProductEntryApp.DLL.GATEWAY
{
    class ProductGateway
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static string query;

        public ProductGateway()
        {
            string conn = ConfigurationManager.ConnectionStrings["ProductEntry"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }

        public string Save(Product aProduct)
        {
            connection.Open();
            query = string.Format("INSERT INTO t_StoreProduct VALUES ('{0}', '{1}', '{2}')", aProduct.ProductCode, aProduct.Name, aProduct.Quantity);
            command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
            {
                return "Insert success";
            }
            else
            {
                return "Some problem happened";
            }
        }

        public List<Product> GetAllProduct()
        {
            connection.Open();
            query = String.Format("SELECT * FROM t_StoreProduct");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> productNameList = new List<Product>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.ProductId = (int) aReader[0];
                    aProduct.ProductCode = aReader[1].ToString();
                    aProduct.Name = aReader[2].ToString();
                    aProduct.Quantity =  (double) aReader[3];
                    productNameList.Add(aProduct);                                  
                }
            }
            connection.Close();
            return productNameList;
        }
    }
}
