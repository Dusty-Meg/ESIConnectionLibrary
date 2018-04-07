using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsMarket
    {
        [JsonProperty(PropertyName = "accept_contracts_courier")]
        public long? AcceptContractsCourier { get; set; }

        [JsonProperty(PropertyName = "accept_contracts_item_exchange")]
        public long? AcceptContractsItemExchange { get; set; }

        [JsonProperty(PropertyName = "buy_orders_placed")]
        public long? BuyOrdersPlaced { get; set; }

        [JsonProperty(PropertyName = "cancel_market_order")]
        public long? CancelMarketOrder { get; set; }

        [JsonProperty(PropertyName = "create_contracts_auction")]
        public long? CreateContractsAuction { get; set; }

        [JsonProperty(PropertyName = "create_contracts_courier")]
        public long? CreateContractsCourier { get; set; }

        [JsonProperty(PropertyName = "create_contracts_item_exchange")]
        public long? CreateContractsItemExchange { get; set; }

        [JsonProperty(PropertyName = "deliver_courier_contract")]
        public long? DeliverCourierContract { get; set; }

        [JsonProperty(PropertyName = "isk_gained")]
        public long? IskGained { get; set; }

        [JsonProperty(PropertyName = "isk_spent")]
        public long? IskSpent { get; set; }

        [JsonProperty(PropertyName = "modify_market_order")]
        public long? ModifyMarketOrder { get; set; }

        [JsonProperty(PropertyName = "search_contracts")]
        public long? OsearchContractsut { get; set; }

        [JsonProperty(PropertyName = "sell_orders_placed")]
        public long? SellOrdersPlaced { get; set; }
    }
}