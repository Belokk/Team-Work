namespace NinjaRacer.Contracts
{
    using Models.Vehicles;

    interface IBonus : ICollidable
    {
        int BonusPoints { get; }
           
        bool IsVisible { get; set; }

        void DestroyObject();
    }
}
