using System.Collections;
using System;
using System.Collections.Generic;
using ToDoService.Models;
using Dapper;
using System.Data;

namespace ToDoService.Service
{
    public class ToDoDataService : IToDoService
    {

        private IDbConnection _Idbconnection;

        public ToDoDataService(IDbConnection dbConnection)
        {
            _Idbconnection = dbConnection;
        }

        public IEnumerable<ToDoTask> GetAllTask(){

            IEnumerable<ToDoTask> response=null;
            var sqlcmd = "SELECT * FROM TASK";
            try{
                using (_Idbconnection)
                {
                    _Idbconnection.Open();
                    response = _Idbconnection.Query<ToDoTask>(sqlcmd);
                    _Idbconnection.Close();
                }
                return response;
            }catch(Exception e){
                throw e;
            }
            
        }

        public int SaveTask(ToDoTask task){
            
            string query = @"INSERT INTO TASK(CREATEDDATE,DESCRIPTION) VALUES (@CREATEDDATE, @DESCRIPTION)";
            try{
                using (_Idbconnection)
                {
                    _Idbconnection.Open();
                    var count = _Idbconnection.Execute(query,new {CREATEDDATE=DateTime.Now,DESCRIPTION=task.description});
                    _Idbconnection.Close();
                    return count;
                }
            }catch(Exception e){
                throw e;
            }
            

        }

        public bool DeleteTask(int id){
            //throw new NotImplementedException();
             string query = "DELETE FROM TASK WHERE ID=@ID";
             try{
                using (_Idbconnection)
                {
                    _Idbconnection.Open();
                    var count = _Idbconnection.Execute(query,new {ID=id});
                    _Idbconnection.Close();
                    if(count > 0)
                    return true;
                    else 
                    return false;
                }
             }catch(Exception e){
                 throw e;
             }
            
        }
    }
}