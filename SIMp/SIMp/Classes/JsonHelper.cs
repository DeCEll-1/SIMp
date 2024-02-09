using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SIMp.Classes;

namespace SSSystemGenerator.Classes
{
    public class JsonHelper
    {
        public static List<Systems> returnListOfSystems()
        {
            List<Systems> list = new List<Systems>();

            bufferListClass bufferList = new bufferListClass();

            using (StreamReader sr = new StreamReader(Statics.SystemLocJsonDir.FullName))
            {
                string json = sr.ReadToEnd();

                bufferList = JsonConvert.DeserializeObject<bufferListClass>(json);

            }

            foreach (object[] buffer in bufferList.SystemList)
            {
                if (buffer[0].ToString() == "" || int.Parse(buffer[1].ToString()) < 0 || int.Parse(buffer[2].ToString()) < 0) continue;



                list.Add(new Systems(buffer[0].ToString(), new System.Drawing.Point(int.Parse(buffer[1].ToString()), int.Parse(buffer[2].ToString()))));

            }


            return list;
        }

        public static SystemData getSystemData(string ID)
        {

            if (Statics.systemDataList.Count == 0)
            {
                List<SystemData> systemDatas = new List<SystemData>();

                using (StreamReader sr = new StreamReader(Statics.SystemDataJsonDir.FullName))
                {
                    string json = sr.ReadToEnd();

                    systemDatas = JsonConvert.DeserializeObject<List<SystemData>>(json);
                }

                systemDatas.ForEach(data =>
                {
                    data.SeperateConnecteds();
                });

                Statics.systemDataList = systemDatas;
            }

            return Statics.systemDataList.FirstOrDefault(data => data.SystemName == ID);
        }
    }

    public class bufferListClass
    {
        public object[][] SystemList;
    }

}
