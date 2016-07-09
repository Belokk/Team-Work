namespace NinjaRacer.Models.Vehicles
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NinjaRacer.Models.Abstract;
    using NinjaRacer.Contracts;

    public class ProgressCar : Vehicle, IMovable
    {
        public ProgressCar(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
        }
        public override void Update(GameTime gameTime, int speed)
        {
            // update movement
            this.Speed = speed;
            this.PositionY = this.PositionY - this.Speed;
            this.Speed = 0;

        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.Texture, this.Position, Color.White);
            
        }

    }
}