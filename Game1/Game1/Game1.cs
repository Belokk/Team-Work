using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Scrolling Background
        Scrolling scrollingFirst;
        Scrolling scrollingSecond;
        //Car
        private Texture2D car;
        //Initial car placement
        private int carXValue = 160;
        private int carYValue = 350;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 412; //width of the window
            graphics.PreferredBackBufferHeight = 550; //height of the window
            Content.RootDirectory = "Content";
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

            car = Content.Load<Texture2D>("car");
            //Loading the two backgrounds that will scroll(they are the same)
            scrollingFirst = new Scrolling(Content.Load<Texture2D>("newBG"), new Rectangle(0, 0, 412, 550), graphics.PreferredBackBufferHeight);
            scrollingSecond = new Scrolling(Content.Load<Texture2D>("newBG1"), new Rectangle(0, -550, 412, 550), graphics.PreferredBackBufferHeight);
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

            scrollingFirst.Update();
            scrollingSecond.Update();

            //TODO: Speed updater

            //update car vector
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //move right
                if(carXValue < graphics.PreferredBackBufferWidth - car.Width - 40) //move only if within the window
                    carXValue += 3; //speed
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //move left
                if (carXValue > 35) //move only if within the window
                    carXValue -= 3; //speed
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //move up
                if (carYValue > 3) //move only if within the window
                    carYValue -= 3; //speed
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //move down
                if (carYValue < graphics.PreferredBackBufferHeight - car.Height - 3) //move only if within the window
                    carYValue += 4; //speed
                
            }

            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            scrollingFirst.Draw(spriteBatch);
            scrollingSecond.Draw(spriteBatch);
            spriteBatch.Draw(car, new Vector2(carXValue,carYValue), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
