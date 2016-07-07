namespace NinjaRacer.Models.Abstract
{
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Vehicle : MovingObject, IMovable
    {
        public Vehicle(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
        }
    }
}
