namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Infrastructure;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bonus : MovingObject, IMovable, ICollidable, IDestructable, IRenderable, IBonus
    {
        private const int MinBonusPoints = 5;
        private const int MaxBonusPoints = 200;
        private const int BonusSpawnCoordY = -100;
        private Random randomSpawnPositionX = new Random();
        private int bonusPoints;

        public Bonus(Texture2D texture, int speed)
            : base(texture, new Vector2(), speed)
        {
            this.Position = new Vector2(this.RandomPositionX, BonusSpawnCoordY);
            this.IsVisible = true;
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
                var message = String.Format(
                    Mesages.NumberMustBeBetweenMinAndMax,
                    nameof(this.BonusPoints), MinBonusPoints, MaxBonusPoints);
                Validator.ValidateIntRange(value, MinBonusPoints, MaxBonusPoints, message);

                    this.bonusPoints = value;
            }
        }

        private int RandomPositionX
        {
            get
            {
                return this.randomSpawnPositionX.Next(
                    Graphic.LeftOutOfRoadPosition,
                    Graphic.RightOutOfRoadPosition - this.Texture.Width);
            }
        }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(IPlayer playerCar);

        public override void Update(GameTime gameTime, int currentSpeed)
        {
            this.PositionY = this.PositionY + (currentSpeed > this.Speed ? this.Speed : currentSpeed);

            if (this.PositionY >= Graphic.WindowHeight)
            {
                this.DestroyObject();
            }
        }
    }
}
