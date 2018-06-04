using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Packet
    {
        private static int id = 0;
        public int bits;
        public Node from;
        public Node to;
        public int ID;
        public Packet(Node from, Node to, int bits)
        {
            Packet.id++;
            this.ID = Packet.id;
            this.from = from;
            this.to = to;
            this.bits = bits;
        }
    }
}
