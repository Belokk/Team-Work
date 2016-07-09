namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Vehicles;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bonus : MovingObject, IMovable, ICollidable, IDestructable, IRenderable, IBonus
    {
        private const int MinBonusPoints = 5;
        private const int MaxBonusPoints = 200;
        private const int BonusSpawnCoordY = -100;
        private const string OutOfRangeMessage = "The bonus points should be between {0}, {1}";
        private Random randomSpawnPositionX = new Random();
        private int bonusPoints;

        public Bonus(Texture2D texture, int speed)
            : base(texture, new Vector2(), speed)
        {
            this.Position = new Vector2(this.RandomPositionX, BonusSpawnCoordY);
            this.IsVisible = true;
          //  this.BonusPoints = bonusPoints;

        }

        public bool IsVisible { get; set; }

        public int BonusPoints
        {
            get
            {
                return this.bonusPoints;
            }

            private set
            {
                if (value <= MinBonusPoints || value > MaxBonusPoints)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.bonusPoints), OutOfRangeMessage);
                }

                this.bonusPoints = value;
            }
        }

        private int RandomPositionX
        {
            get
            {
                return this.randomSpawnPositionX.Next(Graphic.LeftOutOfRoadPosition, Graphic.RightOutOfRoadPosition - this.Texture.Width);
            }
        }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(PlayerCar playerCar);

        // Update
        public override void Update(GameTime gameTime, int currentSpeed)
        {
            // update movement
                this.PositionY = this.PositionY + (currentSpeed > this.Speed ? this.Speed : currentSpeed);
            if (this.PositionY >= Graphic.WindowHeight)
            {
                this.DestroyObject();
            }
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible)
            {
                spriteBatch.Draw(this.Texture, this.Position, Color.White);
            }
        }
    }
}
