using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
	public Book(string title, int year, params string[] authors)
	{
		this.Title = title;
		this.Year = year;
		this.Authors = authors;
	}

	public string Title { get; }

	public int Year { get; }

	public IReadOnlyCollection<string> Authors { get; }

	public int CompareTo(Book book)
	{
		int result = this.Year.CompareTo(book.Year);

		if (result == 0)
		{
			result = this.Title.CompareTo(book.Title);
		}

		return result;
	}

	public override string ToString()
	{
		return $"{this.Title} - {this.Year}";
	}
}