namespace NinjaRacer.SoundsAndVisuals.Sounds
{
    using Microsoft.Xna.Framework.Audio;

    public struct SoundCaller
    {
        private readonly SoundPublisher publisher;
        private readonly SoundSubscriber subscriber;

        public SoundCaller(SoundEffect eff)
        {
            this.publisher = new SoundPublisher(eff);
            this.subscriber = new SoundSubscriber();
            this.subscriber.Subscribe(this.publisher);
            this.publisher.Execute();
        }
    }
}
