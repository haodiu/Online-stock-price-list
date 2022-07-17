using BangGiaChungKhoan.Models;
using System.Data;
using System.Data.SqlClient;

namespace BangGiaChungKhoan.Repositories
{
    public class BangGiaRepository
    {
        string connectionString;
        public BangGiaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<BANGGIATRUCTUYEN> GetPrices()
        {
            List<BANGGIATRUCTUYEN> Prices = new List<BANGGIATRUCTUYEN>();
            BANGGIATRUCTUYEN price;
            var data = GetDataFromDb();
            foreach (DataRow row in data.Rows)
            {
                price = new BANGGIATRUCTUYEN();
                {
                    price.MACK = row["MACK"].ToString();
                   
                    price.GIAMUABA = row["GIAMUABA"].ToString(); 
                    price.SOLUONGMUABA = row["SOLUONGMUABA"].ToString();
                    
                    price.GIAMUAHAI = row["GIAMUAHAI"].ToString(); 
                    price.SOLUONGMUAHAI = row["SOLUONGMUAHAI"].ToString();

                    price.GIAMUAMOT = row["GIAMUAMOT"].ToString(); 
                    price.SOLUONGMUAMOT = row["SOLUONGMUAMOT"].ToString();

                    price.GIAKHOPTRUCTUYEN = row["GIAKHOPTRUCTUYEN"].ToString();
                    price.SOLUONGKHOPTRUCTUYEN = row["SOLUONGKHOPTRUCTUYEN"].ToString();

                    price.GIABANMOT = row["GIABANMOT"].ToString(); 
                    price.SOLUONGBANMOT = row["SOLUONGBANMOT"].ToString();

                    price.GIABANHAI = row["GIABANHAI"].ToString();
                    price.SOLUONGBANHAI = row["SOLUONGBANHAI"].ToString();

                    price.GIABANBA = row["GIABANBA"].ToString();
                    price.SOLUONGBANBA = row["SOLUONGBANBA"].ToString();

                    price.TONGSOLUONG = row["TONGSOLUONG"].ToString();
                };
                Prices.Add(price);
            }
            return Prices;
        }
        public DataTable GetDataFromDb()
        {
            var query = "SELECT * FROM BANGGIATRUCTUYEN";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    return dataTable;
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
