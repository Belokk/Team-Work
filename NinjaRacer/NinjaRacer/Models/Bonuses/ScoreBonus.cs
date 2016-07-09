namespace NinjaRacer.Models.Bonuses
{
    using Contracts;
    using Abstract;
    using Vehicles;
    using SoundsAndVisuals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class ScoreBonus : Bonus, IMovable, ICollidable, IDestructable
    {
        public ScoreBonus(Texture2D texture, int speed) : 
            base(texture, speed)
        {
        }
    }
}
