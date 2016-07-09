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
        private const string OutOfRangeMessage = "The bonus points should be between {0}, {1}";

        private int bonusPoints;

        public Bonus(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
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

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(PlayerCar playerCar);

        // Update
        public override void Update(GameTime gameTime, int currenstSpeed)
        {
            // update movement
                this.PositionY = this.PositionY + (currenstSpeed > this.Speed ? this.Speed : currenstSpeed);
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
