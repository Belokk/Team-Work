namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IPlayer : IMovable, IRenderable
    {
        int Score { get; set; }

        int Health { get; set; }

        Color Color { get; set; }

        bool IsInCollisionWithObstacle { get; set; }

        bool IsOutOfRoad { get; }

        bool IsBeeingDamaged { get; }
    }
}
