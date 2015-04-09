using AngularAuthentication.adapters.adapters;
using AngularAuthentication.adapters.interfaces;
using AngularAuthentication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularAuthentication.Controllers
{
    public class apiToDoController : ApiController
    {
        private IToDoAdapter _adapter;

        public apiToDoController()
        {
            _adapter = new ToDoAdapter();
        }

        public apiToDoController(IToDoAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            List<ToDoViewModel> model = _adapter.GetAllToDos(userId);
            return Ok(model);
        }
        
        public IHttpActionResult Delete(int id)
        {
            int result = _adapter.DeleteTask(id);
            if (result != 1)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
        public IHttpActionResult Edit(int id)
        {
            int result = _adapter.EditTask(id);
            if (result != 1)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}