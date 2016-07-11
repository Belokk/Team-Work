namespace NinjaRacer.Models.Obstacle
{
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework.Graphics;

    public class SmallHole : Hole, IObstacle, IRenderable, ICollidable
    {
        private const int SmallHoleDamagePoints = 10;

        public SmallHole(Texture2D texture) 
            : base(texture)
        {
            this.DamagePoints = SmallHoleDamagePoints;
        }
    }
}
