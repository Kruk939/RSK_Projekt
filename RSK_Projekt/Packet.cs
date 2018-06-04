using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Packet
    {
        private static int id = 0;
        public int bits; //number of bits to transfer
        public Node from; //source of packet
        public Node to; //destination of packet
        public int ID; //packet id
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
