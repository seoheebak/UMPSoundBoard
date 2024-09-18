using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMPSoundBoard.Model
{
    public static class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();
            allSounds.ForEach(sound  => sounds.Add(sound));
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory soundCategory)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(sound => sound.Category == soundCategory).ToList();
            sounds.Clear();
            filteredSounds.ForEach(sound => sounds.Add(sound));
        }
        private static List<Sound> getSounds()
        {
            return new List<Sound> 
            {
                new Sound("Cow", SoundCategory.Animals),
                new Sound("Cat", SoundCategory.Animals),
                new Sound("Gun", SoundCategory.Cartoons),
                new Sound("Spring", SoundCategory.Cartoons),
                new Sound("Clock", SoundCategory.Taunts),
                new Sound("LOL", SoundCategory.Taunts),
                new Sound("Ship", SoundCategory.Warnings),
                new Sound("Siren", SoundCategory.Warnings)
            };

        }
    }
}

