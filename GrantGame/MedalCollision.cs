using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using Common;
using CSharpMinds.Managers;

namespace GrantGame
{
    class MedalCollision : Component
    {
        private TransformComponent _trans;
        private ColliderComponent _collider;
        private TextRenderComponent _score;
        private Random rNum;
        private int score;

        public override void Initialise()
        {
            _trans = Owner.GetComponent<TransformComponent>();
            _collider = Owner.Collider;
            _collider.Collide += new ColliderComponent.CollisionHandler(isHit);
            score = 0;
            rNum = new Random();
        }

        public int getScore()
        {
            return score;
        }
        public void setScore(int s)
        {
            score = s;
        }

        public void isHit(ColliderComponent cc)
        {
            if(_score == null)
                _score = SceneManager.CurrentScene.FindGameObjectByName("score").GetComponent<TextRenderComponent>();
            if(cc.Owner.Name == "player")
            {
                score++;
                _score.Text = "Score: " + score;
                _trans.Position = new Vector(rNum.Next(600), rNum.Next(480));
            }  
        }
    }
}
