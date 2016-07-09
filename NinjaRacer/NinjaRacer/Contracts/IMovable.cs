namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;

    interface IMovable: IRenderable
    {
        int Speed { get; }
    }
}
