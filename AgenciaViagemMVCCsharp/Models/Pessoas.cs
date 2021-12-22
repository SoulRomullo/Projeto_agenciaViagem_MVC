using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AgenciaViagemMVCCsharp.Models
{
    public class Pessoas
    {
        private readonly static string _conn =
        WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int Id { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "CPF:")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string Cpf { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone:")]
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "Cupom:")]
        [Required(ErrorMessage = "O cupom é obrigatório.")]
        public string Cupom { get; set; }

        public Pessoas() { }

        public Pessoas(int id, string nome, string cpf, string endereco, string telefone, string cupom)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Cupom = cupom;
        }

        public static List<Pessoas> GetDados()
        {
            var listaDados = new List<Pessoas>();
            var sql = "SELECT * FROM Usuario";

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
                                    listaDados.Add(new Pessoas(
                                        Convert.ToInt32(dr["ID"]),
                                        dr["nome"].ToString(),
                                        dr["cpf"].ToString(),
                                        dr["endereco"].ToString(),
                                        dr["telefone"].ToString(),
                                        dr["cupom"].ToString()
                                        ));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return listaDados;
        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO Usuario (nome, cpf, endereco, telefone, cupom) VALUES (@nome, @cpf, @endereco, @telefone, @cupom)";
            }
            else
            {
                sql = "UPDATE Usuario SET nome=@nome, cpf=@cpf, endereco=@endereco, telefone=@telefone, cupom=@cupom WHERE id=" + Id;
            }

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@cpf", Cpf);
                        cmd.Parameters.AddWithValue("@endereco", Endereco);
                        cmd.Parameters.AddWithValue("@telefone", Telefone);
                        cmd.Parameters.AddWithValue("@cupom", Cupom);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void Excluir()
        {
            var sql = "DELETE FROM Usuario WHERE id=" + Id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using(var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void GetPessoas(int id)
        {
            var sql = "SELECT nome, cpf, endereco, telefone, cupom FROM Usuario WHERE id=" + id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using(var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    Id = id;
                                    Nome = dr["nome"].ToString();
                                    Cpf = dr["cpf"].ToString();
                                    Endereco = dr["endereco"].ToString();
                                    Telefone = dr["telefone"].ToString();
                                    Cupom = dr["cupom"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Nome = "Falha: " + ex.Message;
                Console.WriteLine("Falha: " + ex.Message);
            }
        }
    }
}