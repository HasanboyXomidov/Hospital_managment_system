using Hospital_managment_system.Constants;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        _connection = new NpgsqlConnection(Db_Constants.DB_CONNECTION_STRING);        
    }

}
