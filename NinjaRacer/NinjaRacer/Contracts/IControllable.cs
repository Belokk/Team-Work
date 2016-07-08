namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework.Input;

    interface IControllable
    {
        void ControlMovement(KeyboardState keyState);
    }
}
