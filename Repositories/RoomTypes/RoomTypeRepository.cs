using Hospital_managment_system.Entities.RoomTypes;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Hospital_managment_system.Repositories.RoomTypes;

public class RoomTypeRepository : BaseRepository, IRoomTypesRepository
{
    public async Task<int> BedroomCount()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from bed_rooms_view ;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync()) 
                {
                    int result = 0;
                    if (await  reader.ReadAsync())
                    {
                        result = reader.GetInt32(0);
                    }
                    return result;
                }
            }
        }
        catch 
        {
            return 0;               
        }finally { await _connection.CloseAsync(); }
    }

    public async Task<int> CreateAsync(RoomType obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.room_type(name, cost, created_at, updated_at) " +
                "VALUES (@name, @cost, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("cost", obj.cost);
                command.Parameters.AddWithValue("created_at", obj.created_at);
                command.Parameters.AddWithValue("updated_at", obj.updated_at);

                var result = await command.ExecuteNonQueryAsync();
                return result;
            }
        }
        catch 
        {
            return 0;
            
        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FreeBedroomCount()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(is_free) from bed_rooms_view where is_free=true;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    int result = 0;
                    if (await reader.ReadAsync())
                    {
                        result = reader.GetInt32(0);
                    }
                    return result;
                }
            }
        }
        catch
        {
            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<IList<RoomType>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from room_type;";
            List<RoomType> roomTypes = new List<RoomType>();
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync()) 
                {
                    while(await  reader.ReadAsync())
                    {
                        RoomType roomType = new RoomType();
                        roomType.Id = reader.GetInt64(0);
                        roomType.name = reader.GetString(1);
                        roomType.cost=reader.GetFloat(2);
                        roomType.created_at=reader.GetDateTime(3);
                        roomType.updated_at = reader.GetDateTime(4);

                        roomTypes.Add(roomType);
                    }
                }
            }
                        return roomTypes;
        }
        catch 
        {
            return  new List<RoomType>();            
        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<RoomType> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, RoomType editObj)
    {
        throw new NotImplementedException();
    }
}
