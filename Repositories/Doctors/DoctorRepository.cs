using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.Doctors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Doctors;

public class DoctorRepository : BaseRepository, IDoctorRepository
{
    public async Task<int> CountDoctor()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from doctors_view;";
            await using (var command = new NpgsqlCommand(query,_connection)) 
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
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Doctor obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.doctors(name, surname, is_male, adress, tel_number, date_birth, department_id, rooms_id, description, medical_education_image_path, higher_education_image_path, passport_image_path, created_at, updated_at)" +
                "VALUES (@name, @surname, @is_male, @adress, @tel_number, @date_birth, @department_id, @rooms_id, @description, @medical_education_image_path, @higher_education_image_path, @passport_image_path, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("surname", obj.surname);
                command.Parameters.AddWithValue("is_male", obj.is_male);
                command.Parameters.AddWithValue("adress", obj.adress);
                command.Parameters.AddWithValue("tel_number", obj.tel_number);
                command.Parameters.AddWithValue("date_birth", obj.date_birth);
                command.Parameters.AddWithValue("department_id", obj.department_id);
                command.Parameters.AddWithValue("rooms_id", obj.rooms_id);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("medical_education_image_path", obj.medical_education_image_path);
                command.Parameters.AddWithValue("higher_education_image_path", obj.higher_education_image_path);
                command.Parameters.AddWithValue("passport_image_path", obj.Passport_Image_Path);
                command.Parameters.AddWithValue("created_at", obj.created_at);
                command.Parameters.AddWithValue ("updated_at", obj.updated_at);
                

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

    public async Task<IList<DoctorsViewModel>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from doctors_view order by id " +
                $"offset {(@params.PageNumber - 1) * @params.PageSize} " +
                $"limit {@params.PageSize}";
            List<DoctorsViewModel> doctorsViewModels = new List<DoctorsViewModel>();
            await using (var command= new NpgsqlCommand(query,_connection))
            {
                await using (var reader= await  command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        var obj = new DoctorsViewModel();
                        obj.Id = reader.GetInt64(0);
                        obj.name=reader.GetString(1);
                        obj.surname=reader.GetString(2);
                        obj.is_male=reader.GetBoolean(3);
                        obj.adress=reader.GetString(4);
                        obj.tel_number=reader.GetString(5);
                        obj.date_birth = reader.GetFieldValue<DateOnly>(6);
                        obj.department=reader.GetString(7);
                        obj.room = reader.GetInt32(8);
                        obj.description=reader.GetString(9);
                        obj.created_at=reader.GetDateTime(10);
                        obj.updated_at=reader.GetDateTime(11);
                        obj.passport_image_path=reader.GetString(12);

                        doctorsViewModels.Add(obj);

                    }
                }
            }
                return doctorsViewModels;
        }
        catch 
        {
            return new List<DoctorsViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<DoctorsViewModel> GetAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from doctors_view where id=@id;";
            DoctorsViewModel viewModel = new DoctorsViewModel();
            await using ( var command = new NpgsqlCommand(query ,_connection))
            {
                command.Parameters.AddWithValue("id", id);
                await using ( var reader  = command.ExecuteReader()) 
                {
                    if (await reader.ReadAsync())
                    {
                        
                        viewModel.Id = reader.GetInt64(0);
                        viewModel.name = reader.GetString(1);
                        viewModel.surname = reader.GetString(2);
                        viewModel.is_male=reader.GetBoolean(3);
                        viewModel.adress = reader.GetString(4);
                        viewModel.tel_number = reader.GetString(5);
                        viewModel.date_birth= reader.GetFieldValue<DateOnly>(6);
                        viewModel.department = reader.GetString(7);
                        viewModel.room = reader.GetInt32(8);
                        viewModel.description = reader.GetString(9);
                        viewModel.created_at = reader.GetDateTime(10);
                        viewModel.updated_at = reader.GetDateTime(11);
                        viewModel.passport_image_path = reader.GetString(12);

                    }
                }
            }
            return viewModel;

        }
        catch 
        {
            return new DoctorsViewModel();
        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<int> UpdateAsync(long id, Doctor editObj)
    {
        throw new NotImplementedException();
    }
}
