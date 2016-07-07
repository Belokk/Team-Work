namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public class BigHole : Hole, IObstacle, IRenderable
    {
        public override void LoadContent(ContentManager content, string fileName)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
