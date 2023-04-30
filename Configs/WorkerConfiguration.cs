using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tankmonitor_service.Configs
{
    public class WorkerConfiguration
    {
        public string? BaseAddress { get; set; }
        public string? AccessToken { get; set; }
        public Guid? LocationGuid { get; set; }
        public Guid? MonitorGuid { get; set; }
        public string? MacAddress { get; set; }
    }
}
