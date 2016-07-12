namespace NinjaRacer.SoundsAndVisuals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using MonoGame.Extended.BitmapFonts;
    using Contracts;
    using Models.Vehicles;
    using Infrastructure.Constants;
    using System;

    public class HUD : IHud, IRenderable
    {
        private readonly Vector2 scorePosition = new Vector2(Graphic.ScoreCoordX, Graphic.ScoreCoordY);
        private readonly Vector2 healthBarPosition = new Vector2(Graphic.HealthBarCoordX, Graphic.HealthBarCoordY);
        private readonly Vector2 playerSpeedPosition = new Vector2(Graphic.PlayerSpeedX, Graphic.PlayerSpeedY);
        private readonly string fontName;
        private readonly string healthBarBorderBoxName;
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

        internal HUD(IPlayer player, ProgressCar progressPlayer, string fontName, string healthBarBorderBoxFileName)
            : this(player, progressPlayer, fontName)
        {
            this.healthBarBorderBoxName = healthBarBorderBoxFileName;
        }

        public Texture2D Texture { get; private set; }

        public Texture2D HealthBarBorderBox { get; private set; }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)healthBarPosition.X, (int)healthBarPosition.Y, this.PlayerHealth, this.Texture.Width);
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

        public BitmapFont Font { get; set; }

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

        public void LoadContent(ContentManager content, string healthBarFileName)
        {
            this.Font = content.Load<BitmapFont>(this.fontName);
            this.Texture = content.Load<Texture2D>(healthBarFileName);
            if (this.healthBarBorderBoxName != null)
            {
                this.HealthBarBorderBox = content.Load<Texture2D>(this.healthBarBorderBoxName);
            }
        }

        public void Update(GameTime gameTime, int currentSpeed)
        {
            this.PlayerSpeed = currentSpeed;
            this.acceleration += this.PlayerSpeed;

            if (this.acceleration >= 1000)
            {
                this.progressPlayer.Speed = 1;
                this.acceleration = 0;
            }

            this.progressPlayer.Update(gameTime, this.progressPlayer.Speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.Font,
                string.Format("Score {0}", this.PlayerScore),
                this.scorePosition, Color.White);

            spriteBatch.DrawString(
                this.Font,
                string.Format("Speed {0}", this.PlayerSpeed),
                this.playerSpeedPosition, Color.White);

            if (this.HealthBarBorderBox != null)
            {
                spriteBatch.Draw(
                    this.HealthBarBorderBox,
                    new Vector2(Graphic.HealthBarBorderCoordX, Graphic.HealthBarBorderCoordY));
            }

            spriteBatch.Draw(this.Texture, this.BoundingBox, Color.White);
            spriteBatch.Draw(this.progressPlayer.Texture, this.progressPlayer.Position, Color.White);
        }
    }
}
