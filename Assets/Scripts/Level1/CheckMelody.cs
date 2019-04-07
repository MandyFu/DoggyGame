using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckMelody : MonoBehaviour
{
    public List<string> Melody = new List<string>();
    public List<string> InputNotes = new List<string>();
   

    public bool IsCorrectMelody()
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
