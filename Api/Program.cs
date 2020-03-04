namespace Api
{
    public static class Program
    {
         /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            var server = new Server();
            server.Start();

            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

        }

    }
}
