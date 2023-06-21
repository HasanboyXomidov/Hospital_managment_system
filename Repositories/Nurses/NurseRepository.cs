using Hospital_managment_system.Constants;
using Hospital_managment_system.Entities.Nurses;
using Hospital_managment_system.Interfaces.Nurses;
using Hospital_managment_system.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Nurses;

public class NurseRepository :BaseRepository, INurseRepository
{
    // Counting nurses
    public async Task<int> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from nurses;";
            await using ( var command = new NpgsqlCommand(query,_connection) )
            {
                int count = await command.ExecuteNonQueryAsync();
                return count;
            }
        }
        catch 
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> CreateAsync(Nurse obj)
    {
        
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.nurses(name, surname, date_birth, adress, tel_number, is_male, passport_path, salary, description, created_at, updated_at)" +
                "VALUES ( @name, @surname, @date_birth, @adress, @tel_number, @is_male, @passport_path, @salary, @description, @created_at, @updated_at);";
            await using ( var command = new NpgsqlCommand(query, _connection) )
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("surname", obj.surname);
                command.Parameters.AddWithValue("date_birth", obj.date_birth);
                command.Parameters.AddWithValue("adress", obj.adress);
                command.Parameters.AddWithValue("tel_number", obj.tel_number);
                command.Parameters.AddWithValue("is_male", obj.is_male);
                command.Parameters.AddWithValue("passport_path", obj.Passport_Image_Path);
                command.Parameters.AddWithValue("salary", obj.salary);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("created_at", obj.created_at);
                command.Parameters.AddWithValue("updated_at", obj.updated_at);

                var db_result = await command.ExecuteNonQueryAsync();
                return db_result;
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
    // deleting nurses by id 
    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "delete from nurses where id=@id";
            await using(var command = new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("id", id);
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

    public Task<IList<Nurse>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
    }

    public async Task<Nurse> GetAsync(long id)
    {
         try
        {
            await _connection.OpenAsync();
            string query = "select * from nurses where id=@id;";
            Nurse nurse = new Nurse();
            await using (var command= new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", id);
                await using ( var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        
                        nurse.name=reader.GetString(1);
                        nurse.surname=reader.GetString(2);
                        var fourthcolumn = reader.GetFieldValue<DateOnly>(3);
                        nurse.date_birth = fourthcolumn;
                        nurse.adress = reader.GetString(4);
                        nurse.tel_number = reader.GetString(5);
                        nurse.is_male=reader.GetBoolean(6);
                        nurse.Passport_Image_Path = reader.GetString(7);
                        nurse.salary=reader.GetFloat(8);
                        nurse.description=reader.GetString(9);
                        nurse.created_at=reader.GetDateTime(10);
                        nurse.updated_at = reader.GetDateTime(11);

                        
                    }
                }                                
            }
            return nurse;
        }
        catch 
        {
            return new Nurse();
        }
        finally { await _connection.CloseAsync(); }
    }

    

    public Task<int> UpdateAsync(long id, Nurse editObj)
    {
        throw new NotImplementedException();
    }

}
