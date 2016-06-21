using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Background
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }

    public class Scrolling : Background
    {
        int windowHeight;
        public int speed = 10; //scroll speed
        private int lastDevisable;
        //TODO: Speed updater
        public Scrolling(Texture2D newTexture, Rectangle newRectangle, int windowHeight)
        {
            texture = newTexture;          
            rectangle = newRectangle;
            this.windowHeight = windowHeight;
            lastDevisable = GetLastDevisable(windowHeight, speed);
        }
        
        public void Update()
        {
            if (rectangle.Y >= lastDevisable)
            {
                //NEEDS MORE WORK
                //revert to starting position if at the bottom of the window
                //formula: -windowHeight + (rectangle.Y - windowHeight) = -2*windowHeight + rectangle.Y

                rectangle.Y += -2*windowHeight; //= -2*windowHeight + rectangle.Y         
            }

            //scroll
                rectangle.Y += speed; 
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

    }
}
