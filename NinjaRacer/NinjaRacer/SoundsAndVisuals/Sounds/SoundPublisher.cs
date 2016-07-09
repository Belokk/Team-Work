namespace NinjaRacer.SoundsAndVisuals.Sounds
{
    using System;
    using Microsoft.Xna.Framework.Audio;

    public class SoundPublisher
    {
        public SoundPublisher(SoundEffect soundEffect)
        {
            this.SoundEffect = soundEffect;
        }

        public delegate void EventHandler(SoundPublisher publisher, EventArgs e);

        public event EventHandler Tick = null;

        public SoundEffect SoundEffect { get; set; }

        public void Execute()
        {
            if (this.Tick != null)
            {
                this.Tick(this, EventArgs.Empty);
            }
        }
    }
}
