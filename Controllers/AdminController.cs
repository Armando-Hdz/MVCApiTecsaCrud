using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPITecsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=dbtecsa; Uid=root; Pwd=12345678";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Admin> lst = null;
            using ( var db = new MySqlConnection(_connection) )
            {
                var sql = "Select id, correo, nombre, telefono, contrasena From admin";

                lst = db.Query<Models.Admin>(sql);
            }

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Post(Models.Admin model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO admin(correo, nombre, telefono, contrasena)" +
                    " VALUES(@correo, @nombre, @telefono, @contrasena)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(Models.Admin model)
        {
            int result = 0;
            using ( var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE admin SET correo=@correo, nombre=@nombre, telefono=@telefono, contrasena=@contrasena" +
                    " WHERE id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(Models.Admin model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM admin WHERE id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }
    }
}
