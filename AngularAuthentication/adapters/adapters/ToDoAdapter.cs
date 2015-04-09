using AngularAuthentication.adapters.interfaces;
using AngularAuthentication.Data;
using AngularAuthentication.Model;
using AngularAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularAuthentication.adapters.adapters
{
    public class ToDoAdapter : IToDoAdapter
    {
        public List<ToDoViewModel> GetAllToDos(string userId)
        {
            List<ToDoViewModel> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.ToDos.Where(x => x.UserId == userId).Select(x => new ToDoViewModel()
                {
                    Description = x.Description,
                    ToDoId = x.ToDoId
                }).ToList();
            }
            return model;
        }

        public int DeleteTask(int id)
        {
            int result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ToDo model = db.ToDos.FirstOrDefault(x => x.ToDoId == id);
                db.ToDos.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

        public int EditTask(int id)
        {
            int result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ToDo model = db.ToDos.FirstOrDefault(x => x.ToDoId == id);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}