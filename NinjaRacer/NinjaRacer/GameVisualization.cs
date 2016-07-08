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
        private readonly RoadMap road = RoadMap.GetInstance();
        //  private PlayerCar playerCar = PlayerCar.GetInstance();
        private PlayerCar playerCar = new PlayerCar();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public HUD Hud { get; private set; }

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Graphic.WindowWidth;
            graphics.PreferredBackBufferHeight = Graphic.WindowHeight;
            Content.RootDirectory = Graphic.RootDirectory;
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


            this.road.LoadContent(this.Content, "newBG3");
            this.playerCar.LoadContent(this.Content, "car");

            //car = new PlayerCar(Content.Load<Texture2D>("car"),
            //    new Vector2(carInitialX - 36, carInitialY), Movement.CarAcceleration);

            this.Hud.LoadContent(this.Content, "healthbar");
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
            //  FirstRoadMap.Update();
            //  SecondRoadMap.Update();
            road.Update(gameTime);
            playerCar.Update(gameTime);
            Hud.Update(gameTime);

            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            // TODO: List of IDrawable and  with foreach loop
            //FirstRoadMap.Draw(spriteBatch);
            //SecondRoadMap.Draw(spriteBatch);

            this.road.Draw(spriteBatch);
            this.playerCar.Draw(spriteBatch);
            Hud.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

