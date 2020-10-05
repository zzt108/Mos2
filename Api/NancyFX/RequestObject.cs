using System.Diagnostics.CodeAnalysis;
#pragma warning disable 649

namespace Api.NancyFX
{
    //Bind Common URL variables into this temporary object
    //acts as a kind of DTO for request parameters
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class RequestObject
    {
        public int RecruiterId;
        public int CandidateId;
        public string Email;
        public string Password;
        public string Technology;
        public int Years;
        //{pageSize}/{pageNumber}
        public int PageSize;
        public int PageNumber;

    }
}