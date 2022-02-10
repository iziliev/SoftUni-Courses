package P24_Book_Library;

public class Book {
    private String title;
    private String author;
    private String publisher;
    private String releaseDate;
    private String isbn;
    private double price;

    public Book(String title, String author, String publisher, String releaseDate, String isbn, double price) {
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.releaseDate = releaseDate;
        this.isbn = isbn;
        this.price = price; }

        public String getTitle() {

        return title;
    }

    public String getAuthor() {
        return author;
    }

    public String getPublisher() {
        return publisher;
    }

    public String getReleaseDate() {
        return releaseDate;
    }

    public String getIsbn() {
        return isbn;
    }

    public double getPrice() {
        return price;
    }
}
