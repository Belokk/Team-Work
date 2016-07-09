namespace NinjaRacer.SoundsAndVisuals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Contracts;
    using Models.Vehicles;
    using Infrastructure.Constants;

    public class HUD : IHud, IRenderable
    {

        public readonly Vector2 ScorePosition = new Vector2(Graphic.ScoreCoordX, Graphic.ScoreCoordY);
        public readonly Vector2 HealthBarPosition = new Vector2(Graphic.HealthBarCoordX, Graphic.HealthBarCoordY);
        public readonly Vector2 PlayerSpeedPosition = new Vector2(Graphic.PlayerSpeedX, Graphic.PlayerSpeedY);
        public readonly Vector2 PlayerSpeedPosoition = new Vector2(Graphic.PlayerSpeedX, Graphic.PlayerSpeedY);
        private int acceleration = 0;


        private PlayerCar player;
        private ProgressCar progressPlayer;

        public HUD(PlayerCar player, ProgressCar progressPlayer)
        {
            this.player = player;
            this.progressPlayer = progressPlayer;
            this.PlayerScore = player.Score;
            this.ShowHud = true;
            this.PlayerScoreFont = null;
            this.PlayerHealth = player.Health;
        }

        public Texture2D Texture { get; private set; }
        public Rectangle BoundingBox { get; private set; }

        public int PlayerScore
        {
            get { return this.player.Score; }
            set { this.player.Score = value; }
        }

        public int PlayerHealth
        {
            get { return this.player.Health; }
            set { this.player.Health = value; }
        }

        public int PlayerSpeed { get; set; }

        public bool ShowHud { get; set; }

        public SpriteFont PlayerScoreFont { get; set; }

        //Load Content
        public void LoadContent(ContentManager Content, string fileName)
        {
            this.PlayerScoreFont = Content.Load<SpriteFont>("georgia");
            this.Texture = Content.Load<Texture2D>(fileName);
        }

        //Updatе

        public void Update(GameTime gameTime, int currentSpeed)
        {
            this.BoundingBox = new Rectangle((int)HealthBarPosition.X, (int)HealthBarPosition.Y,
    this.PlayerHealth, this.Texture.Width);


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
                this.PlayerScoreFont, 
                string.Format("Score {0}", this.PlayerScore), 
                this.ScorePosition, Color.White);

            spriteBatch.DrawString(
                this.PlayerScoreFont, 
                string.Format("Speed {0}", this.PlayerSpeed),
                this.PlayerSpeedPosoition, Color.White);

            spriteBatch.Draw(this.Texture, this.BoundingBox, Color.White);
            spriteBatch.Draw(this.progressPlayer.Texture, this.progressPlayer.Position, Color.White);
        }


    }
}
