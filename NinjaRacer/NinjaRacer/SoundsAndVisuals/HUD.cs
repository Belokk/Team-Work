namespace NinjaRacer.SoundsAndVisuals
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Input;
    using Contracts;
    using Models.Vehicles;
    using Infrastructure.Constants;

    public class HUD : IRenderable
    {
        private int playerScore;
        private int playerHealth;

        public HUD(PlayerCar player)
        {
            this.PlayerScore = player.Score;
            this.ShowHud = true;
            this.PlayerScoreFont = null;
            this.PlayerHealth = player.Health;
        }

        public Texture2D Texture { get; private set; }
        public Rectangle Rectangle { get; private set; }

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
            this.Texture = Content.Load<Texture2D>(fileName);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.Rectangle = new Rectangle((int)HealthBarPosition.X, (int)HealthBarPosition.Y,
                this.PlayerHealth, this.Texture.Width);
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.PlayerScoreFont, string.Format("Score {0}", this.PlayerScore), this.ScorePosition, Color.White);
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public readonly Vector2 ScorePosition = new Vector2(Graphic.ScoreCoordX, Graphic.ScoreCoordY);

        public readonly Vector2 HealthBarPosition = new Vector2(Graphic.HealthBarCoordX, Graphic.HealthBarCoordY);

    }
}
