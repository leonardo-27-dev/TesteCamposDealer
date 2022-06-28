using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteCamposDealer.Models
{
    public class ClienteModel
    {
        private readonly static string _conn = @"Data Source=THAÍS\MSSQLSERVER01;
        Initial Catalog=LeonardoTeste;
        Integrated Security=True;
        Connect Timeout=30;
        Encrypt=False;
        TrustServerCertificate=False;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False;
        MultipleActiveResultSets=true";
        public int? idCliente { get; set; }

        public string? nmCliente { get; set; }

        public string? nmCidade { get; set; }

        public ClienteModel() { }

        public ClienteModel(int id, string cliente, string cidade)
        {
            idCliente = id;
            nmCliente = cliente;
            nmCidade = cidade;
        }

        public static List<ClienteModel> GetClienteModel()
        {
            var listaclientes = new List<ClienteModel>();
            var sql = "SELECT * FROM clientes";

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
                                    listaclientes.Add(new ClienteModel(
                                        Convert.ToInt32(dr["idCliente"]),
                                        dr["nmCliente"].ToString(),
                                        dr["nmCidade"].ToString()
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
            return listaclientes;
        }

        public void Criar()
        {
            using (var cn = new SqlConnection(_conn))
            {
                try
                {
                    cn.Open();
                    var sql = "";
                    sql = "SELECT MAX(idCliente) FROM clientes";
                    var cmd = new SqlCommand(sql, cn);
                    var rl = Convert.ToInt32(cmd.ExecuteScalar());
                    var id = rl + 1;
                    if (idCliente == 0)
                    {
                        sql = $"insert clientes values ({id}, @nmCliente, @nmCidade)";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@idCliente", id);
                            cmd.Parameters.AddWithValue("@nmCliente", nmCliente);
                            cmd.Parameters.AddWithValue("@nmCidade", nmCidade);

                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                    else
                    {
                        sql = "update clientes set nmCliente=@nmCliente, nmCidade=@nmCidade where idCliente=@idCliente";
                        using (cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@nmCliente", nmCliente);
                            cmd.Parameters.AddWithValue("@nmCidade", nmCidade);

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

        public void GetClientes(int Id)
        {
            var sql = "select * from clientes where idCliente=" + Id;
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
                                    idCliente = Convert.ToInt32(dr["idCliente"]);
                                    nmCliente = dr["nmCliente"].ToString();
                                    nmCidade = dr["nmCidade"].ToString();
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
                    var sql = "delete clientes where idCliente=@idCliente";
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

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