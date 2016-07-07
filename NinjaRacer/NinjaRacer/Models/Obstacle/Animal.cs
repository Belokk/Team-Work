namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Animal : MovingObject, IObstacle, IRenderable, IMovable
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update (GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public Animal(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
        }

        public Animal(Texture2D texture, Rectangle rectangle, int speed) : base(texture, rectangle, speed)
        {
        }
    }
}
