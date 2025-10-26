using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;

public class Reference
{
    private string _book = "Moroni";
    private int _chapter = 7;
    private int _verseStart = 47;

    private int _verseEnd;

    public string DisplayReferenceOneVerse()
    {
        return $"{_book} {_chapter} : {_verseStart}";
    }
    
    public string DisplayReferenceMultiplyVerses()
    {
        return $"{_book} {_chapter} : {_verseStart} - {_verseEnd}";
    }
}