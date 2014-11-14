using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace CSharpMinds.Systems {
    public class TestAudioDriver : IAudioDriver {

        public void SoundVolume(int vol) {
            throw new NotImplementedException();
        }

        public void Play(string assetname) {
            throw new NotImplementedException();
        }

        public bool SoundEnabled {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }
    }
}
