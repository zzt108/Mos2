using System;
using System.Collections.Generic;
using System.Linq;
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
            Get("/{technology}/{years:int}", _ => GetCandidatesByTechnology());
            Get("/accepted", _ => GetAcceptedCandidates());
            Put("/accept/{recruiterId:int}/{candidateId:int}", _ => Accept(_, true));
            Put("/reject/{recruiterId:int}/{candidateId:int}", _ => Accept(_, false));
            Post("/promote/{candidateId:int}/{email}/{password}", _ => PromoteCandidate(_));
        }

        private dynamic PromoteCandidate(dynamic _)
        {
            try
            {
                //get parameters
                var model = this.Bind<RequestObject>();
                using (var uw = new UnitOfWork())
                {
                    var recr = Candidates.Promote(uw, model.CandidateId, model.Email, model.Password);
                    return new RecruiterDto(recr);
                }

            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
            }

        }

        private dynamic GetAcceptedCandidates()
        {
            try
            {
                using (var uw=new UnitOfWork())
                {
                    var candidates = Candidates.GetAcceptedCandidates(uw);
                    return Response.AsJson(candidates.Select(candidate => new CandidateDto(candidate)).ToList());
                }
            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
            }
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
                var technology = HttpUtility.UrlDecode(model.Technology);
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
                    var candidatesDto = candidatesByTechnology.Select(candidate => new CandidateDto(candidate)).ToList();
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