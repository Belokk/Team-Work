namespace NinjaRacer.SoundsAndVisuals.Sounds
{
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    public sealed class SoundManager
    {
        private static readonly SoundManager soundManager = new SoundManager();

        private SoundManager()
        {
            this.BonusSound = null;
            this.ObstacleSound = null;
            this.BGMusic = null;
        }

        public static SoundManager Instance
        {
            get
            {
                return soundManager;
            }
        }

        public SoundEffect BonusSound { get; set; }

        public SoundEffect ObstacleSound { get; set; }

        public Song BGMusic { get; set; }

        public void LoadContent(ContentManager Content, string bonusFileName, string obstacleFileName, string BGMusicFileName)
        {
            this.BonusSound = Content.Load<SoundEffect>(bonusFileName);
            this.ObstacleSound = Content.Load<SoundEffect>(obstacleFileName);
            this.BGMusic = Content.Load<Song>(BGMusicFileName);
        }
    }
}
