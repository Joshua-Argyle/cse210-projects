public class Book : Product
{
    private string _author;          // e.g., "J.K. Rowling"
    private string _publisher;       // e.g., "Bloomsbury"
    private string _publicationDate; // e.g., "1997-06-26"
    private int _pageCount;          // e.g., 223

    public Book(int id, string name, decimal price, int stockQuantity, string description,
                string author, string publisher, string publicationDate, int pageCount)
        : base(id, name, price, stockQuantity, description)
    {
        _author = author;
        _publisher = publisher;
        _publicationDate = publicationDate;
        _pageCount = pageCount;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +  // Call base method to get common info
               $"Author: {_author}\n" +
               $"Publisher: {_publisher}\n" +
               $"Publication Date: {_publicationDate}\n" +
               $"Page Count: {_pageCount}\n";

    }
}