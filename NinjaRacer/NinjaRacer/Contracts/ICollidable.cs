namespace NinjaRacer.Contracts
{
    public interface ICollidable : IMovable, IRenderable
    {
        void DetectCollision(IPlayer playerCar);
    }
}
