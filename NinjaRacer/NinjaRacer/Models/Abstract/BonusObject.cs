namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Vehicles;
    using SoundsAndVisuals;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BonusObject : MovingObject, IMovable, ICollidable, IDestructable, IRenderable
    {
        public BonusObject(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
            this.IsVisible = true;
        }

        public bool IsVisible { get; set; }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DetectCollision(PlayerCar playerCar);

        // Update
        public override void Update(GameTime gameTime)
        {
            // update movement
            this.position.Y = this.position.Y + this.Speed;
            if (this.position.Y >= Graphic.WindowHeight)
            {
                this.DestroyObject();
            }
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible)
            {
                spriteBatch.Draw(this.Texture, this.Position, Color.White);
            }
        }
    }
}
