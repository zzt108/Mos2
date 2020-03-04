using System;
using Nancy;

namespace Api.NancyFX
{
    public static class Helper 
    {

        public static Response ErrorResponse(Exception e, HttpStatusCode httpStatusCode)
        {
            //log for test runner
            Console.WriteLine(e?.Message);
            var r = (Response) $"[{e?.Message}]";
            r.StatusCode = httpStatusCode;
            return r;
        }
    }
}