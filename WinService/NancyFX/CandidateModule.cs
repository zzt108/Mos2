using System;
using Controller;
using Nancy;

namespace WinService.NancyFX
{
    public sealed class CandidateModule : NancyModule
    {

        public CandidateModule() : base("/Candidate")
        {
            Get("/{technology}/{years}", _ => GetCandidatesByTechnology(_));
        }

        private static object GetCandidatesByTechnology(dynamic _)
        {
            if (int.TryParse(_.year, out int years))
            {
                try
                {
                    string technology = _.technology.ToString();
                    if (int.TryParse(technology, out var technologyId))
                    {
                        return Candidates.GetCandidates(technologyId, years);

                    }
                    else
                    {
                        return Candidates.GetCandidates(technology, years);
                    }
                }
                catch (Exception e)
                {
                    return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Helper.ErrorResponse(new ArgumentException("Invalid parameter", nameof(years)), HttpStatusCode.InternalServerError);
            }

        }

    }
}