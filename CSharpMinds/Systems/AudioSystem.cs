﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;

namespace CSharpMinds.Systems {
    public class AudioSystem : ISystem {
        IAudioDriver audiodriver;

        public AudioSystem(IAudioDriver audiodriver) {
            this.audiodriver = audiodriver;
        }
        public void Play(string assetname) {
            audiodriver.Play(assetname);
        }

        public void Initialise() {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime) {
            throw new NotImplementedException();
        }
    }
}
