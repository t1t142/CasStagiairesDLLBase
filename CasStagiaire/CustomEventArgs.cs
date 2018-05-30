using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classesMetierStagiaires;

namespace CasStagiaire
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(MSection section)
        {
            this.section = section;
        }
        private MSection section;

        public MSection Section
        {
            get { return section; }
            set { section = value; }
        }
    }

}
