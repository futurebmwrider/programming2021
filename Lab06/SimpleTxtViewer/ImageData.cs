using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTxtViewer
{
    class ImageData
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.Time;
        }
    }
}
