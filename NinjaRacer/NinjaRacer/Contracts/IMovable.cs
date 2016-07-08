namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;

    interface IMovable
    {
        int Speed { get; }

        void Update(GameTime gameTime);

    }
}
