using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static DynamicDataSyncObject[] objects;
        static async Task Main(string[] args)
        {
            var settings = File.ReadAllText("DynamicDataSyncSetting.json");

            var syncObjects = Newtonsoft.Json.JsonConvert.DeserializeObject<DynamicDataObjectSyncSettings>(settings);

            using (var db = new DbContext())
            {
                var testData = await db.LoadTestData();
            }

            //Type myType = typeof(Account);

            //var properties = myType.GetProperties();

            //foreach (var property in properties)
            //{
            //    var attributes = property.GetCustomAttributes(false);

            //    foreach (var att in attributes)
            //    {                 
            //        var icefAtt = att as IcefPropertyAttribute;

            //        if (icefAtt != null)
            //            Console.WriteLine(icefAtt.Name);
            //    }
            //}
            Traverse(syncObjects);

            foreach (var o in objects)
            {
                Console.WriteLine(o.Name);
            }

            var reverseObjects = objects.Reverse();

            foreach (var o in reverseObjects)
            {
                Console.WriteLine(o.Name);
            }
        }

        private static void Traverse(DynamicDataObjectSyncSettings syncObjectSettings)
        {
            var traverseOrder = new Queue<DynamicDataSyncObject>();

            var Q = new Queue<DynamicDataSyncObject>();
           // var S = new HashSet<DynamicDataSyncObject>();

            foreach (var ob in syncObjectSettings.Objects)
            {
                Q.Enqueue(ob);
              // S.Add(ob);

                while (Q.Count > 0)
                {
                    var e = Q.Dequeue();
                    traverseOrder.Enqueue(e);

                    if (e.childObjects != null)
                    {
                        foreach (var childObject in e.childObjects)
                        {
                            //if (!S.Contains(childObject))
                           // {
                                Q.Enqueue(childObject);
                              //  S.Add(childObject);
                           // }
                        }
                    }
                }
            }
          

            //while (traverseOrder.Count > 0)
            //{
            //    var e = traverseOrder.Dequeue();
            //    Console.WriteLine(e.Name);
            //}
            objects = traverseOrder.ToArray();
        }
    }
}
