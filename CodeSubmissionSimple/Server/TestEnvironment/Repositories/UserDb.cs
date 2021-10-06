﻿using AutoMapper;
using CodeSubmissionSimple.Server.TestEnvironment;
using CodeSubmissionSimple.Server.Models;
using CodeSubmissionSimple.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class UserDb : IUserDb
    {
        private readonly IWorkOfUnit unitOfWork;
        private readonly IMapper mapper;

        public UserDb(IWorkOfUnit unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public static string CreateHash(string password)
        {
            var salt = "997eff51db1544c7a3c2ddeb2053f052";
            var md5 = new HMACMD5(Encoding.UTF8.GetBytes(salt + password));
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return System.Convert.ToBase64String(data);

        }

        public async Task<AppUser> AddUser(string email, string password, string role)
        {
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				//store in db
				string hashedPassword = CreateHash(password);

				AppUserDto appUserDto = new Models.AppUserDto(email, role, hashedPassword);

				var user = mapper.Map<AppUser>(appUserDto);
				await unitOfWork.AppUsers.Insert(user);
				await unitOfWork.Save();

				// return user
				return new AppUser(email, role);

			}
			catch
			{
				return null;
			}
		}

        public async Task<AppUser> AuthenticateUser(string email, string password)
        {
            try
            {
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				var user = await unitOfWork.AppUsers.Get(q => q.Email.Equals(email));
				var result = mapper.Map<AppUserDto>(user);

				if (!result.PasswordHash.Equals(CreateHash(password)))
					return null;

				return new AppUser(email, result.Role);
			}
            catch (Exception)
            {

				return null;
            }
		}
    }
}
