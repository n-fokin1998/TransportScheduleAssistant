﻿// <copyright file="PlaneService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.AdminPanelProcessing.Services
{
    using System.Collections.Generic;
    using AirwaySchedule.Bot.AdminPanelProcessing.Interfaces;
    using Common.Models;
    using AirwaySchedule.Bot.Common.FilterModels;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using AutoMapper;

    /// <summary>
    /// PlaneService
    /// </summary>
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _planeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneService"/> class.
        /// </summary>
        /// <param name="planeRepository">planeRepository</param>
        /// <param name="mapper">mapper</param>
        public PlaneService(IPlaneRepository planeRepository, IMapper mapper)
        {
            _planeRepository = planeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// GetFilteredPlanes
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <param name="pagingInfo">pagingInfo</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Plane> GetFilteredPlanes(string searchKey, PagingInfo pagingInfo)
        {
            var filteredPlanes = _planeRepository.GetFilteredList(searchKey, pagingInfo);

            return _mapper.Map<IEnumerable<Plane>>(filteredPlanes);
        }
    }
}
