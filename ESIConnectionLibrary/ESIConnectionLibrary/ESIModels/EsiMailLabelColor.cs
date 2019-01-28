using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiMailLabelColor
    {
        [EnumMember(Value = "#0000fe")]
        Blue,

        [EnumMember(Value = "#006634")]
        FunGreen,

        [EnumMember(Value = "#0099ff")]
        DodgerBlue,

        [EnumMember(Value = "#00ff33")]
        FreeSpeechGreen,

        [EnumMember(Value = "#01ffff")]
        Aqua,

        [EnumMember(Value = "#349800")]
        LaPalma,

        [EnumMember(Value = "#660066")]
        Purple, 

        [EnumMember(Value = "#666666")]
        DimGrey,

        [EnumMember(Value = "#999999")]
        Nobel,

        [EnumMember(Value = "#99ffff")]
        ElectricBlue,

        [EnumMember(Value = "#9a0000")]
        DarkRed,

        [EnumMember(Value = "#ccff9a")]
        Reef,

        [EnumMember(Value = "#e6e6e6")]
        Whisper,

        [EnumMember(Value = "#fe0000")]
        Red,

        [EnumMember(Value = "#ff6600")]
        SafetyOrange,

        [EnumMember(Value = "#ffff01")]
        Yellow,

        [EnumMember(Value = "#ffffcd")]
        Cream,

        [EnumMember(Value = "#ffffff")]
        White
    }
}