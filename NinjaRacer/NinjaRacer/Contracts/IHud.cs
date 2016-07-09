namespace NinjaRacer.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    interface IHud : IRenderable
    {
        int PlayerSpeed { get; set; }

        int PlayerScore { get; }

        int PlayerHealth { get; }
    }
}
