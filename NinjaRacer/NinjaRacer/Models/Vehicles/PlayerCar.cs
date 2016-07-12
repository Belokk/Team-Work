﻿namespace NinjaRacer.Models.Vehicles
{
    using Abstract;
    using Contracts;
    using Infrastructure;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class PlayerCar : MovingObject, IPlayer, IMovable
    {
        private const int ReduceSpeedX = 2;

        private int score = ScoreAndHealth.InititalPlayerScore;
        private int health = ScoreAndHealth.InitialPlayerHealth;
        private int currentSpeed;

        public PlayerCar(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
            this.Health = ScoreAndHealth.InitialPlayerHealth;
            this.Score = ScoreAndHealth.InititalPlayerScore;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                var message = string.Format(Messages.NumberMustBeBetweenMinAndMax, nameof(this.Score), 0, int.MaxValue);
                Validator.ValidateIntRange(value, 0, int.MaxValue, message);

                this.score = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    throw new CrashException(this.Health);
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public bool IsOutOfRoad
        {
            get
            {
                return this.PositionX <= Graphic.LeftOutOfRoadPosition ||
                     this.PositionX >= Graphic.RightOutOfRoadPosition - this.Texture.Width;
            }
        }

        public bool IsInCollisionWithObstacle { get; set; }

        public bool IsBeeingDamaged
        {
            get
            {
                return this.IsOutOfRoad || this.IsInCollisionWithObstacle;
            }
        }

        public Color Color { get; set; }

        public int CurrentSpeed
        {
            get
            {
                return this.currentSpeed;
            }

            private set
            {
                this.currentSpeed = value;
            }
        }

        public override void Update(GameTime gameTime, int speed = 0)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (this.CurrentSpeed < this.Speed)
                {
                    this.CurrentSpeed += 1;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (this.CurrentSpeed > 0 && this.CurrentSpeed % 2 == 0)
                {
                    this.CurrentSpeed -= 2;
                }
                else if (this.CurrentSpeed > 0)
                {
                    this.CurrentSpeed -= 1;
                }
            }
            else
            {
                if (this.CurrentSpeed > 0)
                {
                    this.CurrentSpeed -= 1;
                }
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D)) && this.CurrentSpeed > 0)
            {
                if (this.PositionX <= Graphic.RightOutOfRoadPosition - this.Texture.Width)
                {
                    this.PositionX += (int)(this.CurrentSpeed / ReduceSpeedX);
                }
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) && this.CurrentSpeed > 0)
            {
                if (this.PositionX > Graphic.LeftOutOfRoadPosition)
                {
                    this.PositionX -= (int)(this.CurrentSpeed / ReduceSpeedX);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
        }
    }
}