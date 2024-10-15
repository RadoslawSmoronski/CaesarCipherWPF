using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_cipher
{
    public interface ICipherService
    {
        public int MoveAmount { get; set; }
    }
}
