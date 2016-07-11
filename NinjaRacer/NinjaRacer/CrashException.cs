namespace NinjaRacer
{
    using System;

    public class CrashException:ApplicationException
    {
        private const string ExeptionMessage = "The car crashed! (health = {0})";
        private int health;

        public CrashException(int health)
            : base(string.Format(ExeptionMessage, health), null)
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
