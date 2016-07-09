namespace NinjaRacer.Models.Abstract
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    using Contracts;

    public abstract class MovingObject : IMovable, IRenderable
    {
        private Vector2 position;
        private int speed;
        private Texture2D texture;

        public MovingObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        public MovingObject(Texture2D texture, Vector2 position, int speed)
            : this(texture, position)
        {
            this.Speed = speed;
        }


        public float PositionX
        {
            get
            {
                return this.position.X;
            }
            set
            {
                this.position.X = value;
            }
        }
        public float PositionY
        {
            get
            {
                return this.position.Y;
            }
            set
            {
                this.position.Y = value;
            }
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
                if (value < 0)
                {
                    throw new ArgumentException("Speed can not be assigned negative.");
                }

                this.speed = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.PositionX, (int)this.PositionY, this.Texture.Width, this.Texture.Height);
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

        public virtual void Update(GameTime gameTime, int currentSpeed = 0)
        {
            this.PositionY += this.Speed; //All of the moving objects implement this logic or simmilar(can be overriden)
        }
    }
}
