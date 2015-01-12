using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using Common;
using CSharpMinds.Managers;
using CSharpMinds.Factories;
using CSharpMinds.Components;
using CSharpMinds;
using CSharpMinds.Interfaces;

namespace GrantGame
{
    class CollideWithPlayer : Component
    {
        ColliderComponent _collider;
        TransformComponent _trans;

        public override void Initialise()
        {
            _collider = Owner.Collider;
            _collider.Collide += new ColliderComponent.CollisionHandler(isHit);
            _trans = Owner.GetComponent<TransformComponent>();
        }

        public void isHit(ColliderComponent cc)
        {
            if(cc.Owner.Name == "player")
            {
                SceneManager.RemoveGameObjectFromScene(cc.Owner);
                GameObject _GameOver = GameObjectFactory.Build("score", new List<IComponent>()
                    {
                        new TransformComponent(){Position = new Vector(300,250)},
                        new TextRenderComponent("Game Over!"),
                
                    });
                SceneManager.AddGameObjectToScene(_GameOver);

            }
        }
    }
}
