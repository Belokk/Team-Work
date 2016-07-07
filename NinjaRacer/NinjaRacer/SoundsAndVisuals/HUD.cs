namespace NinjaRacer.SoundsAndVisuals
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Input;
    using Contracts;
    using Infrastructure.Constants;

    public class HUD : IRenderable
    {
        private int playerScore;
        private int playerHealth;

        //Constructor
        public HUD()
        {
            this.PlayerScore = Graphic.InititalPlayerScore;
            this.ShowHud = true;
            this.PlayerScoreFont = null;
            this.PlayerHealth = Graphic.InitialPlayerHealth;
        }

        public Texture2D HealthTexture { get; private set; }
        public Rectangle HealthRectangle { get; private set; }

        public int PlayerScore // to be connected with Player.Score
        {
            get { return this.playerScore; }
            set { this.playerScore = value; }
        }

        public int PlayerHealth // to be connected with Player.Health
        {
            get { return this.playerHealth; }
            set { this.playerHealth = value; }
        }

        public bool ShowHud { get; set; }

        public SpriteFont PlayerScoreFont { get; set; }

        //Load Content
        public void LoadContent(ContentManager Content, string fileName)
        {
            this.PlayerScoreFont = Content.Load<SpriteFont>("georgia");
            this.HealthTexture = Content.Load<Texture2D>(fileName);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            //Get KeyboardState
            KeyboardState keyState = Keyboard.GetState();

            this.HealthRectangle = new Rectangle((int)HealthBarPosition.X, (int)HealthBarPosition.Y,
                this.PlayerHealth, this.HealthTexture.Width);
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.PlayerScoreFont, string.Format("Score {0}", this.PlayerScore), this.ScorePosition, Color.White);
            spriteBatch.Draw(this.HealthTexture, this.HealthRectangle, Color.White);

        }

        public readonly Vector2 ScorePosition = new Vector2(Graphic.ScoreCoordX, Graphic.ScoreCoordY);

        public readonly Vector2 HealthBarPosition = new Vector2(Graphic.HealthBarCoordX, Graphic.HealthBarCoordY);

        public Rectangle Rectangle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Texture2D Texture
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
