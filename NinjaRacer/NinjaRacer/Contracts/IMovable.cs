namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;

    public interface IMovable : IRenderable
    {
        int Speed { get; }

        float PositionX { get; set; }

        float PositionY { get; set; }
    }
}
