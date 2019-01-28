namespace ESIConnectionLibrary.PublicModels
{
    public class V3MailLabelsAndUnreadCountLabels
    {
        public MailLabelColor? Color { get; set; }
        public int? LabelId { get; set; }
        public string Name { get; set; }
        public int? UnreadCount { get; set; }
    }
}