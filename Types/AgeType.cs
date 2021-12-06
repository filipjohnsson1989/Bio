﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Types
{
    //Att använda istället för magiska strängar
    //Siffrorna är en minimiålder för varje åldersgrupp
    enum AgeType
    {
        Centenarian = 100,
        Pensioner = 65,
        Adult = 20,
        Young = 5,
        Child = 0,
    }
}
