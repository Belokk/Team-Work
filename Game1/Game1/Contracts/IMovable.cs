namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface IMovable
    {
        Texture2D Texture { get; }

        Vector2 Position { get; }

        Rectangle Rectangle { get; }

        int Speed { get; }

        // TODO put update here?
    }
}
