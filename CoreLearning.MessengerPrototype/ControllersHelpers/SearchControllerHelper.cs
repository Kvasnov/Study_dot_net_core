﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLearning.DBLibrary.DTO_models;
using CoreLearning.DBLibrary.Interfaces;
using CoreLearning.Infrastructure.Data;

namespace CoreLearning.MessengerPrototype.ControllersHelpers
{
    public class SearchControllerHelper
    {
        public SearchControllerHelper(IUserRepository repository)
        {
            this.repository = repository;
        }

        private IUserRepository repository;

        public async Task<IEnumerable<SearchModel>> SearchUsersAsync(string nickname, string userId)
        {
            var users = await repository.GetUsersAsync(nickname, userId);
            return users.Select(user => new SearchModel {Id = user.Id, Name = user.Name, LastName = user.LastName, Nickname = user.Nickname});
        }
    }
}
