using Common;
using CSharpMinds.Managers;
using CSharpMinds.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds.Factories;
using CSharpMinds.Components;

namespace CSharpMinds
{
    public class GameScene : Scene
    {
        InputSystem _input;
        GameObject _pauseScreen;
        public GameScene() : base() {
            _input = SystemManager.GetSystem<InputSystem>();
            AddGameObject(_pauseScreen = GameObjectFactory.Build("pause indicator",new List<Interfaces.IComponent>(){new TextRenderComponent("PAUSED"), new TransformComponent()}));
            _pauseScreen.GetComponent<TextRenderComponent>().Enabled = false;
        }

        public override void Update(Common.GameTime gameTime)
        {
            if (_input.isKeyPressed(Keys.keyboard.ESC)) {
                _pauseScreen.GetComponent<TextRenderComponent>().Enabled = !_pauseScreen.GetComponent<TextRenderComponent>().Enabled;
            }
            base.Update(gameTime);
        }
    }
}
