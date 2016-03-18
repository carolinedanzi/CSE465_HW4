// Caroline Danzi
// Dr. Zmuda
// CSE 465
// Implements a Multiset class that is a collection of elements
// which allows duplicates.
// Dr. Zmuda provided the code skeleton and outline.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE465 {
	// Implements a multiset similar to C++ multiset. Your implementation should
	// operate properly for all of the basic types, int, double, string, etc.
	// Efficiency of your code should easily allow 100's of items to be insert,
	// without restrictions on the values of those items.	
	public class Multiset<T> {
		
		private Dictionary<T, int> multiset;
		private int count;
		
		// Constructor for multiset.
		public Multiset()
		{
			multiset = new Dictionary<T, int>();
			count = 0;
		}
		// Adds a single instance of v to the multiset.
		public void Add(T v)
		{
			if(multiset.ContainsKey(v))
			{
				multiset[v] += 1;
			} else 
			{
				multiset.Add(v, 1);
			}
			count++;
		}
		// Removes a single instance of v to the multiset. If the
		// value v is not a member of the multiset, no action is
		// performed.
		public void Remove(T v)
		{
			if(multiset.ContainsKey(v)) {
				if(multiset[v] > 1) {
					multiset[v]--;
					count--;
				} else if(multiset[v] == 1) {
					multiset.Remove(v);
					count--;
				}
			}
			
		}
		// Returns the number of copies of the value v are present
		// in the multiset.
		public int Count(T v)
		{
			if(multiset.ContainsKey(v)) {
				return multiset[v];
			} else {
				return 0;
			}
			
		}
		// Returns the total number of items in the multiset.
		public int Size()
		{
			return count;
		}
	}
	public class Program {
		public static void TestIntMS()
		{
			Multiset<int> intMS = new Multiset<int>();

			intMS.Add(3);
			intMS.Add(3);
			intMS.Add(4);
			intMS.Add(3);
			intMS.Add(4);
			intMS.Add(7);
			Console.WriteLine("*********************");
			Console.WriteLine(intMS.Size());
			for (int i = 0; i < 10; i++) {
				Console.WriteLine("{0} {1}", i, intMS.Count(i));
			}
			intMS.Remove(3);
			intMS.Remove(3);
			intMS.Remove(3);
			intMS.Remove(3);
			intMS.Remove(3);
			Console.WriteLine("*********************");
			Console.WriteLine(intMS.Size());
			for (int i = 0; i < 10; i++) {
				Console.WriteLine("{0} {1}", i, intMS.Count(i));
			}
		}
		public static void TestStringMS()
		{
			Multiset<string> strMS = new Multiset<string>();

			strMS.Add("3");
			strMS.Add("3");
			strMS.Add("4");
			strMS.Add("3");
			strMS.Add("4");
			strMS.Add("7");
			Console.WriteLine("*********************");
			Console.WriteLine(strMS.Size());
			for (int i = 0; i < 10; i++) {
				string str = i.ToString();
				Console.WriteLine("{0} {1}", i, strMS.Count(str));
			}
			strMS.Remove("3");
			strMS.Remove("3");
			strMS.Remove("3");
			strMS.Remove("3");
			strMS.Remove("3");
			strMS.Remove("3");
			Console.WriteLine("*********************");
			Console.WriteLine(strMS.Size());
			for (int i = 0; i < 10; i++) {
				string str = i.ToString();
				Console.WriteLine("{0} {1}", i, strMS.Count(str));
			}
		}
		public static void Main(string[] args)
		{
			TestIntMS();
			TestStringMS();
		}
	}
}
