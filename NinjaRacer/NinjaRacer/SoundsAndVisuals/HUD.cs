namespace NinjaRacer.SoundsAndVisuals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Contracts;
    using Models.Vehicles;
    using Infrastructure.Constants;
    using System;

    public class HUD : IHud, IRenderable
    {
        private readonly Vector2 ScorePosition = new Vector2(Graphic.ScoreCoordX, Graphic.ScoreCoordY);
        private readonly Vector2 HealthBarPosition = new Vector2(Graphic.HealthBarCoordX, Graphic.HealthBarCoordY);
        private readonly Vector2 PlayerSpeedPosition = new Vector2(Graphic.PlayerSpeedX, Graphic.PlayerSpeedY);
        private readonly string fontName;
        private int acceleration = 0;
        
        private IPlayer player;
        private ProgressCar progressPlayer;

        internal HUD(IPlayer player, ProgressCar progressPlayer, string fontName)
        {
            this.player = player;
            this.progressPlayer = progressPlayer;
            this.fontName = fontName;
            this.Font = null;
        }

        public Texture2D Texture { get; private set; }
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)HealthBarPosition.X, (int)HealthBarPosition.Y, this.PlayerHealth, this.Texture.Width);
            }
        }

        public int PlayerScore
        {
            get { return this.player.Score; }
        }

        public int PlayerHealth
        {
            get { return this.player.Health; }
        }

        public int PlayerSpeed { get; set; }
        
        public SpriteFont Font { get; set; }

        public Vector2 Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        //Load Content
        public void LoadContent(ContentManager Content, string healthBarFileName)
        {
            this.Font = Content.Load<SpriteFont>(fontName);
            this.Texture = Content.Load<Texture2D>(healthBarFileName);
        }

        //Updatе

        public void Update(GameTime gameTime, int currentSpeed)
        {
            this.PlayerSpeed = currentSpeed;
            acceleration += this.PlayerSpeed;

            if (this.acceleration >= 1000)
            {
                this.progressPlayer.Speed = 1;
                this.acceleration = 0;
            }

            this.progressPlayer.Update(gameTime, this.progressPlayer.Speed);
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.Font, 
                string.Format("Score {0}", this.PlayerScore), 
                this.ScorePosition, Color.White);

            spriteBatch.DrawString(
                this.Font, 
                string.Format("Speed {0}", this.PlayerSpeed),
                this.PlayerSpeedPosition, Color.White);

            spriteBatch.Draw(this.Texture, this.BoundingBox, Color.White);
            spriteBatch.Draw(this.progressPlayer.Texture, this.progressPlayer.Position, Color.White);
        }
    }
}
