using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{

    public static class MelodyCache
    {
        public static List<string> Melody;
        public static List<string> InputNotes;

        public static void Init()
        {
            if (Melody == null)
            {
                Melody.Add("Fa_Sound");
                Melody.Add("Fa_Sound");
                Melody.Add("Mi_Sound");
                Melody.Add("Mi_Sound");
                Melody.Add("Re_Sound");
                Melody.Add("Re_Sound");
                Melody.Add("Do_Sound");
            }

            if (InputNotes == null)
            {
                InputNotes = new List<string>();
            }
        }

        public static bool IsCorrectMelody()
        {
            if (InputNotes.Count < 7)
                return false;

            List<string> _lastInputNotes = InputNotes.Skip(InputNotes.Count - 7).ToList();

            for (int index = 6; index >= 0; index--)
            {
                if (Melody[index] != _lastInputNotes[index])
                    return false;
            }
            return true;
        }
    }

}