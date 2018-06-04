using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Route
    {
        public Node to; //destination of the packet
        public Node via; //to which neighbour forward packet
        public int bits = 0; //number of total bits transfered
        public Route(Node to, Node via)
        {
            this.to = to;
            this.via = via;
        }
        public void SendPacket(Packet packet)
        {
            if(packet.to == this.to)
            {
                bits += packet.bits;
                via.ReceivePacket(packet);
            } else
            {
                Console.WriteLine(String.Format("[{0}]Cannot send packet", packet.ID));
            }
        }
        override public String ToString()
        {
            return String.Format("Route to {0} - {1} bits", to.name, bits);
        }
    }
}
