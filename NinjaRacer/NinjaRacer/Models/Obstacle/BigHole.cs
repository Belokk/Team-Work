namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BigHole : Hole, IObstacle, IRenderable
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
