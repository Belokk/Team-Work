namespace NinjaRacer.Contracts
{
    public interface IHud : IRenderable
    {
        int PlayerSpeed { get; set; }

        int PlayerScore { get; }

        int PlayerHealth { get; }
    }
}
