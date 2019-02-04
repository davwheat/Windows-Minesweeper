using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Sim_Toolkit
{
    public class DebugMessage
    {
        private readonly MessageType type;
        private readonly string message;

        public DebugMessage(MessageType type, string message)
        {
            this.message = message;
            this.type = type;
        }

        public DebugMessage(string message)
        {
            type = MessageType.Other;
            this.message = message;
        }

        public override string ToString()
        {
            var line = "";

            line += DateTime.Now.ToString("T").PadRight(10) + " | ";
            line += nameof(type) . PadRight(10) + " | ";
            line += message;
            line += "\n";

            return line;
        }
    }

    public enum MessageType
    {
        Other = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }
}
