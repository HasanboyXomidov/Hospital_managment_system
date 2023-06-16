using Hospital_managment_system.Constants;
using Hospital_managment_system.Entities.Nurses;
using Hospital_managment_system.Interfaces.Nurses;
using Hospital_managment_system.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Nurses;

public class NurseRepository : INurseRepository
{
    private readonly NpgsqlConnection _connection;
    public NurseRepository()
    {
        _connection = new NpgsqlConnection(Db_Constants.DB_CONNECTION_STRING);
    }
    public Task<int> CountAync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Nurse obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = ""
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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Nurse>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
    }

    public Task<Nurse> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Nurse editObj)
    {
        throw new NotImplementedException();
    }

}
