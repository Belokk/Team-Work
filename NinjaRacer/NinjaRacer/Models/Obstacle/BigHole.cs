namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

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
