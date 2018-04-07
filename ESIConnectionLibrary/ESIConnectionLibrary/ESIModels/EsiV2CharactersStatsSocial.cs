using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsSocial
    {
        [JsonProperty(PropertyName = "add_contact_bad")]
        public long? AddContactBad { get; set; }

        [JsonProperty(PropertyName = "add_contact_good")]
        public long? AddContactGood { get; set; }

        [JsonProperty(PropertyName = "add_contact_high")]
        public long? AddContactHigh { get; set; }

        [JsonProperty(PropertyName = "add_contact_horrible")]
        public long? AddContactHorrible { get; set; }

        [JsonProperty(PropertyName = "add_contact_neutral")]
        public long? AddContactNeutral { get; set; }

        [JsonProperty(PropertyName = "add_note")]
        public long? AddNote { get; set; }

        [JsonProperty(PropertyName = "added_as_contact_bad")]
        public long? AddedAsContactBad { get; set; }

        [JsonProperty(PropertyName = "added_as_contact_good")]
        public long? AddedAsContactGood { get; set; }

        [JsonProperty(PropertyName = "added_as_contact_high")]
        public long? AddedAsContactHigh { get; set; }

        [JsonProperty(PropertyName = "added_as_contact_horrible")]
        public long? AddedAsContactHorrible { get; set; }

        [JsonProperty(PropertyName = "added_as_contact_neutral")]
        public long? AddedAsContactNeutral { get; set; }

        [JsonProperty(PropertyName = "calendar_event_created")]
        public long? CalendarEventCreated { get; set; }

        [JsonProperty(PropertyName = "chat_messages_alliance")]
        public long? ChatMessagesAlliance { get; set; }

        [JsonProperty(PropertyName = "chat_messages_constellation")]
        public long? ChatMessagesConstellation { get; set; }

        [JsonProperty(PropertyName = "chat_messages_corporation")]
        public long? ChatMessagesCorporation { get; set; }

        [JsonProperty(PropertyName = "chat_messages_fleet")]
        public long? ChatMessagesFleet { get; set; }

        [JsonProperty(PropertyName = "chat_messages_region")]
        public long? ChatMessagesRegion { get; set; }

        [JsonProperty(PropertyName = "chat_messages_solarsystem")]
        public long? ChatMessagesSolarsystem { get; set; }

        [JsonProperty(PropertyName = "chat_messages_warfaction")]
        public long? ChatMessagesWarfaction { get; set; }

        [JsonProperty(PropertyName = "chat_total_message_length")]
        public long? ChatTotalMessageLength { get; set; }

        [JsonProperty(PropertyName = "direct_trades")]
        public long? DirectTrades { get; set; }

        [JsonProperty(PropertyName = "fleet_broadcasts")]
        public long? FleetBroadcasts { get; set; }

        [JsonProperty(PropertyName = "fleet_joins")]
        public long? FleetJoins { get; set; }

        [JsonProperty(PropertyName = "mails_received")]
        public long? MailsReceived { get; set; }

        [JsonProperty(PropertyName = "mails_sent")]
        public long? MailsSent { get; set; }
    }
}