using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using Formulario.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Formulario.Infraestructure.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly string _connection;

        public TestRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<Registro> AddRecord(RegistroDTO registro)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarRegistro", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstname", registro.firstname);
                        cmd.Parameters.AddWithValue("@lastname", registro.lastname);

                        await con.OpenAsync();
                        int rownumber = await cmd.ExecuteNonQueryAsync();
                        if (rownumber > 0)
                        {
                            using (SqlCommand cmd2 = new SqlCommand("ConsultarUltimoRegistro", con))
                            {
                                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                                using (SqlDataReader dr = await cmd2.ExecuteReaderAsync())
                                {
                                    if (await dr.ReadAsync())
                                    {
                                        Registro reg = new Registro();
                                        reg.firstname = dr["firstname"].ToString().Trim();
                                        reg.lastname = dr["lastname"].ToString().Trim();
                                        reg.id = int.Parse(dr["id"].ToString().Trim());
                                        return reg;
                                    }
                                }
                            }
                        }
                        return null;

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<List<Registro>> GetRecords()
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ListaRegistros", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        await con.OpenAsync();
                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            List<Registro> lstReg = new List<Registro>();
                            while (await dr.ReadAsync())
                            {
                                Registro reg = new Registro();
                                reg.id = int.Parse(dr["id"].ToString());
                                reg.firstname = dr["firstname"].ToString();
                                reg.lastname = dr["lastname"].ToString();

                                lstReg.Add(reg);
                            }
                            return lstReg;
                        }
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<bool> DeleteRecord(int id)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarRegistro", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                        
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
