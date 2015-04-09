using AngularAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularAuthentication.adapters.interfaces
{
    public interface IToDoAdapter
    {
        List<ToDoViewModel> GetAllToDos(string userId);
        int DeleteTask(int id);
        int EditTask(int id);
    }
}