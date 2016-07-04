namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BigHole : IObstacle, IRenderable
    {
        public Vector2 Position
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Texture2D Texture
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
