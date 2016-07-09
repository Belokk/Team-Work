namespace NinjaRacer.Contracts
{
    using Models.Vehicles;
    public interface ICollidable : IMovable, IRenderable
    {
        void DetectCollision(IPlayer playerCar);
    }
}
