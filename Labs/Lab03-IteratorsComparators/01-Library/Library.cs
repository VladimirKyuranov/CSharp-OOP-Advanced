﻿using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
	private SortedSet<Book> books;

	public Library(params Book[] books)
	{
		this.books = new SortedSet<Book>(books, new BookComparator());
	}

	public IEnumerator<Book> GetEnumerator()
	{
		return new LibraryIterator(this.books);
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	private class LibraryIterator : IEnumerator<Book>
	{
		private readonly List<Book> books;
		private int currentIndex = - 1;

		public LibraryIterator(IEnumerable<Book> books)
		{
			this.books = new List<Book>(books);
		}

		public Book Current => this.books[this.currentIndex];

		object IEnumerator.Current => this.Current;

		public void Dispose() {}

		public bool MoveNext()
		{
			this.currentIndex++;
			return this.currentIndex < this.books.Count;
		}

		public void Reset()	{}
	}
}