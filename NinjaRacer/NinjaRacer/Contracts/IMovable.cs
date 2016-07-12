namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;

    public interface IMovable : IRenderable
    {
        int Speed { get; set; }

        Vector2 Position { get; set; }

        float PositionX { get; set; }

        float PositionY { get; set; }
    }
}
