using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMPSoundBoard.Model
{
  
        public enum SoundCategory
        {
            Animals,
            Cartoons,
            Taunts,
            Warnings
        }
        public class Sound {
            public String Name { get; set; }
            public SoundCategory Category { get; set; }
            public string AudioFile { get; set; }
            public String ImageFile { get; set; }

            public Sound(String name, SoundCategory category) {
                Name = name;
                Category = category;
                AudioFile = $"/Assets/Audio/{category}/{Name}.wav";
                ImageFile = $"/Assets/Images/{Category}/{Name}.png";
            }

        }
}
 
