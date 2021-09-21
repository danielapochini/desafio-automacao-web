namespace DesafioAutomacaoWeb.Utils.Database.Entities
{
    public class BugsEntities
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ReporterId { get; set; }
        public int HandlerId { get; set; }
        public int DuplicateId { get; set; }
        public short Priority { get; set; }
        public short Severity { get; set; }
        public short Reproducibility { get; set; }
        public short Status { get; set; }
        public short Resolution { get; set; }
        public short Projection { get; set; }
        public short Eta { get; set; }
        public int BugTextId { get; set; }
        public string Os { get; set; }
        public string OsBuild { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
        public string FixedInVersion { get; set; }
        public string Build { get; set; }
        public int ProfileId { get; set; }
        public short ViewState { get; set; }
        public string Summary { get; set; }
        public int SponsorshipTotal { get; set; }
        public byte Sticky { get; set; }
        public string TargetVersion { get; set; }
        public int CategoryId { get; set; }
        public int DateSubmitted { get; set; }
        public int DueDate { get; set; }
        public int LastUpdated { get; set; }
    }
}