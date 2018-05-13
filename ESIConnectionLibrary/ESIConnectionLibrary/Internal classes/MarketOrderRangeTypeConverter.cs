using System;
using ESIConnectionLibrary.ESIModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    public sealed class MarketOrderRangeTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;

            switch (value)
            {
                case "1":
                    return EsiMarketRange.one;
                case "10":
                    return EsiMarketRange.ten;
                case "2":
                    return EsiMarketRange.two;
                case "20":
                    return EsiMarketRange.twenty;
                case "3":
                    return EsiMarketRange.three;
                case "30":
                    return EsiMarketRange.thirty;
                case "4":
                    return EsiMarketRange.four;
                case "40":
                    return EsiMarketRange.forty;
                case "5":
                    return EsiMarketRange.five;
                case "region":
                    return EsiMarketRange.region;
                case "solarsystem":
                    return EsiMarketRange.solarsystem;
                default:
                    return EsiMarketRange.station;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
