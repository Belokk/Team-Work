namespace NinjaRacer.SoundsAndVisuals.Sounds
{
    using System;

    public class SoundSubscriber
    {
        public void Subscribe(SoundPublisher publisher)
        {
            publisher.Tick += new SoundPublisher.EventHandler(this.TakeAction);
        }

        private void TakeAction(SoundPublisher publisher, EventArgs e)
        {
            publisher.SoundEffect.Play();
        }
    }
}
