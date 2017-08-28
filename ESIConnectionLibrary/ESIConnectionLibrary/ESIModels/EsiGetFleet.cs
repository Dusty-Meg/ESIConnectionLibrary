namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiGetFleet
    {
        public bool is_free_move { get; set; }
        public bool is_registered { get; set; }
        public bool is_voice_enabled { get; set; }
        public string motd { get; set; }
    }
}
