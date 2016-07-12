namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public interface IRenderable
    {
        Texture2D Texture { get; }

        Rectangle BoundingBox { get; }

        void LoadContent(ContentManager content, string fileName);

        void Update(GameTime gameTime, int updateSpeed = 0);

        void Draw(SpriteBatch spriteBatch);
    }
}
