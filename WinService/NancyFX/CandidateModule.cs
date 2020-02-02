using System;
using System.Collections.Generic;
using Controller;
using DataAccessLayer;
using Model;
using Nancy;
using Nancy.Helpers;
using Nancy.ModelBinding;

namespace WinService.NancyFX
{
    public sealed class CandidateModule : NancyModule
    {

        public CandidateModule() : base("/candidate")
        {
            Get("/{technology}/{years}", _ => GetCandidatesByTechnology());
            Put("/accept/{recruiterId}/{candidateId}}", _ => Accept(_, true));
            Put("/reject/{recruiterId}/{candidateId}}", _ => Accept(_, false));
            Get("/accepted", _ => GetAcceptedCandidates());
            Put("/promote/{id}", _ => PromoteCandidate(_));
        }

        private dynamic PromoteCandidate(dynamic _)
        {
            throw new NotImplementedException();
        }

        private dynamic GetAcceptedCandidates()
        {
            throw new NotImplementedException();
        }

        private dynamic Accept(dynamic _, bool accept)
        {
            try
            {
                //get parameters
                var model = this.Bind<RequestObject>();
                using (var uw = new UnitOfWork())
                {
                    Candidates.Accept(uw, model.RecruiterId, model.CandidateId, accept);
                }

                return null;
            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic GetCandidatesByTechnology()
        {
            try
            {
                //get parameters
                var model = this.Bind<RequestObject>();
                string technology = HttpUtility.UrlDecode(model.Technology);
                using (var uw = new UnitOfWork())
                {
                    IEnumerable<Candidate> candidatesByTechnology;
                    if (int.TryParse(technology, out var technologyId))
                    {
                        candidatesByTechnology = Candidates.GetCandidates(uw, technologyId, model.Years);
                        return candidatesByTechnology;
                    }
                    else
                    {
                        candidatesByTechnology = Candidates.GetCandidates(uw, technology, model.Years);
                    }
                    //load entities before serialization
                    var candidatesDto = new List<CandidateDto>();
                    foreach (var candidate in candidatesByTechnology)
                    {
                        candidatesDto.Add(new CandidateDto(candidate));
                    }
                    return Response.AsJson(candidatesDto);

                }
            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
            }

        }

    }
}