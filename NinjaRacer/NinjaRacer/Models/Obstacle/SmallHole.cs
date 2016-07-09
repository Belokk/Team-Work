namespace NinjaRacer.Models.Obstacle
{
    using System;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public class SmallHole : Hole, IObstacle, IRenderable, ICollidable
    {
        private const int SmallHoleDamagePoints = 20;
        public SmallHole(Texture2D texture, Vector2 position, int damagePoints) 
            : base(texture, position, SmallHoleDamagePoints)
        {
            
        }
    }
}
