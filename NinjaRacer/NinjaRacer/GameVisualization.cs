namespace NinjaRacer
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using SoundsAndVisuals;
    using Models;
    using Models.Abstract;
    using Models.Vehicles;
    using Models.Bonuses;
    using Infrastructure.Constants;
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameVisualization : Game
    {
        private readonly RoadMap road = RoadMap.GetInstance();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private PlayerCar player;
        private ProgressCar progressPlayer;
        private HUD hud;
        private readonly IList<Bonus> bonusesList;

        private int carInitialX = Graphic.CarInitialPositionX;
        private int carInitialY = Graphic.CarInitialPozitionY;

        private int progressCarInitialX = Graphic.PlayerProgressPositionX;
        private int progressCarInitialY = Graphic.PlayerProgressPositionY;
        private int progressCarSpeed = 0;
        public const int TypesOfBonuses = 2;

        //  private int roadSpeed = Movement.RoadSpeed;

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Graphic.WindowWidth;
            graphics.PreferredBackBufferHeight = Graphic.WindowHeight;
            Content.RootDirectory = Graphic.RootDirectory;
            this.bonusesList = new List<Bonus>();
            this.RandomGenerator = new Random();
        }

        public IList<Bonus> BonusesList
        {
            get
            {
                return new List<Bonus>(this.bonusesList);
            }
        }

        public Random RandomGenerator { get; private set; }

        public void LoadBonuses()
        {
            //Creating random variables for X and Y axis of our bonuses
            //int randX = this.RandomGenerator.Next(Graphic.LeftOutOfRoadPosition, Graphic.RightOutOfRoadPosition);
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);

            //if there are less than 2 bonuses on the screen, then create more until there are 2 again
            //Player must be moving with certain speed in order bonuses to be spawned
            if (this.BonusesList.Count < 2 && this.road.CurrentSpeed >= Graphic.MinSpeedToSpawnBonuses) // 2 - min bonuses on screen, 
            {
                switch (randBonus)
                {
                    case 0:
                        this.bonusesList.Add(new ScoreBonus(this.Content.Load<Texture2D>("scoreBonus"), 4));
                        break;
                    case 1:
                        this.bonusesList.Add(new HealthBonus(this.Content.Load<Texture2D>("healthBonus"), 4));
                        break;
                        // Extend with more, if there is more than 2 types of bonus;
                        //case 2:
                        //    // bonusesList.Add(new SomeOtherKindOfBonus();)
                        //    break;
                }
            }

            // If any of the bonuses in the list were destroyed (or invisible), then remove them from the list
            for (int i = 0; i < this.BonusesList.Count; i++)
            {
                if (!this.bonusesList[i].IsVisible)
                {
                    this.bonusesList.RemoveAt(i);
                    i--;
                }
            }
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
            

            this.road.LoadContent(this.Content, "background");

            // Changed start position

            player = new PlayerCar(Content.Load<Texture2D>("car"),
                new Vector2(carInitialX - 36, carInitialY-50), Movement.CarSpeed);

            progressPlayer = new ProgressCar(Content.Load<Texture2D>("progressCar"),
                new Vector2(progressCarInitialX, progressCarInitialY), player.Score);

            hud = new HUD(player, progressPlayer);
            this.hud.LoadContent(this.Content, "healthbar");
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

            if (player.IsOutOfRoad)
            {
                if (player.Score >= 1)
                {
                    player.Score--;
                }
                player.Health--;
            }

            foreach (Bonus bonus in this.BonusesList)
            {
                //check if any bonuses are colliding with player
                // if they are set visible to false

                bonus.DetectCollision(this.player);
                bonus.Update(gameTime, road.CurrentSpeed);
            }

            // TODO: Add your update logic here   
            // TODO: List of IDrowlable and update with foreach loop
            //  FirstRoadMap.Update();
            //  SecondRoadMap.Update();

            road.Update(gameTime);
            player.Update(gameTime);
            this.LoadBonuses();
            hud.Update(gameTime, road.CurrentSpeed);

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
            road.Draw(spriteBatch);

            foreach (Bonus bonus in this.BonusesList)
            {
                bonus.Draw(spriteBatch);
            }
            
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

