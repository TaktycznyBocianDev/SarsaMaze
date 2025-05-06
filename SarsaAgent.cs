using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SarsaMaze
{
    public class SarsaAgent
    {

        public Vector2 AgentPos { get; set; }
        private readonly int size;

        public SarsaAgent(Vector2 startPos, int size)
        {
            AgentPos = startPos;
            this.size = size;
        }

        public void DrawAgent()
        {
            Raylib.DrawRectangle((int)AgentPos.X * size, (int)AgentPos.Y * size, size, size, Color.Yellow);
        }

    }
}
