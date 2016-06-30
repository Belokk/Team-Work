namespace NinjaRacer.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Contracts;

    public class RoadMap : MovingObject, IMovable, IRenderable
    {
        private readonly int TrackHeight;
        private readonly int lastDevisable;

        public RoadMap(Texture2D texture, Rectangle rectangle, int speed, int trackHeight)
            : base(texture, rectangle, speed)
        {
            this.TrackHeight = trackHeight; // TODO this can be get from window size => to set in consructor?
            this.lastDevisable = GetLastDevisable(this.TrackHeight, this.Speed);
        }

        public int GetLastDevisable(int max, int devisor)
        {
            for (int i = max; i >= 0; i--)
            {
                if (i % devisor == 0)
                {
                    return i;
                }
            }
            return max;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public override void Update()
        {
            if (Rectangle.Y >= lastDevisable)
            {
                //NEEDS MORE WORK
                //revert to starting position if at the bottom of the window  
                //formula: -windowHeight + (rectangle.Y - windowHeight) = -2*windowHeight + rectangle.Y

                this.rectangle.Y += -2 * TrackHeight; //= -2*windowHeight + rectangle.Y         
            }

            //scroll
            this.rectangle.Y += this.Speed;
        }
    }
}
