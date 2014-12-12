using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using Common;
using Common.Interfaces;


namespace CSharpMinds.Behaviours
{
    class TrackingBehaviour : Component, IUpdatable
    {
        private GameObject player;
        private TransformComponent _target, AI;
        private PhysicsComponent aiPos;
        public TrackingBehaviour(GameObject p)
        {
            player = p;
            _target = p.GetComponent<TransformComponent>();
           

        }
        public override void Initialise()
        {
            
            AI = Owner.GetComponent<TransformComponent>();
            aiPos = Owner.GetComponent<PhysicsComponent>();
        }

        void IUpdatable.Update(GameTime gameTime)
        {
            //Tracking X Position
            //Tracking left
            if(_target.Position.X < AI.Position.X)
            {
                aiPos.AddForce((new Vector(-0.1f * gameTime.DeltaTime, 0)));
            }
            //Tracking right
            if (_target.Position.X > AI.Position.X)
            {
                aiPos.AddForce((new Vector(0.1f * gameTime.DeltaTime, 0)));
            }
            //Tracking Y Position
            //Tracking Up
            if (_target.Position.Y < AI.Position.Y)
            {
                aiPos.AddForce((new Vector(0, -0.1f * gameTime.DeltaTime)));
            }
            //Tracking Down
            if (_target.Position.Y > AI.Position.Y)
            {
                aiPos.AddForce((new Vector(0, 0.1f * gameTime.DeltaTime)));
            }
        }
    }
}
