using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TesteCamposDealer.Models
{
    public class VendaModel
    {
        private readonly static string _conn = @"Data Source=THAÍS\MSSQLSERVER01;
        Initial Catalog=LeonardoTeste;
        Integrated Security=True;
        Connect Timeout=30;
        Encrypt=False;
        TrustServerCertificate=False;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False;
        MultipleActiveResultSets=true";
        public int idVenda { get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public int? idCliente { get; set; }

        [Required(ErrorMessage = "O Produto é obrigatório.")]
        public int? idProduto { get; set; }

        [Required(ErrorMessage = "A Quantidade é obrigatório.")]
        public int? qtdVenda { get; set; }

        [Required(ErrorMessage = "O Valor Unitario é obrigatório.")]
        public float? vlrUnitarioVenda { get; set; }

        public DateTime? dthVenda { get; set; }

        public float? vlrTotalVenda { get; set; }

        public VendaModel() { }

        public VendaModel(int venda, int cliente, int produto, int quantiade, float valorunitario, DateTime datavenda, float valortotal)
        {
            idVenda = venda;
            idCliente = cliente;
            idProduto = produto;
            qtdVenda = quantiade;
            vlrUnitarioVenda = valorunitario;
            dthVenda = datavenda;
            vlrTotalVenda = valortotal;
        }

        public static List<VendaModel> GetVendaModel()
        {
            var listavendas = new List<VendaModel>();
            var sql = "SELECT * FROM vendas";

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
                                    listavendas.Add(new VendaModel(
                                        Convert.ToInt32(dr["idVenda"]),
                                        Convert.ToInt32(dr["idCliente"]),
                                        Convert.ToInt32(dr["idProduto"]),
                                        Convert.ToInt32(dr["qtdVenda"]),
                                        Convert.ToSingle(dr["vlrUnitarioVenda"]),
                                        Convert.ToDateTime(dr["dthVenda"]),
                                        Convert.ToSingle(dr["vlrTotalVenda"])
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
            return listavendas;
        }

        public void Criar()
        {
            using (var cn = new SqlConnection(_conn))
            {
                try
                {
                    cn.Open();
                    var sql = "";
                    sql = "SELECT MAX(idVenda) FROM vendas";
                    var cmd = new SqlCommand(sql, cn);
                    var rl = Convert.ToInt32(cmd.ExecuteScalar());
                    var id = rl + 1;
                    if (idVenda == 0)
                    {
                        sql = $"insert vendas values ({id}, @idCliente, @idProduto, @qtdVenda, @vlrUnitarioVenda, @dthVenda, @vlrTotalVenda)";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@idVenda", id);
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@idProduto", idProduto);
                            cmd.Parameters.AddWithValue("@qtdVenda", qtdVenda);
                            cmd.Parameters.AddWithValue("@vlrUnitarioVenda", vlrUnitarioVenda);
                            cmd.Parameters.AddWithValue("@dthVenda", DateTime.Now);
                            cmd.Parameters.AddWithValue("@vlrTotalVenda", qtdVenda * vlrUnitarioVenda);

                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                    else
                    {
                        sql = "update vendas set idCliente=@idCliente, idProduto=@idProduto, qtdVenda=@qtdVenda, " +
                            "vlrUnitarioVenda=@vlrUnitarioVenda, dthVenda=@dthVenda, vlrTotalVenda=@vlrTotalVenda where idVenda=@idVenda";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            var a = qtdVenda * vlrUnitarioVenda;
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@idProduto", idProduto);
                            cmd.Parameters.AddWithValue("@qtdVenda", qtdVenda);
                            cmd.Parameters.AddWithValue("@vlrUnitarioVenda", vlrUnitarioVenda);
                            cmd.Parameters.AddWithValue("@dthVenda", DateTime.Now);
                            cmd.Parameters.AddWithValue("@vlrTotalVenda", qtdVenda * vlrUnitarioVenda);
                            cmd.Parameters.AddWithValue("@idVenda", idVenda);

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

        public void GetVendaModel(int Id)
        {
            var sql = "select * from vendas where idVenda=" + Id;
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
                                    idVenda = Convert.ToInt32(dr["idVenda"]);
                                    idCliente = Convert.ToInt32(dr["idCliente"]);
                                    idProduto = Convert.ToInt32(dr["idProduto"]);
                                    qtdVenda = Convert.ToInt32(dr["qtdVenda"]);
                                    vlrUnitarioVenda = Convert.ToSingle(dr["vlrUnitarioVenda"]);
                                    dthVenda = Convert.ToDateTime(dr["dthVenda"]);
                                    vlrTotalVenda = Convert.ToSingle(dr["vlrTotalVenda"]);

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
                    var sql = "delete vendas where idVenda=@idVenda";
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@idVenda", idVenda);

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
