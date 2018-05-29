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
        G4VI,
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
        F0VI,
        [EnumMember(Value = "G1 VI")]
        G1VI,
        [EnumMember(Value = "G0 VI")]
        G0VI,
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
        K2IV,
        [EnumMember(Value = "G2 VI")]
        G2VI,
        [EnumMember(Value = "K0 V")]
        K0V,
        [EnumMember(Value = "K5 IV")]
        K5IV,
        [EnumMember(Value = "F5 VI")]
        F5VI,
        [EnumMember(Value = "G6 VI")]
        G6VI,
        [EnumMember(Value = "F6 VI")]
        F6VI,
        [EnumMember(Value = "F2 IV")]
        F2IV,
        [EnumMember(Value = "G3 VI")]
        G3VI,
        [EnumMember(Value = "M8 V")]
        M8V,
        [EnumMember(Value = "F1 VI")]
        F1VI,
        [EnumMember(Value = "K1 IV")]
        K1IV,
        [EnumMember(Value = "F7 V")]
        F7V,
        [EnumMember(Value = "G5 VI")]
        G5VI,
        [EnumMember(Value = "M5 V")]
        M5V,
        [EnumMember(Value = "G7 VI")]
        G7VI,
        [EnumMember(Value = "F5 V")]
        F5V,
        [EnumMember(Value = "F4 VI")]
        F4VI,
        [EnumMember(Value = "F8 VI")]
        F8VI,
        [EnumMember(Value = "K3 IV")]
        K3IV,
        [EnumMember(Value = "F4 IV")]
        F4IV,
        [EnumMember(Value = "F0 V")]
        F0V,
        [EnumMember(Value = "G7 IV")]
        G7IV,
        [EnumMember(Value = "G8 VI")]
        G8VI,
        [EnumMember(Value = "F2 VI")]
        F2VI,
        [EnumMember(Value = "F4 V")]
        F4V,
        [EnumMember(Value = "F7 VI")]
        F7VI,
        [EnumMember(Value = "F3 V")]
        F3V,
        [EnumMember(Value = "G1 V")]
        G1V,
        [EnumMember(Value = "G9 VI")]
        G9VI,
        [EnumMember(Value = "F3 IV")]
        F3IV,
        [EnumMember(Value = "F9 VI")]
        F9VI,
        [EnumMember(Value = "M9 V")]
        M9V,
        [EnumMember(Value = "K0 IV")]
        K0IV,
        [EnumMember(Value = "F1 IV")]
        F1IV,
        [EnumMember(Value = "G4 IV")]
        G4IV,
        [EnumMember(Value = "F3 VI")]
        F3VI,
        [EnumMember(Value = "K4 IV")]
        K4IV,
        [EnumMember(Value = "G5 IV")]
        G5IV,
        [EnumMember(Value = "G3 IV")]
        G3IV,
        [EnumMember(Value = "G1 IV")]
        G1IV,
        [EnumMember(Value = "K7 IV")]
        K7IV,
        [EnumMember(Value = "G0 IV")]
        G0IV,
        [EnumMember(Value = "K6 IV")]
        K6IV,
        [EnumMember(Value = "K9 IV")]
        K9IV,
        [EnumMember(Value = "G2 IV")]
        G2IV,
        [EnumMember(Value = "F9 IV")]
        F9IV,
        [EnumMember(Value = "F0 IV")]
        F0IV,
        [EnumMember(Value = "K8 IV")]
        K8IV,
        [EnumMember(Value = "G8 IV")]
        G8IV,
        [EnumMember(Value = "F6 IV")]
        F6IV,
        [EnumMember(Value = "F5 IV")]
        F5IV,
        [EnumMember(Value = "A0")]
        A0,
        [EnumMember(Value = "A0IV")]
        A0IV,
        [EnumMember(Value = "A0IV2")]
        A0IV2
    }
}