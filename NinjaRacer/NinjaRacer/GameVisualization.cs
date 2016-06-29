namespace NinjaRacer
{
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Models;
    using Models.Vechicles;
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameVisualization : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Scrolling Background
        RoadMAp First;  // to rename
        RoadMAp Second;

        private Car car;
        private int carInitialX = Grafic.CarInitialPositionX;
        private int carInitialY = Grafic.CarInitialPozitionY;

        private int roadSpeed = Movement.RoadSpeed;

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Grafic.WindowWidth;
            graphics.PreferredBackBufferHeight = Grafic.WindowHight;
            Content.RootDirectory = Grafic.RootDirectory;
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
            car = new Car(Content.Load<Texture2D>("car"),
                new Vector2(carInitialX - 36, carInitialY), Movement.CarSpeed);


            //Loading the two backgrounds that will scroll(they are the same)
            First = new RoadMAp(Content.Load<Texture2D>("newBG"),
                new Rectangle(200, 0, 400, 600),
                roadSpeed,
               graphics.PreferredBackBufferHeight);
            Second = new RoadMAp(Content.Load<Texture2D>("newBG"),
                new Rectangle(200, -600, 400, 600),
                roadSpeed,
                graphics.PreferredBackBufferHeight);
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
            First.Update();
            Second.Update();
            car.Update();

            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            // TODO: List of IDrowlable and  with foreach loop
            First.Draw(spriteBatch);
            Second.Draw(spriteBatch);
            car.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

