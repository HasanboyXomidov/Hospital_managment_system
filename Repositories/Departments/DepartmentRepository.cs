using Hospital_managment_system.Constants;
using Hospital_managment_system.Entities.Departments;
using Hospital_managment_system.Interfaces.Departments;
using Hospital_managment_system.Utilities;
using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Departments;

public  class DepartmentRepository : BaseRepository, IDepartmentRepository
{

    public DepartmentRepository()
    {

    }
    public async Task<int> CreateAsync(Entities.Departments.Department obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO department(name, is_active, description, created_at, updated_at)" +
                "VALUES (@name, @is_active, @description, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("is_active", obj.is_active);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("created_at", obj.created_at);
                command.Parameters.AddWithValue("updated_at", obj.updated_at);

                int result = await command.ExecuteNonQueryAsync();
                return result;
            }
        }
        catch 
        {
            return 0;   
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Entities.Departments.Department>> GetAllAsync(Paginations @params)
    {

        try
        {
            var list = new List<Department>();
            await _connection.OpenAsync();
            string query = $"select * from department order by id " +
                $"offset {(@params.PageNumber-1)*@params.PageSize} " +
                $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.Id = reader.GetInt64(0);
                        department.name = reader.GetString(1);
                        department.is_active = reader.GetBoolean(2);
                        department.description=reader.GetString(3);
                        department.created_at= reader.GetDateTime(4);
                        department.updated_at=reader.GetDateTime(5);
                        list.Add(department);
                    }
                }
            }
            return list;
            
        }
        catch
        {
            return new List<Department>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Entities.Departments.Department> GetAsync(long id)
    {
        throw new NotImplementedException();
    }



    public async Task<int> GetTotalDepartment()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from department;";
            await using(var command = new NpgsqlCommand(query,_connection))
            {
                int count = 0;
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                       count = reader.GetInt32(0);
                        
                    }
                }
                
                return count;
            }
        }
        catch
        {
            return 0;           
        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<int> UpdateAsync(long id, Entities.Departments.Department editObj)
    {
        throw new NotImplementedException();
    }
}
