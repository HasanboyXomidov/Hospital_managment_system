using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.Enums.RoomTypes;
using Hospital_managment_system.Interfaces.BedRooms;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.BedRooms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital_managment_system.Repositories.BedRooms;

public class BedRoomRepository : BaseRepository,IBedRoomsRepository
{
    public async Task<int> CreateAsync(BedRoom bedRooms)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.bed_rooms(name, room_type_id, capacity, is_free, description, created_at, updated_at, room_number)" +
                "VALUES (@name, @room_type_id, @capacity, @is_free, @description, @created_at, @updated_at, @room_number);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", bedRooms.Name);
                command.Parameters.AddWithValue("room_type_id", bedRooms.room_type_id);
                command.Parameters.AddWithValue("capacity", bedRooms.capacity);
                command.Parameters.AddWithValue("is_free", bedRooms.is_empty);
                command.Parameters.AddWithValue("description", bedRooms.description);
                command.Parameters.AddWithValue("created_at", bedRooms.created_at);
                command.Parameters.AddWithValue("updated_at", bedRooms.updated_at);
                command.Parameters.AddWithValue("room_number",bedRooms.room_number);

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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "delete from bed_rooms " +
                "where id = @id;";
            await using ( var command = new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("id", id);
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
 
    // using bed_rooms_view !!!!
    //public async Task<IList<BedRoomsViewModel>> GetAllByRoomNumber(int room_number)
    //{
    //    try
    //    {
    //        List<BedRoomsViewModel> list = new List<BedRoomsViewModel>();
    //        await _connection.OpenAsync();
    //        string query = "select * from bed_rooms_view " +
    //            "where room_number=@room_number;";
    //        await using (var command = new NpgsqlCommand (query,_connection)) 
    //        {
    //            command.Parameters.AddWithValue("room_number",room_number);
    //            await using (var reader = command.ExecuteReader())
    //            {
    //                while (await reader.ReadAsync()) 
    //                {
    //                    BedRoomsViewModel viewModel = new BedRoomsViewModel();
    //                    viewModel.Id = reader.GetInt64(0);
    //                    viewModel.name = reader.GetString(1);
    //                    // enum ni bazadan uqish tekshirib olish kerak 
    //                    string a= reader.GetString(2);
    //                    var moodString = reader.GetFieldValue<string>(a);
    //                    var mood = (RoomTypeEnum)Enum.Parse(typeof(RoomTypeEnum), moodString, true);

    //                    viewModel.room_type = mood;
    //                    viewModel.Room_cost = reader.GetFloat(3);
    //                    viewModel.room_number = reader.GetInt32(4);
    //                    viewModel.capacity = reader.GetInt32(5);
    //                    viewModel.is_free = reader.GetBoolean(6);
    //                    viewModel.description = reader.GetString(7);
    //                    viewModel.created_at = reader.GetDateTime(8);
    //                    viewModel.updated_at = reader.GetDateTime(9);
                        
    //                    list.Add(viewModel);                        
    //                }
    //            }
    //        }
    //        return list;
    //    }
    //    catch 
    //    {
    //        return new List<BedRoomsViewModel>();
    //    }
    //    finally { await _connection.CloseAsync(); }

    //}

    public async Task<IList<BedRoomsViewModel>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            List<BedRoomsViewModel> list = new List<BedRoomsViewModel>();
            string query = "select * from bed_rooms_view order by id " +
                $"offset {(@params.PageNumber-1)*@params.PageSize} " +
                $"limit {@params.PageSize}";

            await using ( var command = new NpgsqlCommand(query,_connection) )
            {
                await using (var reader = command.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        BedRoomsViewModel viewModel = new BedRoomsViewModel();
                        viewModel.Id = reader.GetInt64(0);
                        viewModel.name = reader.GetString(1);                                                
                        viewModel.room_type = reader.GetString(2);
                        viewModel.Room_cost = reader.GetFloat(3);
                        viewModel.room_number = reader.GetInt32(4);
                        viewModel.capacity = reader.GetInt32(5);
                        viewModel.is_free = reader.GetBoolean(6);
                        viewModel.description = reader.GetString(7);
                        viewModel.created_at = reader.GetDateTime(8);
                        viewModel.updated_at = reader.GetDateTime(9);

                        list.Add(viewModel);
                    }
                }
            }
            return list;
        }
        catch 
        {
            return new List<BedRoomsViewModel>();

        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<BedRoomsViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, BedRoom ob)
    {
        try 
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.bed_rooms " +
                "SET name=@name, room_type_id=@room_type_id, capacity=@capacity, is_free=@is_free, description=@description, created_at=@created_at, updated_at=@updated_at, room_number=@room_number " +
                "WHERE id=@id;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name",ob.Name );
                command.Parameters.AddWithValue("room_type_id", ob.room_type_id);
                command.Parameters.AddWithValue("capacity", ob.capacity);
                command.Parameters.AddWithValue("is_free", ob.is_empty);
                command.Parameters.AddWithValue("description", ob.description);
                command.Parameters.AddWithValue("created_at", ob.created_at);
                command.Parameters.AddWithValue("updated_at", ob.updated_at);
                command.Parameters.AddWithValue("room_number", ob.room_number);
                command.Parameters.AddWithValue("id", id);

                var result = await command.ExecuteNonQueryAsync();
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

    
}
