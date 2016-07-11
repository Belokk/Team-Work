namespace NinjaRacer.SoundsAndVisuals.Sounds
{
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    public sealed class SoundManager
    {
        private static readonly SoundManager SoundManagerInstance = new SoundManager();

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
                return SoundManagerInstance;
            }
        }

        public SoundEffect BonusSound { get; private set; }

        public SoundEffect ObstacleSound { get; private set; }

        public Song BGMusic { get; private set; }

        public void LoadContent(
            ContentManager content, 
            string bonusFileName, 
            string obstacleFileName, 
            string backgroundMusicFileName)
        {
            this.BonusSound = content.Load<SoundEffect>(bonusFileName);
            this.ObstacleSound = content.Load<SoundEffect>(obstacleFileName);
            this.BGMusic = content.Load<Song>(backgroundMusicFileName);
        }
    }
}
