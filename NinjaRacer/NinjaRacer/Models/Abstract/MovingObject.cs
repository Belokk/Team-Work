namespace NinjaRacer.Models.Abstract
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    using Contracts;

    public abstract class MovingObject : IRenderable, IMovable
    {
        public Vector2 position;
        private int speed;
        private Texture2D texture;

        public MovingObject(Texture2D texture, Vector2 position, int speed)
        {
            this.Texture = texture;
            this.Position = position;
            this.Speed = speed;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
            private set
            {
                this.texture = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Speed can not be assigned 0 or negative.");
                }

                this.speed = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int) this.Position.X, (int) this.Position.Y, this.Texture.Width, this.Texture.Height);
            }
        }

        public virtual void LoadContent(ContentManager content, string fileName)
        {
            this.Texture = content.Load<Texture2D>(fileName);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.position);
        }

        public abstract void Update(GameTime gameTime);
    }
}
