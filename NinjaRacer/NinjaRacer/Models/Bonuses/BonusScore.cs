namespace NinjaRacer.Models.Bonuses
{
    using Contracts;
    using Abstract;
    using Vehicles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BonusScore : BonusObject, IMovable, ICollidable, IDestructable
    {
        private const int ScoreBonus = 50;

        public BonusScore(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
        }

        public override void DistributeBonusEffect(PlayerCar player)
        {
            player.Score += ScoreBonus;
        }
    }
}
