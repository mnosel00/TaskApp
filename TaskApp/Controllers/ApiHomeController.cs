using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiHomeController : ControllerBase
    {
        private ITaskInterface _ApiTaskInterface;

        public ApiHomeController(ITaskInterface ApiTaskInterface)
        {
            _ApiTaskInterface = ApiTaskInterface;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            try
            {
                return Ok(_ApiTaskInterface.GetAllUsers());
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Can not get data from database");

            }
        }
        [HttpGet("{id:int}")]
        public ActionResult GetUser(int id)
        {
            try
            {
                var res = _ApiTaskInterface.GetUser(id);
                if (res==null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Can not get data from database");

            }
        }
        [HttpPost]
        public ActionResult CreateUser(UserCollection cuser)
        {
            try
            {
                if (cuser == null)
                {
                    return BadRequest   ();
                }

                var newUser = _ApiTaskInterface.Add(cuser);

                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Can not create a new user");

            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id,UserCollection user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }


                _ApiTaskInterface.Update(user);
                return Ok(user);
                    



            }
            catch (System.Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Can not update a user");

            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var userDeleted = _ApiTaskInterface.GetUser(id);
                
                if (userDeleted == null)
                {
                    return NotFound();
                }


                _ApiTaskInterface.Delete(id);
                return Ok($"User{id} has gone");
            }
            catch (System.Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Can not delete a user");

            }
        }
    }
}