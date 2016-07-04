namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Animal : MovingObject, IObstacle ,IRenderable, IMovable
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
