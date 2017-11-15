﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimatedSprite;

namespace AnimatedSprite
{
    class RotatingSprite : Sprite
    {
        public RotatingSprite(Game g, Texture2D tx, Vector2 StartPosition, int NoOfFrames)
            : base(g, tx, StartPosition, NoOfFrames)
        {

        }

        protected static float TurnToFace(Vector2 position, Vector2 faceThis,
            float currentAngle, float turnSpeed)
        {
            // The difference in the two points is 
            float x = faceThis.X - position.X;
            float y = faceThis.Y - position.Y;
            // ArcTan calculates the angle of rotation 
            // relative to a point (the gun turret position)
            // in the positive x plane and 
            float desiredAngle = (float)Math.Atan2(y, x);

            float difference = WrapAngle(desiredAngle - currentAngle);

            difference = MathHelper.Clamp(difference, -turnSpeed, turnSpeed);

            return WrapAngle(currentAngle + difference);
        }


        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        /// <summary>
        /// Returns the angle expressed in radians between -Pi and Pi.
        /// Angle is always positive
        /// </summary>
        private static float WrapAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }
            return radians;
        }
    }
}
