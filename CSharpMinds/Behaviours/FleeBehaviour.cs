using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpMinds.Components;
using Common;
using Common.Interfaces;
using System.Threading.Tasks;
using CSharpMinds;

namespace GrantGame.Behaviours
{
    class FleeBehaviour : Component, IUpdatable
    {
        private GameObject gameObj;
        private TransformComponent _target, AI;
        private PhysicsComponent aiPos;

        /// <summary>
        /// Behaviour to make any GameObject Flee from another GameObject
        /// </summary>
        /// <param name="p"></param>
        public FleeBehaviour(GameObject go)
        {
            gameObj = go;
            _target = go.GetComponent<TransformComponent>();
        }

        public override void Initialise()
        {
            AI = Owner.GetComponent<TransformComponent>();
            aiPos = Owner.GetComponent<PhysicsComponent>();
        }

        void IUpdatable.Update(GameTime gameTime)
        {
            float dTime = gameTime.DeltaTime;
            Vector rangeBox = new Vector(250, 250);

            if (AI.Position.X - rangeBox.X > _target.Position.X) { }//|| _target.Position.Y > AI.Position.Y + rangeBox.Y 
            else if (AI.Position.Y - rangeBox.Y > _target.Position.Y)
            { }
            else
            {
                //Fleeing X Position
                //Flee right
                if (_target.Position.X < AI.Position.X)
                {
                    aiPos.AddForce((new Vector(0.1f * dTime, 0)));
                }

                //Tracking Y Position
                //Flee Down
                if (_target.Position.Y < AI.Position.Y)
                {
                    aiPos.AddForce((new Vector(0, 0.1f * dTime)));
                }
            }

            if (AI.Position.X - rangeBox.X < _target.Position.X) { }//|| _target.Position.Y > AI.Position.Y + rangeBox.Y 
            else if (AI.Position.Y - rangeBox.Y < _target.Position.Y)
            { }
            else
            {
                //Flee left
                if (_target.Position.X > AI.Position.X)
                {
                    aiPos.AddForce((new Vector(-0.1f * dTime, 0)));
                }
                //Flee Up
                if (_target.Position.Y > AI.Position.Y)
                {
                    aiPos.AddForce((new Vector(0, -0.1f * dTime)));
                }
            }
        }
    }
}
    
