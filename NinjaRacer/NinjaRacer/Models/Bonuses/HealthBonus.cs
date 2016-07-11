namespace NinjaRacer.Models.Bonuses
{
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework.Graphics;
    using Infrastructure.Constants;

    public class HealthBonus : Bonus, IMovable, ICollidable, IDestructable
    {
        private const int VealthBonusPoints = 20;

        public HealthBonus(Texture2D texture, int speed) :
            base(texture, speed)
        {
        }

        public override void DetectCollision(IPlayer player)
        {
            if (player.BoundingBox.Intersects(this.BoundingBox) && player.Health < ScoreAndHealth.InitialPlayerHealth)
            {
                player.Health += VealthBonusPoints;
                if (player.Health > 160)
                {
                    player.Health = 160;
                }

                this.DestroyObject();
            }
        }
    }
}
