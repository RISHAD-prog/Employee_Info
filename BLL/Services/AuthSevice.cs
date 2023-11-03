using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class AuthSevice
    {
        private readonly DataAccessFactory daf;

        public AuthSevice(DataAccessFactory _daf)
        {
            this.daf = _daf;
        }
        public UserDto CreateAuthSevice(UserDto user, byte[] passwordHash, byte[] passwordSalt) {
            var config = Service.Mapping<UserDto, User>();
            var mapper = new Mapper(config);
            var usertoken = new User();
            usertoken.UserName = user.UserName;
            usertoken.PasswordHash = passwordHash;
            usertoken.PasswordSalt = passwordSalt;
            var result = daf.User().CreatePasswordHash(usertoken);
            if(result != null)
            {
                return mapper.Map<UserDto>(result);
            }
            return null;
        }

        public string? UserLogin(UserDto user)
        {
            string result = daf.User().GetLoginDetails(user.UserName);
            return result;
        }

        public userRegistrationDetails getDetails (UserDto user) { 
            var result = daf.User().GetRegisterDetails(user.UserName);
            var config = Service.Mapping<userRegistrationDetails, User>();
            var mapper = new Mapper(config);
            if(result != null)
            {
                return mapper.Map<userRegistrationDetails>(result);
            }
            return null;
        }
    }
}
