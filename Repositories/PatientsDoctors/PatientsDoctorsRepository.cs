using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Interfaces.BedRooms;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.BedRooms;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.PatientsDoctors;

public class PatientsDoctorsRepository : BaseRepository, IPatientDoctorRepository
{
    public async Task<int> CreateAsync(PatientDoctor obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.patient_doctor(patients_id, doctor_id, patient_queue, cur_date, doctor_exam_cost, description, created_at, updated_at, next_exam)" +
                "VALUES (@patients_id, @doctor_id, @patient_queue, @cur_date, @doctor_exam_cost, @description, @created_at, @updated_at, @next_exam);";            
            await using (var command=new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("patients_id", obj.patient_id);
                command.Parameters.AddWithValue("doctor_id", obj.doctor_id);
                command.Parameters.AddWithValue("patient_queue", obj.patient_queue);
                command.Parameters.AddWithValue("cur_date", obj.cur_date);
                command.Parameters.AddWithValue("doctor_exam_cost", obj.doctor_exam_cost);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("created_at", obj.created_at);
                command.Parameters.AddWithValue("updated_at", obj.updated_at);
                command.Parameters.AddWithValue("next_exam", obj.next_exam_day);

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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM public.patient_doctor " +
                "WHERE id=@id;";
            await using(var command= new NpgsqlCommand(query, _connection))
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
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<PatientDoctorViewModel>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from patient_doctor_view order by id desc;";
            List<PatientDoctorViewModel> list = new List<PatientDoctorViewModel>();
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                await using (var reader = await  command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        PatientDoctorViewModel obj = new PatientDoctorViewModel();
                        obj.id = reader.GetInt64(0);
                        obj.patientfio = reader.GetString(1);
                        obj.gender_age = reader.GetString(2);
                        obj.tel_number = reader.GetString(3);
                        obj.doctorfio = reader.GetString(4);
                        obj.cur_date = reader.GetFieldValue<DateTime>(5);
                        obj.patientQueue = reader.GetInt32(6);
                        obj.doctorExamCost = reader.GetFloat(7);
                        obj.description = reader.GetString(8);
                        obj.next_exam = reader.GetInt32(9);

                        list.Add(obj);

                    }
                }
            }
            return list;
        }
        catch 
        {            
            return new List<PatientDoctorViewModel>();
        }
        finally {  _connection.Close(); }
    }

    public Task<PatientDoctorViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetCurrentQueue(long doctorId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from patient_doctor " +
                "where doctor_id=@id " +
                "and cur_date::date = current_date;";
            await using(var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", doctorId);
                int a = 0;
                await using (var reader = await command.ExecuteReaderAsync()) 
                {
                    if(await  reader.ReadAsync())
                    {
                        a = reader.GetInt32(0); 
                        
                    }
                    return a;
                }

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

    public async Task<IList<PatientDoctorViewModel>> GetNextExamPatients(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM patient_doctor_view " +
                "WHERE cur_date + next_exam = current_date order by id; ";
            List<PatientDoctorViewModel> list = new List<PatientDoctorViewModel>();
            await using(var command=new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        PatientDoctorViewModel obj = new PatientDoctorViewModel();
                        obj.id = reader.GetInt64(0);
                        obj.patientfio = reader.GetString(1);
                        obj.gender_age = reader.GetString(2);
                        obj.tel_number = reader.GetString(3);
                        obj.doctorfio = reader.GetString(4);
                        obj.cur_date = reader.GetFieldValue<DateTime>(5);
                        obj.patientQueue = reader.GetInt32(6);
                        obj.doctorExamCost=reader.GetFloat(7);
                        obj.description = reader.GetString(8);
                        obj.next_exam = reader.GetInt32(9);
                        list.Add(obj);

                    }
                }
            }
            return list;

        }
        catch 
        {
            return new List<PatientDoctorViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> GetTodaysTotalAppointment()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from patient_doctor " +
                "where cur_date::date=current_date;";
            await using(var command = new NpgsqlCommand(query,_connection))
            {
                int a = 0;
                await using (var reader=command.ExecuteReader())
                {
                    if(await reader.ReadAsync())
                    {
                        a=reader.GetInt32(0);
                    }
                }
                return a;
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

    public async Task<int> GetWeeklyAllAppointment()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from patient_doctor " +
                "WHERE cur_date >= date_trunc('week', CURRENT_DATE) " +
                "AND cur_date < date_trunc('week', CURRENT_DATE) + INTERVAL '1 week';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                int a = 0;
                await using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        a = reader.GetInt32(0);
                    }
                }
                return a;
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

    public async Task<int> GetYesterdaysTotalAppointment()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from patient_doctor " +
                "where cur_date='yesterday'::date - '1 day'::interval;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                int a = 0;
                await using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        a = reader.GetInt32(0);
                    }
                }
                return a;
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

    public async Task<int> MonthlyAllAppointments()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from patient_doctor " +
                "WHERE EXTRACT(MONTH FROM cur_date) = EXTRACT(MONTH FROM CURRENT_DATE) " +
                "AND EXTRACT(YEAR FROM cur_date) = EXTRACT(YEAR FROM CURRENT_DATE);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                int a = 0;
                await using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        a = reader.GetInt32(0);
                    }
                }
                return a;
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

    public async Task<IList<PatientDoctorViewModel>> Searching(string item, Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from patient_doctor_view " +
                "where patientfio ilike '%@name%' order by id desc;";
            List<PatientDoctorViewModel> list = new List<PatientDoctorViewModel>();
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("name", item);
                await using (var reader =await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        PatientDoctorViewModel obj = new PatientDoctorViewModel();
                        obj.id = reader.GetInt64(0);
                        obj.patientfio = reader.GetString(1);
                        obj.gender_age = reader.GetString(2);
                        obj.tel_number = reader.GetString(3);
                        obj.doctorfio = reader.GetString(4);
                        obj.cur_date = reader.GetFieldValue<DateTime>(5);
                        obj.patientQueue = reader.GetInt32(6);
                        obj.doctorExamCost = reader.GetFloat(7);
                        obj.description = reader.GetString(8);
                        obj.next_exam = reader.GetInt32(9);

                        list.Add(obj);
                    }
                }
                
            }
            return list;
        }
        catch 
        {
            return new List<PatientDoctorViewModel>();         
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, PatientDoctor editObj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.patient_doctor " +
                "SET patients_id=@patients_id, doctor_id=@doctor_id, patient_queue=@patient_queue, cur_date=@cur_date, doctor_exam_cost=@doctor_exam_cost, description=@description, created_at=@created_at, updated_at=@updated_at, next_exam=@next_exam " +
                "WHERE id=@id;";
            await using (var command= new NpgsqlCommand(query, _connection))
            {
                
                command.Parameters.AddWithValue("id",id);
                command.Parameters.AddWithValue("patients_id", editObj.patient_id);
                command.Parameters.AddWithValue("doctor_id", editObj.doctor_id);
                command.Parameters.AddWithValue("patient_queue", editObj.patient_queue);
                command.Parameters.AddWithValue("cur_date",editObj.cur_date);
                command.Parameters.AddWithValue("doctor_exam_cost", editObj.doctor_exam_cost);
                command.Parameters.AddWithValue("description",editObj.description);
                command.Parameters.AddWithValue("created_at",editObj.created_at);
                command.Parameters.AddWithValue ("updated_at",editObj.updated_at);
                command.Parameters.AddWithValue("next_exam", editObj.next_exam_day);
                
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
}
