namespace NinjaRacer.Contracts
{
    interface IObstacle :  IDestructable, ICollidable, IMovable, IRenderable
    {
        int DamagePoints { get; }
    }
}
