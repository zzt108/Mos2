using System;
using Nancy;

namespace WinService.NancyFX
{
    public static class Helper 
    {

        public static Response ErrorResponse(Exception e, HttpStatusCode httpStatusCode)
        {
            var r = (Response) $"[{e.Message}]";
            r.StatusCode = httpStatusCode;
            return r;
        }
    }
}