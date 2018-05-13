namespace ESIConnectionLibrary.ESIModels
{
    internal enum EsiContractsStatus
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