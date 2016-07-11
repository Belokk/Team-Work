namespace NinjaRacer
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    using Contracts;
    using SoundsAndVisuals;
    using SoundsAndVisuals.Sounds;
    using Models;
    using Models.Abstract;
    using Models.Vehicles;
    using Models.Bonuses;
    using Models.Obstacle;
    using Infrastructure.Constants;

    public class GameVisualization : Game
    {
        private const int InitialProgressCarSpeed = 0;
        private const int TypesOfBonuses = 2;
        private const int TypesOfObstacles = 2;
        private const int BonusSpeed = 4;

        private const string ContentRootDirectory = "Content";
        private const string ScoreBonusImage = "scoreBonus";
        private const string HealthBonusImage = "healthBonus";
        private const string SmallRoadHoleImage = "smallRoadHole";
        private const string bigRoadHoleImage = "bigRoadHole";

        private const string BonusColisionSoundFile = "bonus";
        private const string ObstacleColisionSoundFile = "obstacle";
        private const string GameTheamMusicFile = "theme";

        private const string BackgroundImage = "background";
        private const string CarImage = "car";
        private const string ProgressCarImage = "progressCar";
        private const string EightBitFontFile = "8bitFont";
        private const string HelthBarBorderImage = "healthBarBorder";
        private const string HealthBarImage = "healthbar";
        private const string ScoreBonusName = "ScoreBonus";

        private readonly IMovable road = RoadMap.GetInstance();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private int progressCarInitialX = Graphic.PlayerProgressPositionX;
        private int progressCarInitialY = Graphic.PlayerProgressPositionY;

        private IPlayer player;
        private ProgressCar progressPlayer;
        private IHud hud;
        private readonly IList<IBonus> bonusesList;
        private readonly IList<IObstacle> obstaclesList;

        private int carInitialX = Graphic.CarInitialPositionX;
        private int carInitialY = Graphic.CarInitialPozitionY;

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Graphic.WindowWidth;
            graphics.PreferredBackBufferHeight = Graphic.WindowHeight;
            Content.RootDirectory = ContentRootDirectory;
            this.bonusesList = new List<IBonus>();
            this.obstaclesList = new List<IObstacle>();
            this.RandomGenerator = new Random();
            this.SoundManager = SoundManager.Instance;
        }

        public IList<IBonus> BonusesList
        {
            get
            {
                return new List<IBonus>(this.bonusesList);
            }
        }

        public IList<IObstacle> ObstaclesList
        {
            get
            {
                return new List<IObstacle>(this.obstaclesList);
            }
        }

        public Random RandomGenerator { get; private set; }

        public SoundManager SoundManager { get; private set; }

        public static string BigRoadHoleImage
        {
            get
            {
                return bigRoadHoleImage;
            }
        }

        public void LoadBonuses()
        {
            //Creating random variables for X and Y axis of our bonuses
            //int randX = this.RandomGenerator.Next(Graphic.LeftOutOfRoadPosition, Graphic.RightOutOfRoadPosition);
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);

            //if there are less than 2 bonuses on the screen, then create more until there are 2 again
            //Player must be moving with certain speed in order bonuses to be spawned

            if (this.BonusesList.Count < 2 && this.player.CurrentSpeed >= ScoreAndHealth.MinSpeedToSpawnBonusesAndObstacles) // 2 - min bonuses on screen,
            {
                if ((BonusType)randBonus == BonusType.ScoreBonus)
                {

                    this.bonusesList.Add(new ScoreBonus(this.Content.Load<Texture2D>(ScoreBonusImage), BonusSpeed));
                }
                else
                {
                    this.bonusesList.Add(new HealthBonus(this.Content.Load<Texture2D>(HealthBonusImage), BonusSpeed));
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

        public void LoadObstacles()
        {
            int randomObstacle = this.RandomGenerator.Next(0, TypesOfObstacles + 2); //Decrease the chance for an obstacle to appear

            //Max obstacles on screen: 1
            if (this.ObstaclesList.Count == 0 &&

                this.player.CurrentSpeed >= ScoreAndHealth.MinSpeedToSpawnBonusesAndObstacles)
            {
                if ((ObstacleType)randomObstacle == ObstacleType.SmallHole)
                {

                    this.obstaclesList.Add(new SmallHole(this.Content.Load<Texture2D>(SmallRoadHoleImage)));
                }
                else if ((ObstacleType)randomObstacle == ObstacleType.BigHole)
                {

                    this.obstaclesList.Add(new BigHole(this.Content.Load<Texture2D>(bigRoadHoleImage)));
                }
            }

            for (int i = 0; i < this.ObstaclesList.Count; i++)
            {
                if (!this.obstaclesList[i].IsVisible)
                {
                    this.obstaclesList.RemoveAt(i);
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
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            this.SoundManager.LoadContent(this.Content, BonusColisionSoundFile, ObstacleColisionSoundFile, GameTheamMusicFile);

            this.road.LoadContent(this.Content, BackgroundImage);
            //Just for fun
            MediaPlayer.Play(this.SoundManager.BGMusic);
            // Changed start position

            this.player = new PlayerCar(

                Content.Load<Texture2D>(CarImage),
                new Vector2(carInitialX, carInitialY), Movement.CarSpeed);

            this.progressPlayer = new ProgressCar(Content.Load<Texture2D>(ProgressCarImage),
                new Vector2(progressCarInitialX, progressCarInitialY), InitialProgressCarSpeed);

            this.hud = new HUD(player, progressPlayer, EightBitFontFile, HelthBarBorderImage);
            this.hud.LoadContent(this.Content, HealthBarImage);
        }

        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            /*if (game.state == menu && keyboard.getstate().iskeydown(keys.enter))
            //    if (keyboard.getstate().iskeydown(keys.enter))
            //    {
            //        mediaplayer.play(this.soundmanager.bgmusic);
            //    }
            //if (game.state == gameover)
             else*/
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MediaPlayer.Stop();
            }

            try
            {
                if ((player.IsBeeingDamaged) && this.player.CurrentSpeed > 0)
                {
                    if (!player.IsOutOfRoad)
                    {
                        SoundCaller obstacle = new SoundCaller(this.SoundManager.ObstacleSound);
                    }

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

                foreach (Obstacle obstacle in this.ObstaclesList)
                {
                    obstacle.DetectCollision(player);

                    obstacle.Update(gameTime, this.player.CurrentSpeed);
                }
            }
            catch (CrashException)
            {
                Exit();
            }


            foreach (IBonus bonus in this.BonusesList)
            {
                //check if any bonuses are colliding with player
                // if they are set visible to false
                if (player.BoundingBox.Intersects(bonus.BoundingBox))
                {

                    if (bonus.GetType().Name == ScoreBonusName)
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


                bonus.Update(gameTime, this.player.CurrentSpeed);
            }
            // TODO: Add your update logic here
            // TODO: List of IDrowlable and update with foreach loop

            this.road.Update(gameTime, player.CurrentSpeed);
            this.player.Update(gameTime);
            this.LoadBonuses();
            this.LoadObstacles();

            this.hud.Update(gameTime, player.CurrentSpeed);

            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();
            // TODO: List of IDrawable and  with foreach loop
            //FirstRoadMap.Draw(spriteBatch);
            //SecondRoadMap.Draw(spriteBatch);

            this.road.Draw(this.spriteBatch);

            foreach (IObstacle obstacle in this.ObstaclesList)
            {
                obstacle.Draw(this.spriteBatch);
            }

            foreach (IBonus bonus in this.BonusesList)
            {
                bonus.Draw(this.spriteBatch);
            }

            player.Draw(this.spriteBatch);
            hud.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}