namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal abstract class Vehicle : MovingObject, IMovable, ICollidable
    {
        public Vehicle(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
        }

        public void CollisionDetection()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.position);
        }
    }
}
