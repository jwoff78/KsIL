﻿using System;
using System.Collections.Generic;

namespace KsIL.Runtime
{
    class Program
    {

        static KsIL KsIL;
        
        static void Main(string[] args)
        {


            KsIL = new KsIL(100, System.IO.File.ReadAllBytes("test.KsIL"));

            

            while (true)
            {
            }
        }
    }
}
