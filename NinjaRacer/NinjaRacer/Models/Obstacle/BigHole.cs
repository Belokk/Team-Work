namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public class BigHole : Hole, IObstacle, IRenderable
    {
        private const int BigHoleDamagePoints = 40;
        public BigHole(Texture2D texture, Vector2 position, int damagePoints) 
            : base(texture, position, damagePoints)
        {
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
