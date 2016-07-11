namespace NinjaRacer.Models.Obstacle
{
    using Abstract;
    using Contracts;
    using Microsoft.Xna.Framework.Graphics;

    public class BigHole : Hole, IObstacle, IRenderable, ICollidable
    {
        private const int BigHoleDamagePoints = 20;

        public BigHole(Texture2D texture) 
            : base(texture)
        {
            this.DamagePoints = BigHoleDamagePoints;
        }
    }
}
