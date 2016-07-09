namespace NinjaRacer.Contracts
{
    public interface IDestructable : ICollidable, IMovable, IRenderable
    {
        bool IsVisible { get; }

        void DestroyObject();
    }
}
