using SSSystemGenerator.Classes;
using SSSystemGenerator.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Classes
{
    public class SystemData
    {

        public string ID { get; set; } // connects to the systems id

        public List<Anomaly> anomalies { get; set; }

        public string SystemName { get; set; }

        public string Status { get; set; }

        public string StarClass { get; set; }

        public int NumberOfConnectedSystems { get; set; }

        public string ConnectedSystemsNotSeperated { get; set; }

        public string[] ConnectedSystems { get; set; }

        public void SeperateConnecteds()
        {
            ConnectedSystems = ConnectedSystemsNotSeperated.Split(',');

            Statics.Lines.Add(SystemName, ConnectedSystems);
        }

    }
}
