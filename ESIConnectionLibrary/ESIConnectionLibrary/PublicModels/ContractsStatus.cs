namespace ESIConnectionLibrary.PublicModels
{
    public enum ContractsStatus
    {
        outstanding,
        in_progress,
        finished_issuer,
        finished_contractor,
        finished,
        cancelled,
        rejected,
        failed,
        deleted,
        reversed
    }
}