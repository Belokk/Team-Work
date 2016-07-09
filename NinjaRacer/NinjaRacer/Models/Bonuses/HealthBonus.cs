using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaRacer.Models.Bonuses
{
    using Contracts;
    using Abstract;
    using Vehicles;
    using SoundsAndVisuals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class HealthBonus : Bonus, IMovable, IDestructable
    {
        public HealthBonus(Texture2D texture, int speed) :
            base(texture, speed)
        {
        }
    }
}
