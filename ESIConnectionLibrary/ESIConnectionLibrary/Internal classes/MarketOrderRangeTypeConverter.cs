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
                    return EsiMarketRange.One;
                case "10":
                    return EsiMarketRange.Ten;
                case "2":
                    return EsiMarketRange.Two;
                case "20":
                    return EsiMarketRange.Twenty;
                case "3":
                    return EsiMarketRange.Three;
                case "30":
                    return EsiMarketRange.Thirty;
                case "4":
                    return EsiMarketRange.Four;
                case "40":
                    return EsiMarketRange.Forty;
                case "5":
                    return EsiMarketRange.Five;
                case "region":
                    return EsiMarketRange.Region;
                case "solarsystem":
                    return EsiMarketRange.Solarsystem;
                default:
                    return EsiMarketRange.Station;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
