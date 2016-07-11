namespace NinjaRacer.Models
{
    using System;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Infrastructure.Constants;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework.Content;

    public class RoadMap : MovingObject, IMovable, IRenderable, IRoad
    {
        private const float FirstCoordY = 0;
        private const float SecondCoordY = -600;
        private const float CoordX = 50;
        private const int RoadHight = Graphic.WindowHeight;
        private const int RoadWidh = 400;
        private Vector2 secondPosition;
        private static RoadMap instance = null;
        private int currentSpeed = 0;
        private decimal acceleration = 0.1M;  // 

        private RoadMap(Texture2D texture, Vector2 position, int speed)
            : base(null, new Vector2(CoordX, FirstCoordY), Graphic.RoadMapSpeed)
        {
            this.secondPosition = new Vector2(CoordX, SecondCoordY);
        }

        private RoadMap()
            : this(null, new Vector2(CoordX, FirstCoordY), Graphic.RoadMapSpeed)
        {
        }

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

        public Vector2 SecondPosition
        {
            get
            {
                return this.secondPosition;
            }
        }

        public static RoadMap GetInstance()
        {
            if (instance == null)
            {
                instance = new RoadMap();
            }

            return instance;
        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
            spriteBatch.Draw(this.Texture, this.SecondPosition, Color.White);
        }

        // Update
        public override void Update(GameTime gameTime, int updateSpeed = 0)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                // acceleration
                if (this.CurrentSpeed < this.Speed)
                {
                    this.CurrentSpeed += 1;
                }

                this.PositionY += this.CurrentSpeed;
                this.secondPosition.Y += this.CurrentSpeed;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                // brake
                if (this.CurrentSpeed > 0 && this.CurrentSpeed % 2 == 0)
                {
                    this.CurrentSpeed -= 2;
                }
                else if (this.CurrentSpeed > 0)
                {
                    this.CurrentSpeed -= 1;
                }

                this.PositionY += this.CurrentSpeed;
                this.secondPosition.Y += this.CurrentSpeed;
            }
            else
            {
                if (this.CurrentSpeed > 0)
                {
                    this.CurrentSpeed -= 1;
                }

                this.PositionY += this.CurrentSpeed;

                this.secondPosition.Y += this.CurrentSpeed;
            }

            // Scrolling background (Repeating)
            if (this.PositionY >= Graphic.WindowHeight)
            {
                this.PositionY = 0;
                this.secondPosition.Y = -Graphic.WindowHeight;
            }
        }
    }
}
