﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using EmbyStat.Common.Extentions;

namespace EmbyStat.Common.Models
{
    public class ConfigurationKeyValue
    {
        [Key] public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Configuration
    {
        private readonly Dictionary<string, string> _config;

        public bool WizardFinished
        {
            get => _config[Constants.Configuration.WizardFinished].ToBoolean();
            set => _config[Constants.Configuration.WizardFinished] = value.ToString();
        }

        public string AccessToken
        {
            get => _config[Constants.Configuration.AccessToken];
            set => _config[Constants.Configuration.AccessToken] = value;
        }

        public string EmbyUserName
        {
            get => _config[Constants.Configuration.EmbyUserName];
            set => _config[Constants.Configuration.EmbyUserName] = value;
        }

        public string EmbyServerAddress
        {
            get => _config[Constants.Configuration.EmbyServerAddress];
            set => _config[Constants.Configuration.EmbyServerAddress] = value;
        }

        public string Username
        {
            get => _config[Constants.Configuration.UserName];
            set => _config[Constants.Configuration.UserName] = value;
        }

        public string Language
        {
            get => _config[Constants.Configuration.Language];
            set => _config[Constants.Configuration.Language] = value;
        }

        public string ServerName
        {
            get => _config[Constants.Configuration.ServerName];
            set => _config[Constants.Configuration.ServerName] = value;
        }

        public string EmbyUserId
        {
            get => _config[Constants.Configuration.EmbyUserId];
            set => _config[Constants.Configuration.EmbyUserId] = value;
        }
        public int ToShortMovie
        {
            get => Convert.ToInt32(_config[Constants.Configuration.ToShortMovie]);
            set => _config[Constants.Configuration.ToShortMovie] = value.ToString();
        }
        public DateTime? LastTvdbUpdate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_config[Constants.Configuration.LastTvdbUpdate])) return null;
                return Convert.ToDateTime(_config[Constants.Configuration.LastTvdbUpdate]);
            }
            set
            {
                if (value.HasValue) _config[Constants.Configuration.LastTvdbUpdate] = value.Value.ToString(CultureInfo.InvariantCulture);
                else _config[Constants.Configuration.LastTvdbUpdate] = null;
            }
        }

        public Configuration(IEnumerable<ConfigurationKeyValue> list)
        {
            _config = list.ToDictionary(x => x.Id, y => y.Value);
        }

        [Obsolete("Don't use this contructor! AutMapper needs it")]
        public Configuration()
        {
            _config = new Dictionary<string, string>();
        }

        public IEnumerable<ConfigurationKeyValue> GetKeyValuePairs()
        {
            return _config.Select(x => new ConfigurationKeyValue {Id = x.Key, Value = x.Value});
        }
    }
}
