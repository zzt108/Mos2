using System;
using Controller;
using DataAccessLayer;
using Nancy;

namespace WinService.NancyFX
{
    public sealed class CandidateModule : NancyModule
    {

        public CandidateModule() : base("/Candidate")
        {
            Get("/{technology}/{years}", _ => GetCandidatesByTechnology(_));
            Put("/accept/{id}}", _ => Accept(_, true));
            Put("/reject/{id}}", _ => Accept(_, false));
            Get("/accepted", _ => GetAcceptedCandidates());
            Put("/promote/id", _ => PromoteCandidate(_));
        }

        private dynamic PromoteCandidate(dynamic _)
        {
            throw new NotImplementedException();
        }

        private dynamic GetAcceptedCandidates()
        {
            throw new NotImplementedException();
        }

        private static dynamic Accept(dynamic _, bool accept)
        {
            throw new NotImplementedException();
        }

        private static dynamic GetCandidatesByTechnology(dynamic _)
        {
            if (int.TryParse(_.year, out int years))
            {
                try
                {
                    string technology = _.technology.ToString();
                    using (var uw = new UnitOfWork())
                    {
                        if (int.TryParse(technology, out var technologyId))
                        {
                            return Candidates.GetCandidates(uw, technologyId, years);

                        }
                        else
                        {
                            return Candidates.GetCandidates(uw, technology, years);
                        }

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