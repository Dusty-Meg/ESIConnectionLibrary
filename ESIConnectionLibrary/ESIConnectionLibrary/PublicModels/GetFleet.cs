namespace ESIConnectionLibrary.PublicModels
{
    public class GetFleet
    {
        public bool IsFreeMove { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsVoiceEnabled { get; set; }
        public string Motd { get; set; }
    }
}
