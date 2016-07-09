﻿
namespace NinjaRacer.Contracts
{
    using NinjaRacer.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public interface IRenderable
    {
        Texture2D Texture { get; }

        Rectangle BoundingBox { get; }

        void LoadContent(ContentManager content, string fileName);

        void Update(GameTime gameTime, int currentSpeed);

        void Draw(SpriteBatch spriteBatch);
    }
}
