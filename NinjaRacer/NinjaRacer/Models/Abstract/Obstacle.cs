namespace NinjaRacer.Models.Abstract
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models.Vehicles;
    using NinjaRacer.Contracts;

    public abstract class Obstacle : MovingObject, IObstacle, IDestructable, ICollidable, IMovable, IRenderable
    {
        private int damagePoints;

        public Obstacle(Texture2D texture, Vector2 position, int demagePoints) 
            : base(texture, position)
        {
            this.DamagePoints = demagePoints;
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            protected set
            {
                if (value > 0)
                {
                    this.damagePoints = value;
                }
                else
                {
                    throw new ArgumentException("Damage points can't be 0 or less");
                }
            }
        }

        public bool IsVisible { get; protected set; }

        public virtual void DestroyObject()
        {
            this.IsVisible = false;
        }

        public virtual void DetectCollision(IPlayer playerCar)
        {
            if (this.BoundingBox.Intersects(playerCar.BoundingBox))
            {
                playerCar.Health -= this.DamagePoints;
            }
        }
    }
}