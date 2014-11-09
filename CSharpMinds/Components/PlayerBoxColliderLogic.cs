using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;

namespace CSharpMinds.Components
{
    class PlayerBoxColliderLogic : BoxColliderComponent
    {
        private int p1;
        private int p2;

        public override void Initialise() {
            base.Initialise();
        }
        public PlayerBoxColliderLogic(int p1, int p2) : base(p1,p2) {
        }
        public override void OnCollision(IColliderComponent other) {
            if(other.Owner.Name == "bat")
                other.Owner.GetComponent<SpriteRenderComponent>().SpriteName = "Resources\\bat_dead.png";
            Console.WriteLine("Player collided with " + other.Owner.Name + "!");
        }
    }
}
