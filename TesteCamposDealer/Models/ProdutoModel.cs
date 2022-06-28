using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteCamposDealer.Models
{
    public class ProdutoModel
    {
        private readonly static string _conn = @"Data Source=THAÍS\MSSQLSERVER01;
        Initial Catalog=LeonardoTeste;
        Integrated Security=True;
        Connect Timeout=30;
        Encrypt=False;
        TrustServerCertificate=False;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False;
        MultipleActiveResultSets=true";
        public int? idProduto { get; set; }

        public string? dscProduto { get; set; }

        public float? vlrUnitario { get; set; }

        public ProdutoModel() { }

        public ProdutoModel(int id, string produto, float vlrunitario)
        {
            idProduto = id;
            dscProduto = produto;
            vlrUnitario = vlrunitario;
        }

        public static List<ProdutoModel> GetProdutoModel()
        {
            var listaprodutos = new List<ProdutoModel>();
            var sql = "SELECT * FROM Produtos";

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaprodutos.Add(new ProdutoModel(
                                        Convert.ToInt32(dr["idProduto"]),
                                        dr["dscProduto"].ToString(),
                                        Convert.ToSingle(dr["vlrUnitario"])
                                    ));
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return listaprodutos;
        }

        public void Criar()
        {
            using (var cn = new SqlConnection(_conn))
            {
                try
                {
                    cn.Open();
                    var sql = "";
                    sql = "SELECT MAX(idProduto) FROM produtos";
                    var cmd = new SqlCommand(sql, cn);
                    var rl = Convert.ToInt32(cmd.ExecuteScalar());
                    var id = rl + 1;
                    if (idProduto == 0)
                    {
                        sql = $"insert produtos values ({id}, @dscProduto, @vlrUnitario)";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@idProduto", id);
                            cmd.Parameters.AddWithValue("@dscProduto", dscProduto);
                            cmd.Parameters.AddWithValue("@vlrUnitario", vlrUnitario);

                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                    else
                    {
                        sql = "update produtos set dscProduto=@dscProduto, vlrUnitario=@vlrUnitario where idProduto=@idProduto";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@idProduto", idProduto);
                            cmd.Parameters.AddWithValue("@dscProduto", dscProduto);
                            cmd.Parameters.AddWithValue("@vlrUnitario", vlrUnitario);

                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha: " + ex.Message);
                }
            }
        }

        public void GetProdutoModel(int Id)
        {
            var sql = "select * from produtos where idProduto=" + Id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    idProduto = Convert.ToInt32(dr["idProduto"]);
                                    dscProduto = dr["dscProduto"].ToString();
                                    vlrUnitario = Convert.ToSingle(dr["vlrUnitario"]);
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void Deletar()
        {
            using (var cn = new SqlConnection(_conn))
            {
                try
                {
                    cn.Open();
                    var sql = "delete produtos where idProduto=@idProduto";
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);

                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha: " + ex.Message);
                }
            }
        }
    }
}