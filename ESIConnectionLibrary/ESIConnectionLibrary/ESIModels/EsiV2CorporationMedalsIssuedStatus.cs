﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2CorporationMedalsIssuedStatus
    {
        [EnumMember(Value = "private")]
        Private,

        [EnumMember(Value = "public")]
        Public
    }
}