namespace NinjaRacer
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Infrastructure.Constants;
    using Models;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Scrolling Background
        Track First;  // to rename
        Track Second;

        private Car car;
        private int carInitialX = Grafic.CarInitialPositionX;
        private int carInitialY = Grafic.CarInitialPozitionY;

        private int roadSpeed = Movement.RoadSpeed;

        public GameEngine()
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
            car = new Car(Content.Load<Texture2D>("car"), new Vector2(carInitialX, carInitialY), 3);
            //Loading the two backgrounds that will scroll(they are the same)
            First = new Track(Content.Load<Texture2D>("newBG"), new Rectangle(0, 0, 412, 550), roadSpeed, graphics.PreferredBackBufferHeight);
            Second = new Track(Content.Load<Texture2D>("newBG"), new Rectangle(0, -550, 412, 550), roadSpeed, graphics.PreferredBackBufferHeight);
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
            GraphicsDevice.Clear(Color.Black);

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
