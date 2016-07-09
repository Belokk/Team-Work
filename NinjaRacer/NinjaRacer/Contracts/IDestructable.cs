namespace NinjaRacer.Contracts
{
    interface IDestructable : ICollidable, IMovable, IRenderable
    {
        bool IsVisible { get; }

        void DestroyObject();
    }
}
