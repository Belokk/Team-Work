namespace NinjaRacer.Models.Obstacle
{
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Human : MovingObject, IObstacle, IRenderable, IMovable
    {
        public Human(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
        }

        public Human(Texture2D texture, Rectangle rectangle, int speed) : base(texture, rectangle, speed)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
