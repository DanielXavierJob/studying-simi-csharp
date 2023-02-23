using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Simi.DB
{
    public class Conn
    {
        private static string Host = ""; //host
        private static string User = ""; //USERNAME
        private static string DBname = ""; //DB NAME
        private static string Password = ""; //PASSWORD
        private static string Port = ""; //PORT
        private string connString = String.Format(
                 "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                 Host,
                 User,
                 DBname,
                 Port,
                 Password);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();
        public bool AddManu(string serial, string problema)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO manutencao (serial_key, problema) VALUES (@n1,@n2)", conn))
                {
                    command.Parameters.AddWithValue("n1", serial);
                    command.Parameters.AddWithValue("n2", problema);


                    int nRows = command.ExecuteNonQuery();
                    if (nRows > 0)
                    {
                        using(var comm = new NpgsqlCommand("UPDATE rel_pc SET problema = @n1 WHERE serial_key = @n2", conn))
                        {
                            comm.Parameters.AddWithValue("n1", problema);
                            comm.Parameters.AddWithValue("n2", serial);
                            comm.ExecuteNonQuery();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public DataTable npg(string serial)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();

                using (var command = new NpgsqlCommand("SELECT seccia,tecnico,inspecao,nficha,npatrimonio,problema,solucao,created_at FROM laudos WHERE serial_key = @n1", conn))
                {
                    command.Parameters.AddWithValue("n1", serial);

                    NpgsqlDataAdapter data = new NpgsqlDataAdapter(command);
                    ds.Reset();
                    data.Fill(ds);
                    dt = ds.Tables[0];

                    return dt;
                }
            }
        }
        public bool insertlaudo(string[] Vs)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO laudos (serial_key, seccia, tecnico,inspecao,nficha,npatrimonio,problema,solucao,created_at,updated_at) VALUES (@n1,@n2,@n3,@n4,@n5,@n6,@n7,@n8,@n9,@n10)", conn))
                {
                    command.Parameters.AddWithValue("n1", Vs[0]);
                    command.Parameters.AddWithValue("n2", Vs[1]);
                    command.Parameters.AddWithValue("n3", Vs[2]);
                    command.Parameters.AddWithValue("n4", Vs[3]);
                    command.Parameters.AddWithValue("n5", Vs[4]);
                    command.Parameters.AddWithValue("n6", Vs[5]);
                    command.Parameters.AddWithValue("n7", Vs[6]);
                    command.Parameters.AddWithValue("n8", Vs[7]);
                    command.Parameters.AddWithValue("n9", Vs[8]);
                    command.Parameters.AddWithValue("n10", Vs[9]);

                    int nRows = command.ExecuteNonQuery();
                    if (nRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }
        public DataTable selectManutencao()
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM manutencao", conn))
                {
                    NpgsqlDataAdapter data = new NpgsqlDataAdapter(command);
                    ds.Reset();
                    data.Fill(ds);
                    dt = ds.Tables[0];

                    return dt;

                }

            }
        }
        public bool RetirarManutencao(string serial)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();

                using (var command = new NpgsqlCommand("DELETE FROM manutencao WHERE serial_key =  @n1", conn))
                {
                    command.Parameters.AddWithValue("n1", serial);
                    int nRows = command.ExecuteNonQuery();
                    if (nRows > 0)
                    {
                        using (var comm = new NpgsqlCommand("UPDATE rel_pc SET problema = null WHERE serial_key =  @n1", conn))
                        {
                            comm.Parameters.AddWithValue("n1", serial);
                            command.ExecuteNonQuery();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
            }
        }
        public string[] selectManutencao(string serial)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();

                using (var command = new NpgsqlCommand("SELECT secao,tipo FROM rel_pc WHERE serial_key = @n1", conn))
                {
                    command.Parameters.AddWithValue("n1", serial);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] Data =
                        {
                            reader.GetString(0),
                            reader.GetString(1)
                        };
                        return Data;
                    }

                    reader.Close();
                }

                return null;
            }
        }
        public bool Excluir(string serial)
        {
            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();

                using (var command = new NpgsqlCommand("DELETE FROM manutencao WHERE serial_key =  @n1", conn))
                {
                    command.Parameters.AddWithValue("n1", serial);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Deletado com sucesso de Manutenções.");
                }
                using (var command1 = new NpgsqlCommand("DELETE FROM rel_pc WHERE serial_key =  @n1", conn))
                {
                    command1.Parameters.AddWithValue("n1", serial);
                    command1.ExecuteNonQuery();
                    MessageBox.Show("Deletado com sucesso do Banco de Dados.");

                }
                return true;
            }
        }
        public string[] select(string pesq)
        {

            using (var conn = new NpgsqlConnection(connString))

            {

                conn.Open();
                int num = 0;
                using (var command1 = new NpgsqlCommand("SELECT COUNT(*) FROM manutencao WHERE serial_key = @n1", conn))
                {
                    command1.Parameters.AddWithValue("n1", pesq);
                    var nRows = command1.ExecuteReader();
                    while (nRows.Read())
                    {

                        num = nRows.GetInt16(0);
                    }
                    nRows.Close();
                }
                if (num != 0)
                {

                    using (var command = new NpgsqlCommand("SELECT b.*, f.problema FROM rel_pc as b  INNER JOIN manutencao as f ON b.serial_key = f.serial_key WHERE b.serial_key = @n1", conn))
                    {
                        command.Parameters.AddWithValue("n1", pesq);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            string[] Data =  {
                                reader.GetInt32(0).ToString(),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetString(8),
                                reader.GetString(9),
                                reader.GetString(10),
                                reader.GetString(11),
                                reader.GetString(12),
                                reader.GetString(13),
                                reader.GetString(14),
                                reader.GetString(15)
                                };
                            return Data;
                        }
                        reader.Close();
                    }
                }
                else
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM rel_pc  WHERE serial_key = @n1", conn))
                    {
                        command.Parameters.AddWithValue("n1", pesq);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            string[] Data =  {
                                reader.GetInt32(0).ToString(),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetString(8),
                                reader.GetString(9),
                                reader.GetString(10),
                                reader.GetString(11),
                                reader.GetString(12),
                                reader.GetString(13),
                                reader.GetString(14),
                                null
                                };
                            return Data;
                        }
                        reader.Close();
                    }
                }
                return null;
            }
        }

    }
}
