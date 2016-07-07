namespace NinjaRacer.Models.Obstacle
{
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class TrafficCar : MovingObject, IObstacle, IRenderable, IMovable
    {

        public TrafficCar(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
        }

        public TrafficCar(Texture2D texture, Rectangle rectangle, int speed) : base(texture, rectangle, speed)
        {
        }

        public void CollisionDetection()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
