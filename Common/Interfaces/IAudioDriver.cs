using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces {
    public interface IAudioDriver {
        bool SoundEnabled { get; set; }
        void SoundVolume(int vol);
        void Play(string assetname);
    }
}
