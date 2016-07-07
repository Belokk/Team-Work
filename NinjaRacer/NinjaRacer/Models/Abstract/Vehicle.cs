namespace NinjaRacer.Models.Abstract
{
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal abstract class Vehicle : MovingObject, IMovable
    {
        public Vehicle(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.position);
        }
    }
}
