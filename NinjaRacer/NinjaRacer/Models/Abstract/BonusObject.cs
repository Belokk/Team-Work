namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Vehicles;
    using Infrastructure.Constants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BonusObject : MovingObject, IMovable, ICollidable, IDestructable, IRenderable
    {
        public BonusObject(Texture2D texture, Vector2 position, int speed) : base(texture, position, speed)
        {
            this.IsVisible = true;
        }

        public Rectangle BoundingBox { get; set; }

        public bool IsVisible { get; set; }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DistributeBonusEffect(PlayerCar p);

        // Update
        public override void Update(GameTime gameTime)
        {
            // Set bounding box for collision
            this.BoundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.Texture.Width, this.Texture.Height);

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

        public void CollisionDetection()
        {
            throw new NotImplementedException();
        }
    }
}
