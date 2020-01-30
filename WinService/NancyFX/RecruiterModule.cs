using System;
using Model;
using Nancy;
using Nancy.ModelBinding;

namespace WinService.NancyFX
{
    public sealed class RecruiterModule : NancyModule
    {

        public RecruiterModule() : base("/Recruiter")
        {
            Post("/add}", _ =>
            {
                try
                {
                    var model = this.Bind<Recruiter>();
                    Controller.Recruiters.Add(model);

                    var r = Response.AsJson(model).WithHeader("Location", $"/recruiter/id/{model.Id}");

                    return r;
                }
                catch (Exception e)
                {
                    return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
                }
            });
        }

   }



}