using Hospital_managment_system.Entities.BedPatients;
using Hospital_managment_system.Interfaces;
using Hospital_managment_system.Interfaces.Bed_patients;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.BedPatientsV;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Bed_patients;

public class Bed_patientsRepository : BaseRepository, IBed_PatientsRepository
{
    public async Task<int> CreateAsync(BedPatient obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.bed_patients(name, surname, date_birth, adress, is_male, tel_number, come_time, leave_time, bed_room_id, description, allergies, where_come_from, created_at, updated_at)" +
                "VALUES (@name, @surname, @date_birth, @adress, @is_male, @tel_number, @come_time, @leave_time, @bed_room_id, @description, @allergies, @where_come_from, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("surname", obj.surname);
                command.Parameters.AddWithValue("date_birth", obj.date_birth);
                command.Parameters.AddWithValue("adress", obj.adress);
                command.Parameters.AddWithValue("is_male", obj.is_male);
                command.Parameters.AddWithValue("tel_number", obj.tel_number);
                command.Parameters.AddWithValue("come_time", obj.come_time);
                command.Parameters.AddWithValue("leave_time", obj.leave_date);
                command.Parameters.AddWithValue("bed_room_id", obj.bed_room_id);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("allergies", obj.allergies);
                command.Parameters.AddWithValue("where_come_from", obj.where_come_from);
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

    public async Task<IList<BedPatientsViewModel>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from bed_patients_view;";
            List<BedPatientsViewModel> list = new List<BedPatientsViewModel>();
            await using ( var command= new NpgsqlCommand(query,_connection) )
            {
                await using(var reader = await  command.ExecuteReaderAsync())
                {
                    while (await  reader.ReadAsync())
                    {
                        BedPatientsViewModel obj = new BedPatientsViewModel();
                        obj.Id = reader.GetInt64(0);
                        obj.name = reader.GetString(1);
                        obj.surname = reader.GetString(2);
                        obj.date_birth = reader.GetFieldValue<DateOnly>(3);
                        obj.adress=reader.GetString(4);
                        obj.is_male=reader.GetBoolean(5);
                        obj.tel_number = reader.GetString(6);
                        obj.comeTime=reader.GetDateTime(7);
                        obj.leaveTime=reader.GetDateTime(8);
                        obj.room_number=reader.GetInt32(9);
                        obj.description=reader.GetString(10);
                        obj.allergies = reader.GetString(11);
                        obj.where_come_from=reader.GetString(12);
                        
                        list.Add(obj);


                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<BedPatientsViewModel>();

        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<BedPatientsViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, BedPatient editObj)
    {
        throw new NotImplementedException();
    }
}
