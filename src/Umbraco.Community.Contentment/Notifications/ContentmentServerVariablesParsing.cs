﻿/* Copyright © 2021 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core;
using Umbraco.Extensions;
using Microsoft.Extensions.Options;

namespace Umbraco.Community.Contentment.Notifications
{
    internal sealed class ContentmentServerVariablesParsing : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly ContentmentSettings _contentmentSettings;

        public ContentmentServerVariablesParsing(IOptions<ContentmentSettings> contentmentSettings)
        {
            _contentmentSettings = contentmentSettings.Value;
        }

        public void Handle(ServerVariablesParsingNotification notification)
        {
            if (notification.ServerVariables.TryGetValueAs("umbracoPlugins", out Dictionary<string, object> umbracoPlugins) == true &&
                umbracoPlugins.ContainsKey(Constants.Internals.ProjectAlias) == false)
            {
                umbracoPlugins.Add(Constants.Internals.ProjectAlias, new
                {
                    name = Constants.Internals.ProjectName,
                    version = ContentmentVersion.SemanticVersion.ToSemanticString(),
                    telemetry = _contentmentSettings.DisableTelemetry == false,
                });
            }
        }
    }
}