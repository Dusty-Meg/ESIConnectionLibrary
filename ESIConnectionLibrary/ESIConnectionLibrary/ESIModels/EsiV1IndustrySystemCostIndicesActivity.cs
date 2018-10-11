using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1IndustrySystemCostIndicesActivity
    {
        [EnumMember(Value = "copying")]
        Copying,

        [EnumMember(Value = "duplicating")]
        Duplicating,

        [EnumMember(Value = "invention")]
        Invention,

        [EnumMember(Value = "manufacturing")]
        Manufacturing,

        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "reaction")]
        Reaction,

        [EnumMember(Value = "researching_material_efficiency")]
        ResearchingMaterialEfficiency,

        [EnumMember(Value = "researching_technology")]
        ResearchingTechnology,

        [EnumMember(Value = "researching_time_efficiency")]
        ResearchingTimeEfficiency,

        [EnumMember(Value = "reverse_engineering")]
        ReverseEngineering
    }
}