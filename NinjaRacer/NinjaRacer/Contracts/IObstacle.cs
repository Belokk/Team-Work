namespace NinjaRacer.Contracts
{
    public interface IObstacle : IDestructable, ICollidable, IMovable, IRenderable
    {
        int DamagePoints { get; }
    }
}
