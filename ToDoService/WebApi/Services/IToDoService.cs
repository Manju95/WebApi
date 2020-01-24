using System;
using System.Collections.Generic;
using ToDoService.Models;

namespace ToDoService.Service
{
    public interface IToDoService
    {
        IEnumerable<ToDoTask> GetAllTask();

        int SaveTask(ToDoTask task);

        bool DeleteTask(int id);
    }
}