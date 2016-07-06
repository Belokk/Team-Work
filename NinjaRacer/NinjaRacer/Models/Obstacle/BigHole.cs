namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BigHole : RoadMap
    {
        public BigHole(Texture2D texture, Rectangle rectangle, int speed, int trackHeight) : base(texture, rectangle, speed, trackHeight)
        {
        }
    }
}
