﻿namespace NinjaRacer
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
        private HUD hud;
        private readonly IList<BonusObject> bonusesList;

        private int carInitialX = Graphic.CarInitialPositionX;
        private int carInitialY = Graphic.CarInitialPozitionY;
        public const int TypesOfBonuses = 2;

        //  private int roadSpeed = Movement.RoadSpeed;

        public GameVisualization()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Graphic.WindowWidth;
            graphics.PreferredBackBufferHeight = Graphic.WindowHeight;
            Content.RootDirectory = Graphic.RootDirectory;
            this.bonusesList = new List<BonusObject>();
            this.RandomGenerator = new Random();
        }

        public IList<BonusObject> BonusesList
        {
            get
            {
                return new List<BonusObject>(this.bonusesList);
            }
        }

        public Random RandomGenerator { get; private set; }

        public void LoadBonuses()
        {
            //Creating random variables for X and Y axis of our bonuses
            int coordY = 0; // Bonuses will appear on the top part of the screen;
            int randX = this.RandomGenerator.Next(200, 400);
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);

            //if there are less than 2 bonuses on the screen, then create more until there are 2 again
            if (this.BonusesList.Count < 2) // 2 - min bonuses on screen
            {
                switch (randBonus)
                {
                    case 0:
                        this.bonusesList.Add(new BonusScore(this.Content.Load<Texture2D>("pointsBonus"), new Vector2(randX, coordY), 4));
                        break;
                    case 1:
                        this.bonusesList.Add(new BonusScore(this.Content.Load<Texture2D>("pointsBonus"), new Vector2(randX, coordY), 4));
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
            

            this.road.LoadContent(this.Content, "newBG3");

            player = new PlayerCar(Content.Load<Texture2D>("car"),
                new Vector2(carInitialX - 36, carInitialY), Movement.CarSpeed);

            hud = new HUD(player);
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

            foreach (BonusObject bonus in this.BonusesList)
            {
                //check if any bonuses are colliding with player
                // if they are set visible to false
                if (bonus.Position.X == player.Position.X && bonus.Position.X == player.Position.Y)
                {
                    bonus.DistributeBonusEffect(this.player);
                    bonus.DestroyObject();
                }

                bonus.Update(gameTime);
            }

            // TODO: Add your update logic here   
            // TODO: List of IDrowlable and update with foreach loop
            //  FirstRoadMap.Update();
            //  SecondRoadMap.Update();
            road.Update(gameTime);
            player.Update(gameTime);
            hud.Update(gameTime);
            this.LoadBonuses();

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
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            foreach (BonusObject bonus in this.BonusesList)
            {
                bonus.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

