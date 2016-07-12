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
        private const int ScoreBonusPoints = 50;

        public ScoreBonus(Texture2D texture, int speed) :
            base(texture, speed)
        {
        }

        public override void DetectCollision(IPlayer player)
        {
            if (player.BoundingBox.Intersects(this.BoundingBox))
            {
                player.Score += ScoreBonusPoints;
                this.DestroyObject();
            }
        }
    }
}
