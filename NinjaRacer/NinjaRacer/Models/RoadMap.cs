﻿namespace NinjaRacer.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Infrastructure.Constants;
    using Contracts;
    using Abstract;
    using Microsoft.Xna.Framework.Content;

    public class RoadMap : MovingObject, IMovable, IRenderable
    {
        private const float FirstCoordY = 0;
        private const float SecondCoordY = -600;
        private const float CoordX = 200;
        private const int RoadHight = Graphic.WindowHeight;
        private const int RoadWidh = 400;
        private Vector2 secondPosition;
        private static RoadMap instance = null;

        private RoadMap(Texture2D texture, Vector2 position, int speed)
            : base(null, new Vector2(200, FirstCoordY), Graphic.RoadMapSpeed)
        {
            this.secondPosition = new Vector2(CoordX, SecondCoordY);
        }

        private RoadMap()
            : this(null, new Vector2(200, FirstCoordY), Graphic.RoadMapSpeed)
        {
        }

        public Vector2 SecondPosition { get { return this.secondPosition; } }

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
            spriteBatch.Draw(this.Texture, this.position, Color.White);
            spriteBatch.Draw(this.Texture, this.SecondPosition, Color.White);
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Setting speed for background scrolling
            this.position.Y = this.position.Y + this.Speed;
            this.secondPosition.Y = this.secondPosition.Y + this.Speed;

            // Scrolling background (Repeating)
            if (this.position.Y >= Graphic.WindowHeight)
            {
                this.position.Y = 0;
                this.secondPosition.Y = -Graphic.WindowHeight;
            }
        }
    }
}
