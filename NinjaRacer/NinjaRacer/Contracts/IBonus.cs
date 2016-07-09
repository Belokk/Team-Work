namespace NinjaRacer.Contracts
{
    public interface IBonus : IDestructable, ICollidable, IMovable, IRenderable
    {
        int BonusPoints { get; }
    }
}
