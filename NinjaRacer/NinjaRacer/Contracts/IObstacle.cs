namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface IObstacle : ICollidable, IRenderable, IMovable
    {
        int DamagePoints { get; }
    }
}