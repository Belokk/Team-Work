﻿namespace NinjaRacer.Models.Abstract
{
    using System;

    using Contracts;
    using Infrastructure;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Obstacle : MovingObject, IObstacle, IDestructable, ICollidable, IMovable, IRenderable
    {
        private const int ObstacleSpawnCoordY = -100;

        private int damagePoints;

        private Random randomSpawnPositionX = new Random();

        public Obstacle(Texture2D texture)
            : base(texture, new Vector2())
        {
            this.Position = new Vector2(this.RandomSpawnPositionX, ObstacleSpawnCoordY);
            this.IsVisible = true;
        }

        public bool IsVisible { get; set; }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }

            protected set
            {
                var message = string.Format(
                     Messages.NumberMustBeBetweenMinAndMax,
                     nameof(this.DamagePoints),
                     0,
                     int.MaxValue);
                Validator.ValidateIntRange(value, 0, int.MaxValue, message);

                this.damagePoints = value;
            }
        }

        private int RandomSpawnPositionX
        {
            get
            {
                return this.randomSpawnPositionX.Next(
                    Graphic.LeftOutOfRoadPosition,
                    Graphic.RightOutOfRoadPosition - this.Texture.Width);
            }
        }

        public virtual void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(IPlayer playerVechile);

        public override void Update(GameTime gameTime, int currentSpeed = 0)
        {
            this.Speed = currentSpeed;
            this.PositionY = this.PositionY + currentSpeed;

            if (this.PositionY >= Graphic.WindowHeight)
            {
                this.DestroyObject();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position);
        }
    }
}