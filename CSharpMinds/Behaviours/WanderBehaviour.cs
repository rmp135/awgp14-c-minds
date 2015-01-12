using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpMinds.Components;
using Common;
using Common.Interfaces;
using System.Threading.Tasks;

namespace CSharpMinds.Behaviours
{
    class WanderBehaviour : Component, IUpdatable
    {
        private float wanderRadius, wanderDist, wanderJitter, randX, randY;
        private Random rNum;
        private PhysicsComponent aiPos;
        private TransformComponent AI;

        /// <summary>
        /// Behaviour to make any GameObject wander around an open area
        /// </summary>
        /// <param name="p"></param>
        public WanderBehaviour()
        {
            wanderRadius = 1.2f;
            wanderDist = 2.0f;
            wanderJitter = 0.0f;
        }

        public override void Initialise()
        {
            AI = Owner.GetComponent<TransformComponent>();
            aiPos = Owner.GetComponent<PhysicsComponent>();
        }

//Vector2D SteeringBehavior::Wander()
//{ 
//  //this behavior is dependent on the update rate, so this line must
//  //be included when using time independent framerate.
//  double JitterThisTimeSlice = 80 * TimeElapsed;

//  //first, add a small random vector to the target's position
//  m_vWanderTarget += Vector2D(RandomClamped() * JitterThisTimeSlice,
//                              RandomClamped() * JitterThisTimeSlice);

//  //reproject this new vector back on to a unit circle
//  m_vWanderTarget.Normalize();

//  //increase the length of the vector to the same as the radius
//  //of the wander circle
//  m_vWanderTarget *= 1.2;

//  //move the target into a position WanderDist in front of the agent
//  Vector2D target = m_vWanderTarget + Vector2D(2.0, 0);

//  //and steer towards it
//  return target - m_pVehicle->Pos(); 
//}

        void IUpdatable.Update(GameTime gameTime)
        {
            rNum = new Random();

            wanderJitter = 0.08f; //* gameTime.DeltaTime;

            double valX, valY;

            double theta = rNum.Next(0, 360) * (2 * Math.PI);
            Vector wandertarget = new Vector(wanderRadius * (float)Math.Cos(theta),wanderRadius * (float)Math.Sin(theta));

            valX = rNum.NextDouble();
            valX -= 0.5;
            valX *= 2;

            randX = (float)valX;

            valY = rNum.NextDouble();
            valY -= 0.5;
            valY *= 2;

            randY = (float)valY;

            wandertarget+= new Vector(randX * wanderJitter,randY * wanderJitter);

            wandertarget *=wanderRadius;

            Vector target = wandertarget + new Vector(randX, randY);

            Vector force = new Vector(target.X,target.Y);

            Math.Truncate(force.X);
            Math.Truncate(force.Y);

            aiPos.AddForce(force);
        }
    }
}
