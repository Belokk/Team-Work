namespace NinjaRacer.Models.Abstract
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    public abstract class Hole : Obstacle, IObstacle, ICollidable, IRenderable
    {
    }
}
