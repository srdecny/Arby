using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arby.dataclass;
using Newtonsoft.Json;

namespace Arby.util
{
    class JsonFileSerializer
    {
        public static void SerializeSnapshotsToJson(Dictionary<long, List<MarketSnapshot>> Data, Stream File)
        {
            TextWriter Writer = new StreamWriter(File);
            Writer.Write(JsonConvert.SerializeObject(Data));
            Writer.Close();
        }

        public static Dictionary<long, List<MarketSnapshot>> DeserializeSnapshotsFromJson(Stream File)
        {
            TextReader Reader = new StreamReader(File);
            return JsonConvert.DeserializeObject<Dictionary<long, List<MarketSnapshot>>>(Reader.ReadToEnd());
        }
    }
}
