﻿using System;
using Model;
using Nancy;
using Nancy.ModelBinding;

namespace Api.NancyFX
{
    public sealed class RecruiterModule : NancyModule
    {
        // this is a temporary solution, as API calls should specify recruiter token
        public const int LoggedInRecruiterId = 1;
        public RecruiterModule() : base("/Recruiter")
        {
            Get("/login/{email}/{password}", _ => LoginRecruiter(_));
            Post("/add}", _ => Add());

            Response Add()
            {
                try
                {
                    var model = this.Bind<Recruiter>();
                    Controller.Recruiters.Add(model);

                    return Helper.ErrorResponse(null, HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
                }
            }

            dynamic LoginRecruiter(dynamic _)
            {
                try
                {
                    var r = Controller.Recruiters.GetByEmail(_.email.ToString());
                    return r == null ? Helper.ErrorResponse(new ArgumentException($"Email '{_.email}' not found"), HttpStatusCode.NotFound) : r.Name ;
                }
                catch (Exception e)
                {
                    return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
                }
            }
        }

    }



}