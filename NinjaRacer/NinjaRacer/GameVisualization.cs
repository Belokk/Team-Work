﻿using NinjaRacer.Models.Obstacle;

namespace NinjaRacer
{
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using SoundsAndVisuals;
    using Models;
    using Models.Vehicles;
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameVisualization : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Scrolling Background
        //Scrolling Background
        RoadMap FirstRoadMap;
        RoadMap SecondRoadMap;
        BigHole hole;
        public HUD Hud { get; private set; }

        private PlayerCar car;
        private int carInitialX = Grafic.CarInitialPositionX;
        private int carInitialY = Grafic.CarInitialPozitionY;

        private int roadSpeed = Movement.RoadSpeed;

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Grafic.WindowWidth;
            graphics.PreferredBackBufferHeight = Grafic.WindowHeight;
            Content.RootDirectory = Grafic.RootDirectory;
            Hud = new HUD();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// LoadContent will be called once per game and is the place to load
        /// all of your content.

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //  car = Content.Load<Texture2D>("car");  //TODO
            //var carW = 
            // var carX = carInitialX - carW;
            car = new PlayerCar(Content.Load<Texture2D>("car"),
                new Vector2(carInitialX - 36, carInitialY), Movement.CarAcceleration);


            //Loading the two backgrounds that will scroll(they are the same)
            FirstRoadMap = new RoadMap(Content.Load<Texture2D>("newBG"),
                new Rectangle(200, 0, 400, 600),
                roadSpeed,
                graphics.PreferredBackBufferHeight);
            SecondRoadMap = new RoadMap(Content.Load<Texture2D>("newBG"),
                new Rectangle(200, -600, 400, 600),
                roadSpeed,
                graphics.PreferredBackBufferHeight);
            
            hole = new BigHole(Content.Load<Texture2D>("hole"),new Rectangle(240, 20, 20, 20), roadSpeed, graphics.PreferredBackBufferHeight);

            this.Hud.LoadContent(this.Content);
        }

        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here   
            // TODO: List of IDrowlable and update with foreach loop
            FirstRoadMap.Update();
            SecondRoadMap.Update();
            car.Update();
            Hud.Update(gameTime);
            hole.Update();

            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            // TODO: List of IDrawable and  with foreach loop
            FirstRoadMap.Draw(spriteBatch);
            SecondRoadMap.Draw(spriteBatch);
            car.Draw(spriteBatch);
            Hud.Draw(spriteBatch);
            hole.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

