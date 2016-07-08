namespace NinjaRacer
{
    using System;

    public class CarCrashException : ApplicationException
    {
        private const string ExceptionMessage = "Car Crashed! (health = {0})";
        private int health;

        public CarCrashException(int health)
                : base(string.Format(ExceptionMessage, health), null)
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

