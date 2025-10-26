using System.Diagnostics;

public class Word
{
    private string _word;


    public void SetWord(string word)
    {
        if (word is string)
        {
            _word = word;
        }

    }
    public string GetWord()
    {
        return _word;
    }
    public string ConvertWordUnderScore(string word)
    {
        string _hiddenWord = "_";
        foreach (char letter in word)
        {
            _hiddenWord += "_";
        }
        return _hiddenWord;
    }
}