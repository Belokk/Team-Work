namespace NinjaRacer.Models.Obstacle
{
    using Contracts;
    using Abstract;
    using Models.Vehicles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class OutOfTheRoad : ICollidable
    {
        //TODO: Collision Detection for leaving the road

        public void DetectCollision(PlayerCar playerCar)
        {
            throw new NotImplementedException();
        }
    }
}
