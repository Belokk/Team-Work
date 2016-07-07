﻿namespace NinjaRacer.Models.Abstract
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using NinjaRacer.Contracts;

    public abstract class Obstacle : IObstacle, IRenderable, ICollidable
    {
        private int damagePoints;
        
        public Vector2 Position
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Rectangle Rectangle
        {
            private set { }
            get
            {
                throw new NotImplementedException();
            }
        }

        public Texture2D Texture
        {
            private set { }
            get
            {
                throw new NotImplementedException();
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }

            set
            {
                if (value > 0)
                {
                    this.damagePoints = value;
                }
                else
                {
                    throw new ArgumentException("Damage points can't be 0 or less");
                }
            }
        }


        public virtual void CollisionDetection()
        {
            throw new NotImplementedException();
        }

        public virtual void LoadContent(ContentManager content, string fileName)
        {
            this.Texture = content.Load<Texture2D>(fileName);
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}