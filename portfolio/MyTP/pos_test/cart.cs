using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_test
{
    internal class cart
    {
        public cart(string id, string name, string count)
        {
            this.id = id;
            this.name = name;
            this.count = count;
        }
        public string id { get; set; }
        public string name { get; set; }
        public string count { get; set; }
        public string format { get { return name + " (" + count + ")"; } }

    }
}
