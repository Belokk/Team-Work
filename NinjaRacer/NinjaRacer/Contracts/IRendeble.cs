
namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IRendeble
    {
        Texture2D Texture { get; }

        Vector2 Position { get; }

        Rectangle Rectangle { get; }

        void Draw(SpriteBatch spriteBatch);
    }
}
