﻿using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Client
{
    class ActivityTrackerClient
    {
        private readonly IActivityTrackerApi _activityTrackerApi;

        public ActivityTrackerClient()
        {
            var activityTrackerApi = RestService.For<IActivityTrackerApi>("https://activitytrackerappapi.azurewebsites.net/api");
            _activityTrackerApi = activityTrackerApi;
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto)
        {
            var result = await _activityTrackerApi.Register(registerRequestDto);
            return result;
        }
        public async Task<string> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _activityTrackerApi.Login(loginRequestDto);
            return result;
        }
    }
}
