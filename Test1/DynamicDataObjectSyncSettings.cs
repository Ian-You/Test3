using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    public class DynamicDataObjectSyncSettings
    {
        public DynamicDataSyncObject[] Objects { get; set; }
    }

    public class DynamicDataSyncObject
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public DynamicDataSyncObject[] childObjects { get; set; }
    }
}
