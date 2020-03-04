using System.ServiceProcess;
using Api;


namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Server _server;

        public Service1()
        {
            InitializeComponent();
            
            _server = new Server();
        }

        public void Start()
        {
            _server.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        protected override void OnStop()
        {
            _server.Stop();
        }
    }
}
