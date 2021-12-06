using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Types
{
    //Att använda istället för magiska strängar
    //Siffror är priserna för varje biljettgrupp
    enum TicketType
    {
        Free = 0,
        Young = 80,
        Pensioner = 90,
        Adult = 120,
    }
}
