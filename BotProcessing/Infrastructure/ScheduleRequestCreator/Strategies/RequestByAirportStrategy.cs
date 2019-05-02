﻿// <copyright file="RequestByAirportStrategy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator.Strategies
{
    using System.Linq;
    using System.Threading.Tasks;

    using Common.Models;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using Interfaces.Infrastructure.ScheduleRequestCreator;

    /// <summary>
    /// RequestByIataStrategy
    /// </summary>
    public class RequestByAirportStrategy : RequestStrategyBase, IScheduleRequestStrategy
    {
        private readonly IIataApiProxy _iataApiProxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestByAirportStrategy"/> class.
        /// </summary>
        /// <param name="iataApiProxy">iataApiProxy</param>
        public RequestByAirportStrategy(IIataApiProxy iataApiProxy)
        {
            _iataApiProxy = iataApiProxy;
        }

        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <returns>RequestParameters</returns>
        public async Task<RequestParameters> CreateRequest(long chatId, string commandText)
        {
            return await CreateRequest(chatId, commandText, async (departure, destination) =>
            {
                var departureIataResponse = await _iataApiProxy.GetResponseAsync(departure);
                var destinationIataResponse = await _iataApiProxy.GetResponseAsync(destination);

                return new RequestParameters
                {
                    Departure = departureIataResponse.Response.Airports.First().Code,
                    Destination = destinationIataResponse.Response.Airports.First().Code
                };
            });
        }
    }
}
