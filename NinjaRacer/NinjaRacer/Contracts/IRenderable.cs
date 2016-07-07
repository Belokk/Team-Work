
namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public interface IRenderable
    {
        Texture2D Texture { get; }

        Rectangle BoundingBox { get; }

        void LoadContent(ContentManager content, string fileName);

        void Draw(SpriteBatch spriteBatch);
    }
}
