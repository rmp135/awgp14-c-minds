using CSharpMinds.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Components;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using Common;

namespace CSharpMinds
{
    class MenuScene : Scene
    {
        private int _activeItemIndex;
        private List<GameObject> _items;
        private InputSystem _input;

        public MenuScene() : base() {
            _input = SystemManager.GetSystem<InputSystem>();
            _items = new List<GameObject>() {
                GameObjectFactory.Build(new List<Interfaces.IComponent>(){ 
                new MenuItemComponent("Play"),
                new TransformComponent()
                }),
                GameObjectFactory.Build(new List<Interfaces.IComponent>(){ 
                new MenuItemComponent("Menu Item 2"),
                new TransformComponent(new Vector(0, 200))
                })
            };
            foreach (GameObject go in _items)
            {
                AddGameObject(go);
            }
            _items[0].GetComponent<MenuItemComponent>().Active = true;
        }


        public override void Update(Common.GameTime gameTime)
        {
            base.Update(gameTime);
            int _oldIndex = _activeItemIndex;
            if (_input.isKeyPressed(Keys.keyboard.DOWN))
                _activeItemIndex++;
            else if (_input.isKeyPressed(Keys.keyboard.UP))
                _activeItemIndex--;

            if (_activeItemIndex < 0) _activeItemIndex = 0;
            if (_activeItemIndex > _items.Count-1) _activeItemIndex = _items.Count-1;

            if (_oldIndex != _activeItemIndex)
            {
                _items[_oldIndex].GetComponent<MenuItemComponent>().Active = false;
                _items[_activeItemIndex].GetComponent<MenuItemComponent>().Active = true;
            }

            if (_input.isKeyPressed(Keys.keyboard.RETURN)) {
                SceneManager.TransitionToScene("Game");
            }

        }
    }
}
