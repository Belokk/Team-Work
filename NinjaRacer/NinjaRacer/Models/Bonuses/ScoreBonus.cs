namespace NinjaRacer.Models.Bonuses
{
    using Abstract;
    using Contracts;
    using Microsoft.Xna.Framework.Graphics;

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
