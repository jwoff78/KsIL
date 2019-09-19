﻿using System;

namespace KsIL.Interrupts
{
    public class CPU_Interrupt : Interrupt
    {

        enum codes
        {

            stop = 0x01,
            start = 0x02,

            make = 0x03,
            kill = 0x04,

        }

        public CPU_Interrupt()
        {

            Code = 2;

        }

        public override void Run(byte[] Parameters, CPU CPU)
        {

            codes code = (codes)Parameters[0];

            int ID = BitConverter.ToInt32(Parameters, 1);
            if (ID == Int32.MaxValue)
            {
                ID = CPU.ID;
            }
            uint Point;

            switch (code)
            {

                case codes.stop:

                    CPU.VM.cpu[ID].isRunning = false;

                    break;

                case codes.start:

                    CPU.VM.cpu[ID].isRunning = true;

                    break;

                case codes.make:

                    // what point it code to start at
                    Point = BitConverter.ToUInt32(Parameters, 5);

                    // ID here is a pointer in memory
                    CPU.VM.StartCPU(BitConverter.ToUInt32(Parameters, 1), Point);

                    break;

                case codes.kill:

                    CPU.VM.cpu[ID] = null;

                    break;

            }



        }


    }
}
