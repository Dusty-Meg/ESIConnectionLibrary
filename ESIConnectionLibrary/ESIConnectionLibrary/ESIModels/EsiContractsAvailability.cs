﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiContractsAvailability
    {
        [EnumMember(Value = "public")]
        Public,

        [EnumMember(Value = "personal")]
        Personal,

        [EnumMember(Value = "corporation")]
        Corporation,

        [EnumMember(Value = "alliance")]
        Alliance
    }
}