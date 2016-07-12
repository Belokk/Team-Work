namespace NinjaRacer
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    using Contracts;
    using Infrastructure.Enum;
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
        private const string StartMenuImage = "StartGame";
        private const string GameOverMenuImage = "EndGame";
        private const string YouWinMenuImage = "Winner";

        private const string BonusColisionSoundFile = "bonus";
        private const string ObstacleColisionSoundFile = "obstacle";
        private const string GameTheamMusicFile = "theme";

        private const string BackgroundImage = "background";
        private const string CarImage = "car";
        private const string ProgressCarImage = "progressCar";
        private const string EightBitFontFile = "8bitFont";
        private const string HelthBarBorderImage = "healthBarBorder";
        private const string HealthBarImage = "healthbar";
        private const string ProgressCarFinishFlag = "FinishFlag";
        private const string ScoreBonusName = "ScoreBonus";

        private const GameType defaultGameType = GameType.Menu;
        private Vector2 menuImagePosition = new Vector2(0, 0);

        private readonly IMovable road = RoadMap.GetInstance();

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private int progressCarInitialX = Graphic.PlayerProgressPositionX;
        private int progressCarInitialY = Graphic.PlayerProgressPositionY;

        private IPlayer player;
        private ProgressCar progressPlayer;
        private IHud hud;
        private readonly IList<IBonus> bonusesList;
        private readonly IList<IObstacle> obstaclesList;
        private IList<IRenderable> gameObjects;

        public GameVisualization()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            this.Graphics.PreferredBackBufferWidth = Graphic.WindowWidth;
            this.Graphics.PreferredBackBufferHeight = Graphic.WindowHeight;
            this.Content.RootDirectory = ContentRootDirectory;
            this.bonusesList = new List<IBonus>();
            this.obstaclesList = new List<IObstacle>();
            this.gameObjects = new List<IRenderable>();
            this.RandomGenerator = new Random();
            this.SoundManager = SoundManager.Instance;
            this.MenuImage = null;
            this.GameOverImage = null;
            this.GameState = GameType.Menu;
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

        public IList<IRenderable> GameObjects
        {
            get
            {
                return new List<IRenderable>(this.gameObjects);
            }
            private set
            {
            }
        }

        public Random RandomGenerator { get; private set; }

        public SoundManager SoundManager { get; private set; }

        public GraphicsDeviceManager Graphics { get; private set; }

        public Texture2D MenuImage { get; private set; }

        public Texture2D GameOverImage { get; private set; }

        public Texture2D YouWinImage { get; private set; }

        public GameType GameState { get; private set; }

        public bool DontPlayMusic { get; set; }

        public bool MuteWasPressed { get; set; }

        private void AddGameObject(IRenderable rendableObject)
        {
            this.GameObjects.Add(rendableObject);
        }

        public void LoadBonuses()
        {
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);
            int randPush = this.RandomGenerator.Next(0, 100);

            if (this.BonusesList.Count < 1 && (randPush == randBonus))
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
            int randomObstacle = this.RandomGenerator.Next(0, TypesOfObstacles + 2);
            int randPush = this.RandomGenerator.Next(0, 50);


            if (this.ObstaclesList.Count == 0 && randPush == randomObstacle)
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.GameState = defaultGameType;

            this.SoundManager.LoadContent(this.Content, BonusColisionSoundFile, ObstacleColisionSoundFile, GameTheamMusicFile);

            MediaPlayer.Play(this.SoundManager.BGMusic);
            this.road.LoadContent(this.Content, BackgroundImage);

            this.MenuImage = Content.Load<Texture2D>(StartMenuImage);
            this.GameOverImage = Content.Load<Texture2D>(GameOverMenuImage);
            this.YouWinImage = Content.Load<Texture2D>(YouWinMenuImage);

            this.player = new PlayerCar(
                Content.Load<Texture2D>(CarImage),
                new Vector2(Graphic.CarInitialPositionX, Graphic.CarInitialPositionX), Movement.CarSpeed);

            this.progressPlayer = new ProgressCar(Content.Load<Texture2D>(ProgressCarImage),
                new Vector2(progressCarInitialX, progressCarInitialY), InitialProgressCarSpeed);

            this.hud = new HUD(player, progressPlayer, EightBitFontFile, HelthBarBorderImage, ProgressCarFinishFlag);
            this.hud.LoadContent(this.Content, HealthBarImage);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            //if (game.state == menu && keyboard.getstate().iskeydown(keys.enter))
            //    if (keyboard.getstate().iskeydown(keys.enter))
            //    {
            //    }
            //if (game.state == gameover)
            //else
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                if (!this.MuteWasPressed)
                {
                    this.MuteWasPressed = true;
                    this.DontPlayMusic = !this.DontPlayMusic;
                }
            }
            else
            {
                this.MuteWasPressed = false;
            }
            if(!DontPlayMusic)
            {
                MediaPlayer.Resume();
            }
            else
            {
                MediaPlayer.Pause();
            }

            if (this.GameState == defaultGameType)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    this.GameState = GameType.Play;
                }
            }
            else if (this.GameState == GameType.Play)
            {
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
                    this.GameState = GameType.Crash;
                }

                foreach (IBonus bonus in this.BonusesList)
                {
                    if (player.BoundingBox.Intersects(bonus.BoundingBox))
                    {

                        if (bonus.GetType().Name == ScoreBonusName)
                        {
                            SoundCaller bonusCollected = new SoundCaller(this.SoundManager.BonusSound);
                            player.Score += ScoreAndHealth.ScoreBonus;
                            bonus.DestroyObject();
                        }
                        else if (player.Health < ScoreAndHealth.InitialPlayerHealth)
                        {
                            SoundCaller bonusCollected = new SoundCaller(this.SoundManager.BonusSound);
                            player.Health += ScoreAndHealth.HealthBonus;
                            if (player.Health > ScoreAndHealth.InitialPlayerHealth)
                            {
                                player.Health = ScoreAndHealth.InitialPlayerHealth; ;
                            }

                            bonus.DestroyObject();
                        }
                    }

                    bonus.Update(gameTime, this.player.CurrentSpeed);
                }
                if(this.progressPlayer.PositionY == 0)
                {
                    this.GameState = GameType.End;
                }
                this.road.Update(gameTime, player.CurrentSpeed);
                this.player.Update(gameTime);
                this.LoadBonuses();
                this.LoadObstacles();
                this.hud.Update(gameTime, player.CurrentSpeed);

                this.AddGameObject(this.road);
                foreach (var item in BonusesList)
                {
                    this.AddGameObject(item);
                }
                this.AddGameObject(this.player);
                this.AddGameObject(this.progressPlayer);
                this.AddGameObject(this.hud);

            }
            else if(this.GameState == GameType.Crash)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            else if(this.GameState == GameType.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            else if(this.GameState == GameType.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();

            if(this.GameState == defaultGameType)
            {
                spriteBatch.Draw(this.MenuImage, menuImagePosition);
            }
            else if (this.GameState == GameType.Play)
            {
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
            }
            else if(this.GameState == GameType.Crash)
            {
                spriteBatch.Draw(this.GameOverImage, menuImagePosition);
            }
            else if(this.GameState == GameType.End)
            {
                spriteBatch.Draw(this.YouWinImage, menuImagePosition);
            }
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}