using System;
using System.Collections;
using System.Collections.Generic;

// Клас Document
public class Document
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Content: {Content}";
    }
}

// Універсальний клас GenericList<T> з обмеженням типу
public class GenericList<T> where T : Document
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public GenericList()
    {
        head = null;
    }

    // Додавання елемента в початок списку
    public void AddHead(T document)
    {
        Node node = new Node(document);
        node.Next = head;
        head = node;
    }

    // Перебір елементів списку
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Пошук документа за заголовком
    public T FindByTitle(string title)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Title == title)
                return current.Data;

            current = current.Next;
        }
        return null;
    }
}

// Головний клас для демонстрації
class Program
{
    static void Main(string[] args)
    {
        // Створення списку документів
        GenericList<Document> documents = new GenericList<Document>();

        // Додавання документів у список
        documents.AddHead(new Document("Doc1", "Content of document 1"));
        documents.AddHead(new Document("Doc2", "Content of document 2"));
        documents.AddHead(new Document("Doc3", "Content of document 3"));

        // Перебір і виведення документів
        Console.WriteLine("All Documents:");
        foreach (var doc in documents)
        {
            Console.WriteLine(doc);
        }

        // Пошук документа за заголовком
        string searchTitle = "Doc2";
        var foundDoc = documents.FindByTitle(searchTitle);
        Console.WriteLine($"\nFound Document by Title '{searchTitle}':");
        Console.WriteLine(foundDoc != null ? foundDoc.ToString() : "Document not found.");

        Console.ReadKey();
    }
}

