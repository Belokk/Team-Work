namespace NinjaRacer.Models.Bonuses
{
    using Contracts;
    using Abstract;
    using Vehicles;
    using SoundsAndVisuals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class ScoreBonus : Bonus, IMovable, ICollidable, IDestructable
    {
        private const int scoreBonus = 50;

        public ScoreBonus(Texture2D texture, Vector2 position, int speed) : 
            base(texture, position, speed)
        {
        }

        public override void DetectCollision(PlayerCar player)
        {
            if (player.BoundingBox.Intersects(this.BoundingBox))
            {
                player.Score += scoreBonus;
                this.DestroyObject();
            }
        }
    }
}
