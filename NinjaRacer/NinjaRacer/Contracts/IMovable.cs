namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface IMovable
    {
        int Speed { get; }

        void Update(GameTime gameTime);

    }
}
