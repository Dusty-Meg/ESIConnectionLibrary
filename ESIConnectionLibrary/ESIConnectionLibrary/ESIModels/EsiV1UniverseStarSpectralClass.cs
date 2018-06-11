using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1UniverseStarSpectralClass
    {
        [EnumMember(Value = "K2 V")]
        K2V,
        [EnumMember(Value = "K4 V")]
        K4V,
        [EnumMember(Value = "G2 V")]
        G2V,
        [EnumMember(Value = "G8 V")]
        G8V,
        [EnumMember(Value = "M7 V")]
        M7V,
        [EnumMember(Value = "K7 V")]
        K7V,
        [EnumMember(Value = "M2 V")]
        M2V,
        [EnumMember(Value = "K5 V")]
        K5V,
        [EnumMember(Value = "M3 V")]
        M3V,
        [EnumMember(Value = "G0 V")]
        G0V,
        [EnumMember(Value = "G7 V")]
        G7V,
        [EnumMember(Value = "G3 V")]
        G3V,
        [EnumMember(Value = "F9 V")]
        F9V,
        [EnumMember(Value = "G5 V")]
        G5V,
        [EnumMember(Value = "F6 V")]
        F6V,
        [EnumMember(Value = "K8 V")]
        K8V,
        [EnumMember(Value = "K9 V")]
        K9V,
        [EnumMember(Value = "K6 V")]
        K6V,
        [EnumMember(Value = "G9 V")]
        G9V,
        [EnumMember(Value = "G6 V")]
        G6V,
        [EnumMember(Value = "G4 VI")]
        G4Vi,
        [EnumMember(Value = "G4 V")]
        G4V,
        [EnumMember(Value = "F8 V")]
        F8V,
        [EnumMember(Value = "F2 V")]
        F2V,
        [EnumMember(Value = "F1 V")]
        F1V,
        [EnumMember(Value = "K3 V")]
        K3V,
        [EnumMember(Value = "F0 VI")]
        F0Vi,
        [EnumMember(Value = "G1 VI")]
        G1Vi,
        [EnumMember(Value = "G0 VI")]
        G0Vi,
        [EnumMember(Value = "K1 V")]
        K1V,
        [EnumMember(Value = "M4 V")]
        M4V,
        [EnumMember(Value = "M1 V")]
        M1V,
        [EnumMember(Value = "M6 V")]
        M6V,
        [EnumMember(Value = "M0 V")]
        M0V,
        [EnumMember(Value = "K2 IV")]
        K2Iv,
        [EnumMember(Value = "G2 VI")]
        G2Vi,
        [EnumMember(Value = "K0 V")]
        K0V,
        [EnumMember(Value = "K5 IV")]
        K5Iv,
        [EnumMember(Value = "F5 VI")]
        F5Vi,
        [EnumMember(Value = "G6 VI")]
        G6Vi,
        [EnumMember(Value = "F6 VI")]
        F6Vi,
        [EnumMember(Value = "F2 IV")]
        F2Iv,
        [EnumMember(Value = "G3 VI")]
        G3Vi,
        [EnumMember(Value = "M8 V")]
        M8V,
        [EnumMember(Value = "F1 VI")]
        F1Vi,
        [EnumMember(Value = "K1 IV")]
        K1Iv,
        [EnumMember(Value = "F7 V")]
        F7V,
        [EnumMember(Value = "G5 VI")]
        G5Vi,
        [EnumMember(Value = "M5 V")]
        M5V,
        [EnumMember(Value = "G7 VI")]
        G7Vi,
        [EnumMember(Value = "F5 V")]
        F5V,
        [EnumMember(Value = "F4 VI")]
        F4Vi,
        [EnumMember(Value = "F8 VI")]
        F8Vi,
        [EnumMember(Value = "K3 IV")]
        K3Iv,
        [EnumMember(Value = "F4 IV")]
        F4Iv,
        [EnumMember(Value = "F0 V")]
        F0V,
        [EnumMember(Value = "G7 IV")]
        G7Iv,
        [EnumMember(Value = "G8 VI")]
        G8Vi,
        [EnumMember(Value = "F2 VI")]
        F2Vi,
        [EnumMember(Value = "F4 V")]
        F4V,
        [EnumMember(Value = "F7 VI")]
        F7Vi,
        [EnumMember(Value = "F3 V")]
        F3V,
        [EnumMember(Value = "G1 V")]
        G1V,
        [EnumMember(Value = "G9 VI")]
        G9Vi,
        [EnumMember(Value = "F3 IV")]
        F3Iv,
        [EnumMember(Value = "F9 VI")]
        F9Vi,
        [EnumMember(Value = "M9 V")]
        M9V,
        [EnumMember(Value = "K0 IV")]
        K0Iv,
        [EnumMember(Value = "F1 IV")]
        F1Iv,
        [EnumMember(Value = "G4 IV")]
        G4Iv,
        [EnumMember(Value = "F3 VI")]
        F3Vi,
        [EnumMember(Value = "K4 IV")]
        K4Iv,
        [EnumMember(Value = "G5 IV")]
        G5Iv,
        [EnumMember(Value = "G3 IV")]
        G3Iv,
        [EnumMember(Value = "G1 IV")]
        G1Iv,
        [EnumMember(Value = "K7 IV")]
        K7Iv,
        [EnumMember(Value = "G0 IV")]
        G0Iv,
        [EnumMember(Value = "K6 IV")]
        K6Iv,
        [EnumMember(Value = "K9 IV")]
        K9Iv,
        [EnumMember(Value = "G2 IV")]
        G2Iv,
        [EnumMember(Value = "F9 IV")]
        F9Iv,
        [EnumMember(Value = "F0 IV")]
        F0Iv,
        [EnumMember(Value = "K8 IV")]
        K8Iv,
        [EnumMember(Value = "G8 IV")]
        G8Iv,
        [EnumMember(Value = "F6 IV")]
        F6Iv,
        [EnumMember(Value = "F5 IV")]
        F5Iv,
        [EnumMember(Value = "A0")]
        A0,
        [EnumMember(Value = "A0IV")]
        A0Iv,
        [EnumMember(Value = "A0IV2")]
        A0Iv2
    }
}