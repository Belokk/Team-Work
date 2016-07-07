namespace NinjaRacer.Contracts
{
    using Models.Vehicles;
    interface ICollidable
    {      
        void DetectCollision(PlayerCar playerCar);
    }
}
