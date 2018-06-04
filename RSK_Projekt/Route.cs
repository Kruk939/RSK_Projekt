using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Route
    {
        public List<Node> to; //destination of the packet
        public Node via; //to which neighbour forward packet
        public int bits = 0; //number of total bits transfered
        public int packetSize = 1024;
        public Route(List<Node> to, Node via)
        {
            this.to = to;
            this.via = via;
        }
        public void SendPacket(Packet packet)
        {
            if(this.to.Contains(packet.to))
            {
                bits += packet.bits;
                via.ReceivePacket(packet);
            } else
            {
                Console.WriteLine(String.Format("[{0}]Cannot send packet", packet.ID));
            }
        }
        public int GetBandwidth(double multiplayer = 2.0)
        {
            return (int)Math.Pow(2.0, Math.Ceiling(Math.Log((multiplayer * (double)bits), 2)));
        }
        public int GetPackets()
        {
            double ret = (double)bits / (double)packetSize;
            return (int)Math.Ceiling(ret);
        }
    }
}
