using Hospital_managment_system.Entities;
using Hospital_managment_system.Entities.Rooms;
using Hospital_managment_system.Interfaces;
using Hospital_managment_system.Interfaces.Rooms;
using Hospital_managment_system.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Rooms;

public class RoomsRepository : BaseRepository, IRoomsRepository
{
    public RoomsRepository()
    {

    }

    public async Task<int> CreateAsync(OtherRoom obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.rooms(room_number, name, is_free, description, created_at, updated_at)" +
                "VALUES (@room_number, @name, @is_free, @description, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("room_number", obj.room_number);
                command.Parameters.AddWithValue("name", obj.Name);
                command.Parameters.AddWithValue("is_free", obj.is_empty);
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
        finally { await _connection.CloseAsync(); }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<OtherRoom>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from rooms order by id;";
            List<OtherRoom> list = new List<OtherRoom>();
            await using (var command= new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await  command.ExecuteReaderAsync())
                {
                    while(await  reader.ReadAsync())
                    {
                        OtherRoom obj = new OtherRoom();
                        obj.Id = reader.GetInt64(0);
                        obj.room_number = reader.GetInt32(1);
                        obj.name=reader.GetString(2);
                        obj.is_free=reader.GetBoolean(3);
                        obj.description = reader.GetString(4);
                        obj.created_at= reader.GetDateTime(5);
                        obj.updated_at= reader.GetDateTime(6);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<OtherRoom>();            
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<OtherRoom> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<OtherRoom>> GetEmptyRooms(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from rooms " +
                "where is_free=true;";
            List<OtherRoom> otherRooms = new List<OtherRoom>();
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                await using (var reader = await command.ExecuteReaderAsync()) 
                {
                    while( await  reader.ReadAsync() )
                    {
                        OtherRoom obj = new OtherRoom();
                        obj.Id = reader.GetInt64(0);
                        obj.room_number = reader.GetInt32(1);
                        obj.name = reader.GetString(2);
                        obj.is_free=reader.GetBoolean(3);
                        obj.description = reader.GetString(4);
                        obj.created_at = reader.GetDateTime(5);
                        obj.updated_at = reader.GetDateTime(6);
                        
                        otherRooms.Add(obj);
                    }
                }
            }
            return otherRooms;
        }
        catch 
        {
            return new List<OtherRoom>();    
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, OtherRoom editObj)
    {
        throw new NotImplementedException();
    }
}
