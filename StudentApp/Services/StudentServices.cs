﻿using Dapper;
using StudentApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Services
{
    //2.Use Interface
    public class StudentServices : IStudentService
    {
        //1.Create Constructor

        private readonly IConfiguration _configuration;     

        //2.Create Constructor method
        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DBConnection");
            providerName = "System.Data.SqlClient";
        }

        public string ConnectionString { get; }
        public string providerName { get;  }

        //Add Attribute for SQL connection /  IStudentService Members
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public string InsertStudent(Student model)
        {
            using(IDbConnection dbConnection = Connection)
            {
               dbConnection.Open();

                var student = dbConnection.Query<List<Student>>("sp_InsertStudentRecord", model, commandType: CommandType.StoredProcedure).ToList();

                dbConnection.Close();

            }
            return "";

        }


    }

    //1.Create Interface
    public interface IStudentService
    {
        public string InsertStudent(Student model);

    }






}
