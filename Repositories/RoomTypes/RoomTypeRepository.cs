using Hospital_managment_system.Entities.RoomTypes;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.RoomTypes;

public class RoomTypeRepository : BaseRepository, IRoomTypes
{
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

    public Task<IList<RoomType>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
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
