namespace NinjaRacer.Models.Vehicles
{
    using Abstract;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ProgressCar : MovingObject, IMovable
    {
        public ProgressCar(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
        }

        public override void Update(GameTime gameTime, int speed)
        {
            this.Speed = speed;
            this.PositionY = this.PositionY - this.Speed;
            this.Speed = 0;
        }
    }
}