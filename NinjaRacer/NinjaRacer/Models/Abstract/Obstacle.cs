namespace NinjaRacer.Models.Abstract
{
    using System;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models.Vehicles;
    using NinjaRacer.Contracts;

    public abstract class Obstacle : MovingObject, IObstacle, IDestructable, ICollidable, IMovable, IRenderable
    {
        private int damagePoints;
        private const int ObstacleSpawnCoordY = -100;
        private Random randomSpawnPositionX = new Random();

        public Obstacle(Texture2D texture)
            : base(texture, new Vector2())
        {
            this.Position = new Vector2(this.RandomSpawnPositionX, ObstacleSpawnCoordY);
            this.IsVisible = true;
        }

        private int RandomSpawnPositionX
        {
            get
            {
                return randomSpawnPositionX.Next(Graphic.LeftOutOfRoadPosition, Graphic.RightOutOfRoadPosition - this.Texture.Width);
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }

            protected set
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

        public bool IsVisible { get; set; }

        public virtual void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(IPlayer playerCar);

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