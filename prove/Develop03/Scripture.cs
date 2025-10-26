using System.Runtime.CompilerServices;

public class Scripture
{
    public List<string> _scriptures = new List<string>
    {
        "But", "charity", "is", "the", "pure", "love", "of", "Christ,", "and", "it", "endureth", "forever;", "and", "whoso", "is", "found", "possessed", "of", "it", "at", "the", "last", "day,", "it", "shall", "be", "well", "with", "him."
    };

    public string RandomWordPicker(List<string> passage)
    {
        Random random = new Random();
        
        int index = random.Next(passage.Count);
        while (passage[index].Contains("_")) {
            index = random.Next(passage.Count);
        }
        string pickedWord = passage[index];
        return pickedWord;
    }

    public List<string> HideWords(List<string> passage)
    {
        Word scripture_word = new Word();

        string pickedWord = RandomWordPicker(passage);

        for (int i = 0; i < passage.Count; i++)
        {
            scripture_word.SetWord(passage[i]);
            if (pickedWord == scripture_word.GetWord())
                passage[i] = scripture_word.ConvertWordUnderScore(passage[i]);
        }
        return passage;
        
        
    }



}