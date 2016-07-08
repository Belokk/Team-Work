namespace NinjaRacer.Models.Vehicles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Infrastructure.Constants;
    using Contracts;
    using Abstract;
    using System;

    internal class PlayerCar : Vehicle, IMovable, ICollidable
    {
        private int score;
        private int health;
        private int acseleration;

        private static PlayerCar instance = null;

        private const float width = 90; //74 Width of the ship texture in pixels. Will change if ship pic is changed.
        private const float height = 152; // Height of the ship texture in pixels. Will change if ship pic is changed.

        public PlayerCar(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
            this.Health = Graphic.InitialPlayerHealth;
            this.Score = Graphic.InititalPlayerScore;
            this.acseleration = 1;
        }

        //car = new PlayerCar(Content.Load<Texture2D>("car"),
        //    new Vector2(carInitialX - 36, carInitialY), Movement.CarAcceleration);

        public PlayerCar()
            : this(null, new Vector2(400 - width / 2, 600 - height - 100), 5)
        {
        }

        public static PlayerCar GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerCar();
            }

            return instance;
        }
        //public int Health
        //{
        //    get
        //    {
        //        return this.Health1;
        //    }

        //    private set
        //    {
        //        // TODO Custom exception Car Crash
        //        this.Health1 = value;
        //    }
        //}

        public int Score
        {
            get
            {
                return this.score;

            }
            private set
            {
                // TODO Exeption
                this.score = value;
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
                health = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //move right
                if (this.position.X < Graphic.WindowWidth - this.Texture.Width - Graphic.BufferWidth)
                {
                    this.position.X += this.Speed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ///move left
                if (this.position.X > Graphic.BufferWidth)
                {
                    this.position.X -= this.Speed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                ///move up
                if (this.position.Y > Graphic.BufferHeight)
                {
                    this.position.Y -= this.Speed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                ///move down
                if (this.position.Y < Graphic.WindowHeight - this.Texture.Height)
                {
                    this.position.Y += this.Speed;
                }
            }
        }

        public void CollisionDetection()
        {
            throw new NotImplementedException();
        }
    }
}

