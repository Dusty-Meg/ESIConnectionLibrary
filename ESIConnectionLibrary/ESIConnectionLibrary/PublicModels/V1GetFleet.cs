namespace ESIConnectionLibrary.PublicModels
{
    public class V1GetFleet
    {
        public bool IsFreeMove { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsVoiceEnabled { get; set; }
        public string Motd { get; set; }
    }
}
