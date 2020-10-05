using System;
using Nancy;
using Nancy.ModelBinding;

namespace Api.NancyFX
{
    public sealed class TechnologyModule : NancyModule
    {
        public TechnologyModule() : base("/Technology")
        {
            Get("/{pageSize}/{pageNumber}", _ => GetAll());

            object GetAll()
            {
                try
                {
                    var model = this.Bind<RequestObject>();
                    return Controller.Technologies.GetAll(model.PageSize, model.PageNumber);
                }
                catch (Exception e)
                {
                    return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
                }
            }
        }


    }
}