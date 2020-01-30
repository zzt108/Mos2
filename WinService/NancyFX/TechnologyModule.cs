using System;
using Nancy;

namespace WinService.NancyFX
{
    public sealed class TechnologyModule : NancyModule
    {
        public TechnologyModule() : base("/Technology")
        {
            Get("/", _ => GetAll());
        }

        private static object GetAll()
        {
            try
            {
                return Controller.Technologies.GetAll();
            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e, HttpStatusCode.InternalServerError);
            }
        }

    }
}