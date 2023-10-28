using lab1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Array
{
    static public class Array
    {
        public static User[] users = {
                new User(0, "John", "Smith", "john.smith@example.com"),
                new User(1, "Emily", "Johnson", "emily.johnson@example.com"),
                new User(2, "Michael", "Davis", "michael.davis@example.com"),
                new User(3, "Sarah", "Wilson", "sarah.wilson@example.com"),
                new User(4, "Michael", "Brown", "michael.brown@example.com"),
                new User(5, "Olivia", "Miller", "olivia.miller@example.com"),
                new User(6, "James", "Wilson", "james.wilson@example.com"),
                new User(7, "Emma", "Moore", "emma.moore@example.com"),
                new User(8, "Liam", "Taylor", "liam.taylor@example.com")
        };

        public static Book[] books = {
                new Book(0, "George Orwell", "1984", new DateTime(1949, 6, 8), 5),
                new Book(1, "Jane Austen", "Pride and Prejudice", new DateTime(1813, 1, 28), 8),
                new Book(2, "F. Scott Fitzgerald", "The Great Gatsby", new DateTime(1925, 4, 10), 7),
                new Book(3, "J.K. Rowling", "Harry Potter and the Philosopher's Stone", new DateTime(1997, 6, 26), 6),
                new Book(4, "Hermann Hesse", "Siddhartha", new DateTime(1922, 9, 16), 4),
                new Book(5, "Leo Tolstoy", "War and Peace", new DateTime(1869, 1, 1), 9),
                new Book(6, "Fyodor Dostoevsky", "Crime and Punishment", new DateTime(1866, 11, 14), 3),
                new Book(7, "Gabriel Garcia Marquez", "One Hundred Years of Solitude", new DateTime(1967, 5, 30), 2),
                new Book(8, "Mark Twain", "The Adventures of Tom Sawyer", new DateTime(1876, 12, 1), 1)
        };
        public static User selectetUSer;
        public static Book selectetBOok;


        public static UserBook[] userBook = {
            //new UserBook(users[0],books[2],3),
        };
    }
}
