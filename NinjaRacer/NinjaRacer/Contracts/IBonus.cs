namespace NinjaRacer.Contracts
{
    using Models.Vehicles;

    interface IBonus
    {
        int BonusPoints { get; }
           
        bool IsVisible { get; set; }

        void DetectCollision(PlayerCar player);

        void DestroyObject();
    }
}
