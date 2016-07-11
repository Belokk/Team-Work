using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaRacer
{
   internal class CrashException:ApplicationException
    {
        private int health;

        public CrashException(int health)
            : base(string.Format("The player died! (health = {0})", health), null)
        {
            this.Health = health;
        }

        public int Health
        {
            get { return this.health; }
            private set { this.health = value; }
        }
    }
}
