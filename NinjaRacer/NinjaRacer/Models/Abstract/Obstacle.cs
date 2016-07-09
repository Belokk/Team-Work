namespace NinjaRacer.Models.Abstract
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Models.Vehicles;
    using NinjaRacer.Contracts;

    public abstract class Obstacle : MovingObject, IRenderable, IObstacle
    {
        public int damagePoints;

        public Obstacle(Texture2D texture, Vector2 position, int speed, int demagePoints) : base(texture, position, speed)
        {
            this.DamagePoints = demagePoints;
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if(value > 0)
                {
                    this.damagePoints = value;
                }
                else
                {
                    throw new ArgumentException("Damage points can't be 0 or less");
                }
            }
        }

        public virtual void DetectCollision(PlayerCar playerCar)
        {
            if (this.BoundingBox.Intersects(playerCar.BoundingBox))
            {
                playerCar.Health -= this.DamagePoints;
            }
        }
    }
}