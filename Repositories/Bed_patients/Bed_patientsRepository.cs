using Hospital_managment_system.Entities.BedPatients;
using Hospital_managment_system.Interfaces.Bed_patients;
using Hospital_managment_system.Utilities;
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
            await using ( var command = new NpgsqlCommand(query,_connection) )
            {
                command.Parameters.AddWithValue("name",obj.name);
                command.Parameters.AddWithValue("name", obj.surname);
                command.Parameters.AddWithValue("name", obj.date_birth);
                command.Parameters.AddWithValue("name", obj.adress);
                command.Parameters.AddWithValue("name", obj.is_male);
                command.Parameters.AddWithValue("name", obj.tel_number);
                command.Parameters.AddWithValue("name", obj.come_time);
                command.Parameters.AddWithValue("name", obj.leave_date);
                command.Parameters.AddWithValue("name", obj.bed_room_id);
                command.Parameters.AddWithValue("name", obj.description);
                command.Parameters.AddWithValue("name", obj.allergies);
                command.Parameters.AddWithValue("name", obj.where_come_from);
                command.Parameters.AddWithValue("name", obj.created_at);
                command.Parameters.AddWithValue("name", obj.updated_at);

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

    public Task<IList<BedPatient>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
    }

    public Task<BedPatient> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, BedPatient editObj)
    {
        throw new NotImplementedException();
    }
}
