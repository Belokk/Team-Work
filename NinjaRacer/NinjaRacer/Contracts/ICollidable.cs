namespace NinjaRacer.Contracts
{
    using Models.Vehicles;
    interface ICollidable : IMovable, IRenderable
    {
        void DetectCollision(PlayerCar playerCar);
    }
}
