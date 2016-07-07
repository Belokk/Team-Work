namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    public abstract class Hole : Obstacle, IObstacle, ICollidable, IRenderable
    {
        public Hole(Texture2D texture, Vector2 position, int speed, int damagePoints) : base(texture, position, speed, damagePoints)
        {
        }
    }
}
