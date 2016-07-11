namespace NinjaRacer.Models.Vehicles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Abstract;
    using Contracts;

    public class ProgressCar : Vehicle, IMovable
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