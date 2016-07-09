namespace NinjaRacer.Models.Vehicles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Infrastructure.Constants;
    using Contracts;
    using Abstract;
    using System;
    using Microsoft.Xna.Framework.Content;

    public class PlayerCar : Vehicle, IMovable
    {
        private int score = Graphic.InititalPlayerScore;
        private int health = Graphic.InitialPlayerHealth;

        public PlayerCar(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
            this.Health = Graphic.InitialPlayerHealth;
            this.Score = Graphic.InititalPlayerScore;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's score cannot be a negative number.");
                }
                else
                {
                    this.score = value;
                }
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                if (value < 0)
                {
                    // custom
                    throw new ArgumentException("Player's health cannot be a negative number.");
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
                return this.PositionX <= Graphic.LeftOutOfRoadPosition || this.PositionX >= Graphic.RightOutOfRoadPosition - this.Texture.Width;
            }
        }

        public Color Color
        {
            get
            {
                if (this.IsOutOfRoad)
                {
                    return Color.Red;
                }
                else
                {
                    return Color.White;
                }
            }
        }

        public override void Update(GameTime gameTime, int currentSpeed = 0)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //move right
                if (this.PositionX <= Graphic.RightOutOfRoadPosition - this.Texture.Width)
                {
                    this.PositionX += this.Speed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // move left

                if (this.PositionX > Graphic.LeftOutOfRoadPosition)
                {
                    this.PositionX -= this.Speed;
                }
            }
            //if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    // move up
            //    if (this.position.Y > Graphic.BufferHeight)
            //    {
            //        this.position.Y -= this.Speed;
            //    }
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    // move down

            //    if (this.position.Y < Graphic.WindowHeight - this.Texture.Height)
            //    {

            //        this.position.Y += this.Speed;
            //    }
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
        }
    }
}

