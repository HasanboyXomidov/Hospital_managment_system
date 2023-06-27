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

    public async Task<IList<PatientDoctorViewModel>> GetAllAsync(Paginations @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from patient_doctor_view;";
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
        finally { await _connection.CloseAsync(); }
    }

    public Task<PatientDoctorViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, PatientDoctor editObj)
    {
        throw new NotImplementedException();
    }
}
