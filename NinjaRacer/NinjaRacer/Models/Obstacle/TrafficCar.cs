namespace NinjaRacer.Models.Obstacle
{
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using Microsoft.Xna.Framework.Content;

    public class TrafficCar : Obstacle, IRenderable, IMovable
    {

        public TrafficCar(Texture2D texture, Vector2 position, int speed, int damagePoints) : base(texture, position, speed, damagePoints)
        {
        }

        public void DetectCollision()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.BoundingBox, Color.White);
        }

        public override void LoadContent(ContentManager content, string fileName)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
