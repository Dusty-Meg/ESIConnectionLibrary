﻿using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationContainerLogs
    {
        public V2CorporationContainerLogAction Action { get; set; }
        public int CharacterId { get; set; }
        public long ContainerId { get; set; }
        public int ContainerTypeId { get; set; }
        public LocationFlagCorporation LocationFlag { get; set; }
        public long LocationId { get; set; }
        public DateTime LoggedAt { get; set; }
        public int? NewConfigBitmask { get; set; }
        public int? OldConfigBitmask { get; set; }
        public V2CorporationContainerLogPasswordType? PasswordType { get; set; }
        public int? Quantity { get; set; }
        public int? TypeId { get; set; }
    }
}