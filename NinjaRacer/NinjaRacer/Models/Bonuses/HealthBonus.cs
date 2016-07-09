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

    public class HealthBonus : Bonus, IMovable, ICollidable, IDestructable
    {
        private const int healthBonus = 20;

        public HealthBonus(Texture2D texture, int speed) :
            base(texture, speed)
        {
        }

        public override void DetectCollision(PlayerCar player)
        {
            if (player.BoundingBox.Intersects(this.BoundingBox) && player.Health < 160)
            {
                player.Health += healthBonus;
                if (player.Health > 160)
                {
                    player.Health = 160;
                }
                this.DestroyObject();
            }
        }
    }
}
