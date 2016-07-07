namespace NinjaRacer.Contracts
{
    interface IDestructable
    {
        bool IsVisible { get; }

        void DestroyObject();
    }
}
