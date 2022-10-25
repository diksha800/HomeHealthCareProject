using HomeHealthCareModelClass.Model;
using HomeHealthCareMVC.Models;
using NLog;
using System;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace HomeHealthCareAPI.Controllers
{
    public class AccountController : ApiController
    {
        private HomeHealthCareEntities entities;
        private object varhashedBytes;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object UserId { get; private set; }

        public AccountController()
        {
            this.entities = new HomeHealthCareEntities();
        }
        [Route("api/Account/Register")]
        [HttpPost]
        public void Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {
                    try
                    {
                       
                        ObjectParameter responseMessage = new ObjectParameter("ErrorMessage", typeof(string));

                        entities.Adduser(model.FirstName, model.LastName, model.Email, model.Password, model.DOB, model.TypeOfUser, responseMessage);
                        entities.SaveChanges();
                        logger.Info("User Registered Successfully");
                    }
                    catch (Exception e)
                    {
                        logger.Error("Error Occoured During Adding User Data In Database");
                        logger.Error(e);

                    }

                }
            }
            logger.Error("ModelState is Invalid");


            
        }
        
        [Route("api/account/login")]
        [HttpPost]

        public HttpResponseMessage Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {

                    using (var sha512 = SHA512.Create())
                    {
                        try
                        {
                            varhashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));
                        }
                        catch (Exception e)
                        {
                            logger.Error("Error During hashing the Password During login");
                            logger.Error(e);

                        }
                        try
                        {
                            var _currentUser = entities.Users.FirstOrDefault(user => user.Email == userLogin.Email || user.Password == varhashedBytes);
                            if (_currentUser != null)
                            {
                                UserId = _currentUser.UserId;
                                var HealthUrl = this.Url.Content("https://localhost:44304/Home/index");
                                logger.Info("User Logged in Successfully");
                                return Request.CreateResponse(HttpStatusCode.Created,
                                                         new { Success = true, RedirectUrl = HealthUrl, user = _currentUser.UserId, email = _currentUser.Email });
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Error("Error Occoured During User Validation");
                            logger.Error(e);

                        }


                    }

                }
            }
            logger.Error("Invalid User");
            var testUrl = this.Url.Link("Default", new
            {
                Controller = "Home",
                Action = "Index"
            });
            return Request.CreateResponse(HttpStatusCode.Forbidden,
                                     new { Success = false, RedirectUrl = testUrl });
        }



    }
}

