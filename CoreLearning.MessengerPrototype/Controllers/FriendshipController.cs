﻿using System;
using System.Linq;
using System.Threading.Tasks;
using CoreLearning.DBLibrary.Interfaces.ControllerHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreLearning.MessengerPrototype.Controllers
{
    [ApiController]
    [Route("Friendship")]
    public class FriendshipController : ControllerBase
    {
        public FriendshipController(IFriendshipControllerHelper helper)
        {
            this.helper = helper;
        }

        private readonly IFriendshipControllerHelper helper;

        [HttpGet("AddToFriends")]
        [Authorize]
        public async Task<IActionResult> AddToFriendsAsync(Guid friendId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
            await helper.AddToFriendsAsync(Guid.Parse(userId), friendId);
            await helper.SaveAsync();

            return Ok(new {Message = $"application of friendship is send, id = {friendId}" });
        }

        [HttpPost("ShowFriedList")]
        [Authorize]
        public async Task<IActionResult> ShowFriedListAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            return Ok(new {FriendList = await helper.ShowFriedListAsync(Guid.Parse(userId))});
        }

        [HttpPost("ShowInboxApplicationList")]
        [Authorize]
        public async Task<IActionResult> ShowInboxApplicationListAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            return Ok(new {InboxApplicationList = await helper.ShowInboxApplicationListAsync(Guid.Parse(userId))});
        }

        [HttpPost("ShowOutboxApplicationList")]
        [Authorize]
        public async Task<IActionResult> ShowOutboxApplicationListAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            return Ok(new {OutboxApplicationList = await helper.ShowOutboxApplicationListAsync(Guid.Parse(userId))});
        }

        [HttpGet("ApproveApplication")]
        [Authorize]
        public async Task<IActionResult> ApproveApplicationAsync(Guid friendId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
            await helper.ApproveApplicationAsync(Guid.Parse(userId), friendId);
            await helper.SaveAsync();

            return Ok(new {Message = $"Application is approved, friend id = {friendId}"});
        }

        [HttpGet("RemoveFriend")]
        [Authorize]
        public async Task<IActionResult> RemoveFriendAsync(Guid friendId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
            await helper.RemoveFriendAsync(Guid.Parse(userId), friendId);
            await helper.SaveAsync();

            return Ok(new {Message = $"Friend is removed, id = {friendId}" });
        }
    }
}