﻿using Data_Access_Layer;
using Data_Access_Layer.JWTService;
using Data_Access_Layer.Repository.Entities;

namespace Business_logic_Layer
{
    public class BALLogin
    {
        private readonly DALLogin _dalLogin;
        private readonly JwtService _jwtService;
        ResponseResult result = new ResponseResult();
        public BALLogin(DALLogin dalLogin, JwtService jwtService)
        {
            _dalLogin = dalLogin;
            _jwtService = jwtService;
        }

        public ResponseResult GetUserById(int id)
        {
            try
            {
                User user = new User();
                user = _dalLogin.GetUserById(id);

                if (user != null)
                {
                    result.Message = "User Found";
                    result.Result = ResponseStatus.Success;
                    result.Data = user;
                }
                else
                {
                    result.Message = "User Not Found";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public ResponseResult UpdateUser(User user)
        {
            try
            {
                User userObj = new User();
                userObj = _dalLogin.UpdateUser(user);

                if (userObj != null)
                {
                    if (userObj.Message.ToString() == "User Updated Successfully")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in Update";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    
        public ResponseResult LoginUser(User user)
        {
            try
            {
                User userObj= new User();
                userObj = UserLogin(user);

                if(userObj != null)
                {
                    if(userObj.Message.ToString() == "Login Successfully")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                        result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress,userObj.UserType,userObj.UserImage);
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in Login";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public User  UserLogin(User user)
        {
            User userOb = new User()
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };

            return _dalLogin.LoginUser(user);
        }

        public string Register(User user)
        {
            return _dalLogin.Register(user);
        }
    }
}
