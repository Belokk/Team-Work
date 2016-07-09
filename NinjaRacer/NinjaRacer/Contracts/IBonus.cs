namespace NinjaRacer.Contracts
{
    interface IBonus : IDestructable, ICollidable, IMovable, IRenderable
    {
        int BonusPoints { get; }
    }
}
