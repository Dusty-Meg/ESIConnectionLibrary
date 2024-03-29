﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV3CorporationContainerLogPasswordType
    {
        [EnumMember(Value = "config")]
        Config,

        [EnumMember(Value = "general")]
        General
    }
}