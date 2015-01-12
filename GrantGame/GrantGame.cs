﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMinds;
using CSharpMinds.Systems;
using CSharpMinds.Managers;
using SFMLLibrary.Drivers;

namespace GrantGame
{
    class GrantGame : Game
    {
        static void Main(string[] args)
        {
            GrantGame game = new GrantGame();
        }

        public override void LoadScenes()
        {
            SceneManager.AddScene(new GrantGameScene(), "game");
            SceneManager.TransitionToScene("game");
        }
        public override void LoadSystems()
        {
            SystemManager.AddSystems(new List<ISystem>(){
                new RenderSystem(new SFMLRenderDriver()),
                new InputSystem(new SFMLKeyboardDriver()),
                new PhysicsSystem()
            });
        }
    }
}
