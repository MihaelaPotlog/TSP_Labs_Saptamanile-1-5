using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class Pacient
    {
        public override string ToString()
        {
            return Id.ToString() + FirstName + " " + LastName;
        } 
    }
}
