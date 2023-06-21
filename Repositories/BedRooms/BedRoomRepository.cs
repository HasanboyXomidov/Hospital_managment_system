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

    public Task<IList<BedRoomsViewModel>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
    }

    public Task<BedRoomsViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, BedRoom editObj)
    {
        throw new NotImplementedException();
    }

    
}
