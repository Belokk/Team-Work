namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections;
    interface IObstacle : ICollidable, IRenderable, IMovable
    {
        int DamagePoints { get; }
    }
}
