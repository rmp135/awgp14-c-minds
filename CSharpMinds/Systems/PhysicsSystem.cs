using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Interfaces;
using CSharpMinds.Components;
using Common;


namespace CSharpMinds.Systems
{
    public class PhysicsSystem : ISystem
    {
        List<ColliderComponent> _colliders;

        public PhysicsSystem() {
            _colliders = new List<ColliderComponent>();
        }

        public void AddCollider(ColliderComponent collider) {
           _colliders.Add(collider);
        }
        public void RemoveCollider(ColliderComponent toremove) {
            _colliders.Remove(toremove);
        }

        public void Update(GameTime gameTime) {
            for (int i = 0; i < _colliders.Count-1; i++) {
                for (int j = i+1; j < _colliders.Count; j++) {
                    if (hasCollided(_colliders[i], _colliders[j])) {
                        _colliders[i].OnCollide(_colliders[j]);
                        _colliders[j].OnCollide(_colliders[i]);
                    }
                }
            }
        }

        private bool hasCollided(ColliderComponent col1, ColliderComponent col2) {
            Type col1Type = col1.GetType();
            Type col2Type = col2.GetType();
            // Box with Box
            if (col1Type == typeof(BoxColliderComponent) && col2Type == typeof(BoxColliderComponent)) {
                return collideBoxWithBox((BoxColliderComponent)col1, (BoxColliderComponent)col2);
            }
            // Box with Point.
            else if (col1Type == typeof(PointCollider) && col2Type == typeof(BoxColliderComponent)) {
                return collidePointWithBox((PointCollider)col1, (BoxColliderComponent)col2);
            }
            // Point with Box.
            else if (col1Type == typeof(BoxColliderComponent) && col2Type == typeof(PointCollider)) {
                return collidePointWithBox((PointCollider)col2, (BoxColliderComponent)col1);
            }
            // Not implemented collision.
            else {
                return false;
            }
        }

        private bool collidePointWithBox(PointCollider point, BoxColliderComponent box) {
                if (point.Max.X <= box.Min.X) {
                    return false;
                }
                if (point.Max.Y <= box.Min.Y) {
                    return false;
                }
                if (point.Min.X >= box.Max.X) {
                    return false;
                }
                if (point.Min.Y >= box.Max.Y) {
                    return false;
                }
            return true;
        }

        private bool collideBoxWithBox(BoxColliderComponent box1, BoxColliderComponent box2) { 
                if (box1.Max.X <= box2.Min.X) {
                    return false;
                }
                if (box1.Max.Y <= box2.Min.Y) {
                    return false;
                }
                if (box1.Min.X >= box2.Max.X) {
                    return false;
                }
                if (box1.Min.Y >= box2.Max.Y) {
                    return false;
                }
            return true;
        }

        public void Initialise() {
           
        }
    }
}
