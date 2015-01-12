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
    public class PatrollingBehaviour : Component, IUpdatable
    {
        private bool atTarget = false;
        private float start;
        private float target;
        private PhysicsComponent aiPos;
        private TransformComponent AI;

        /// <summary>
        /// Behaviour to make any GameObject Patrol between any 2 given points in 3D space
        /// </summary>
        /// <param name="p"></param>
        public PatrollingBehaviour(float s,float t)
        {
            start = s;
            target = t;
        }

        public override void Initialise()
        {
            AI = Owner.GetComponent<TransformComponent>();
            aiPos = Owner.GetComponent<PhysicsComponent>();
        }

        void IUpdatable.Update(GameTime gameTime)
        {
            float dTime = gameTime.DeltaTime;
            if (AI.Position.X < target && atTarget == false)
            {
                aiPos.AddForce((new Vector( 5.0f,0.0f)));
            }
            if (AI.Position.X >= target - 0.1f && AI.Position.X <= target + 0.1f)
            {
                atTarget = true;
            }

            if (AI.Position.X > start && atTarget == true)
            {
                aiPos.AddForce((new Vector(-5.0f, 0.0f)));
            }
            if (AI.Position.X >= start - 0.1f && AI.Position.X <= start + 0.1f)
            {
                atTarget = false;
            }
        }
    }
}
