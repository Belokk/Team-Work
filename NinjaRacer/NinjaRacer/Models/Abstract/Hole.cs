﻿namespace NinjaRacer.Models.Abstract
{
    using Contracts;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Hole : Obstacle, IDestructable, IObstacle, ICollidable, IRenderable
    {
        public Hole(Texture2D texture) :
            base(texture)
        {
        }

        private bool HasBeenDrivenThrough { get; set; }

        public override void DetectCollision(IPlayer playerCar)
        {
            if (playerCar.BoundingBox.Intersects(this.BoundingBox))
            {
                if (!this.HasBeenDrivenThrough)
                {
                    this.HasBeenDrivenThrough = true;
                    playerCar.IsInCollisionWithObstacle = true;
                    playerCar.Health -= this.DamagePoints;
                }
                else
                {
                    playerCar.IsInCollisionWithObstacle = false;
                }
            }
        }
    }
}
