namespace NinjaRacer
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    using Contracts;
    using SoundsAndVisuals;
    using SoundsAndVisuals.Sounds;
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

        private IPlayer player;
        private ProgressCar progressPlayer;
        private IHud hud;
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
            this.SoundManager = SoundManager.Instance;
        }

        public IList<Bonus> BonusesList
        {
            get
            {
                return new List<Bonus>(this.bonusesList);
            }
        }

        public Random RandomGenerator { get; private set; }

        public SoundManager SoundManager { get; private set; }

        public void LoadBonuses()
        {
            //Creating random variables for X and Y axis of our bonuses
            //int randX = this.RandomGenerator.Next(Graphic.LeftOutOfRoadPosition, Graphic.RightOutOfRoadPosition);
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);

            //if there are less than 2 bonuses on the screen, then create more until there are 2 again
            //Player must be moving with certain speed in order bonuses to be spawned
            if (this.BonusesList.Count < 2 && this.road.CurrentSpeed >= ScoreAndHealth.MinSpeedToSpawnBonuses) // 2 - min bonuses on screen, 
            {
                if ((BonusType)randBonus == BonusType.ScoreBonus)
                {
                    this.bonusesList.Add(new ScoreBonus(this.Content.Load<Texture2D>("scoreBonus"), 4));
                }
                else
                {
                    this.bonusesList.Add(new HealthBonus(this.Content.Load<Texture2D>("healthBonus"), 4));
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

            this.SoundManager.LoadContent(this.Content, "bonus", "obstacle", "theme");

            this.road.LoadContent(this.Content, "background");

            // Changed start position

            player = new PlayerCar(Content.Load<Texture2D>("car"),
                new Vector2(carInitialX - 36, carInitialY-50), Movement.CarSpeed);

            progressPlayer = new ProgressCar(Content.Load<Texture2D>("progressCar"),
                new Vector2(progressCarInitialX, progressCarInitialY), player.Score);

            hud = new HUD(player, progressPlayer, "georgia");
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
            
            // if (game.state == menu && Keyboard.GetState().IsKeyDown(Keys.Enter))
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) 
            {
                MediaPlayer.Play(this.SoundManager.BGMusic);
            }
            // if (game.state == gameOver)
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MediaPlayer.Stop();
            }

            if (player.IsOutOfRoad)
            {
                // pretty annoying because its playing over and over again, maybe should be removed
                SoundCaller bonusCollected = new SoundCaller(this.SoundManager.BonusSound);
                player.Color = Color.Red;
                if (player.Score >= 1)
                {
                    player.Score--;
                }
                player.Health--;
            }
            else
            {
                player.Color = Color.White;
            }

            foreach (IBonus bonus in this.BonusesList)
            {
                //check if any bonuses are colliding with player
                // if they are set visible to false

                if (player.BoundingBox.Intersects(bonus.BoundingBox))
                {
                    if (bonus.GetType().Name == "ScoreBonus")
                    {
                        SoundCaller bonusCollected = new SoundCaller(this.SoundManager.BonusSound);
                        player.Score += ScoreAndHealth.ScoreBonus;
                        bonus.DestroyObject();
                    }
                    else if (player.Health < 160) // HealthBonus
                    {
                        SoundCaller bonusCollected = new SoundCaller(this.SoundManager.BonusSound);
                        player.Health += ScoreAndHealth.HealthBonus;
                        if (player.Health > 160)
                        {
                            player.Health = 160;
                        }
                        bonus.DestroyObject();
                    }
                }
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

            foreach (IBonus bonus in this.BonusesList)
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

