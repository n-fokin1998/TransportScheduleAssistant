﻿// <copyright file="YandexApiConfiguration.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace TransportScheduleAssistant.IntegrationProxy.Models
{
    /// <summary>
    /// YandexApiConfiguration
    /// </summary>
    public class YandexApiConfiguration
    {
        /// <summary>
        /// ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// BaseUrl
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Lang
        /// </summary>
        public string Lang { get; set; }
    }
}
