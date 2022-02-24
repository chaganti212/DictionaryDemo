using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDictionaryConsoleApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<string>> demoDict = new Dictionary<string, List<string>>();

			while (true)
			{
				Console.Write(">");
				string input = Console.ReadLine();

				// Check for empty
				if (!String.IsNullOrEmpty(input))
				{
					DictionaryMain(demoDict, input);
				}
				else
				{
					Console.WriteLine("Error: Invalid Input" + string.Empty);
				}
			}
		}
		public static Dictionary<string, List<string>> DictionaryMain(Dictionary<string, List<string>> demoDict, string input)
		{
			// Get words from input string
			string[] cmdWord = input.Split(' ');

			if (cmdWord.Length < 4)
			{
				if (!String.IsNullOrEmpty(cmdWord[0]))
				{
					if (cmdWord[0] == "ADD")
					{
						if (cmdWord.Length == 3)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]) || !String.IsNullOrEmpty(cmdWord[2]))
							{
								AddDictdata(demoDict, cmdWord[1], cmdWord[2]);
							}
							else
							{
								Console.WriteLine("Error: Invalid Key, Members" + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key and Members" + string.Empty);
						}

					}
					else if (cmdWord[0] == "REMOVE")
					{
						if (cmdWord.Length == 3)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]) || !String.IsNullOrEmpty(cmdWord[2]))
							{
								RemoveDictdata(demoDict, cmdWord[1], cmdWord[2]);
							}
							else
							{
								Console.WriteLine("Error:key,member must not be empty or null " + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key and Members" + string.Empty);
						}

					}
					else if (cmdWord[0] == "KEYS")
					{
						getKeys(demoDict);
					}
					else if (cmdWord[0] == "MEMBERS")
					{
						if (cmdWord.Length == 2)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]))
							{
								getMembers(demoDict, cmdWord[1]);
							}
							else
							{
								Console.WriteLine($"Error: key - {cmdWord[1]} must not be empty or null" + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key" + string.Empty);
						}

					}
					else if (cmdWord[0] == "ALLMEMBERS")
					{
						getAllMembers(demoDict);
					}
					else if (cmdWord[0] == "ITEMS")
					{
						getAllItems(demoDict);
					}
					else if (cmdWord[0] == "KEYEXISTS")
					{
						if (cmdWord.Length == 2)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]))
							{
								Console.WriteLine(demoDict.ContainsKey(cmdWord[1]));
							}
							else
							{
								Console.WriteLine($"Error: key - {cmdWord[1]} must not be empty or null" + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key" + string.Empty);
						}
					}
					else if (cmdWord[0] == "MEMBEREXISTS")
					{
						if (cmdWord.Length == 3)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]) || !String.IsNullOrEmpty(cmdWord[2]))
							{
								checkMemberExists(demoDict, cmdWord[1], cmdWord[2]);
							}
							else
							{
								Console.WriteLine("Error:key,member must not be empty or null " + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key and Members" + string.Empty);
						}

					}
					else if (cmdWord[0] == "REMOVEALL")
					{
						if (cmdWord.Length == 2)
						{
							if (!String.IsNullOrEmpty(cmdWord[1]))
							{
								RemoveAllDictdata(demoDict, cmdWord[1]);
							}
							else
							{
								Console.WriteLine($"Error: key - {cmdWord[1]} must not be empty or null" + string.Empty);
							}
						}
						else
						{
							Console.WriteLine("Error: please enter Key" + string.Empty);
						}

					}
					else if (cmdWord[0] == "CLEAR")
					{
						demoDict.Clear();
						Console.WriteLine(") Cleared");
					}
					else
					{
						Console.WriteLine($"Command {cmdWord[0]} is Invalid");
					}
				}
				else
				{
					Console.WriteLine("Error: Invalid Command" + string.Empty);
				}
			}
			else
			{
				Console.WriteLine("Error: Invalid Data" + string.Empty);
			}
			return demoDict;
		}

		//KEYS
		public static Dictionary<string, List<string>> getKeys(Dictionary<string, List<string>> demodisct)
		{
			Dictionary<string, List<string>>.KeyCollection keyColl = demodisct.Keys;
			if (keyColl.Any())
			{
				int kcount = 0;
				foreach (string s in keyColl)
				{
					kcount = kcount + 1;
					Console.WriteLine("{0}) {1}", kcount, s);
				}
			}
			else
			{
				Console.WriteLine("(Empty Set)");
			}
			return demodisct;
		}

		//MEMBERS
		public static Dictionary<string, List<string>> getMembers(Dictionary<string, List<string>> demodisct, string key)
		{
			List<string> list;

			if (demodisct.TryGetValue(key, out list))
			{
				int mCount = 0;
				foreach (var item in list)
				{
					mCount = mCount + 1;
					Console.WriteLine("{0}) {1}", mCount, item);
				}
			}
			else
			{
				Console.WriteLine("(Empty Set)");
			}
			return demodisct;
		}

		//ADD
		public static Dictionary<string, List<string>> AddDictdata(Dictionary<string, List<string>> demodisct, string key, string val)
		{
			List<string> list;

			if (!demodisct.TryGetValue(key, out list))
			{
				list = new List<string>();
				list.Add(val);
				demodisct.Add(key, list);
				Console.WriteLine(") Added.");
			}
			else
			{
				if (list.Contains(val))
				{
					Console.WriteLine($"An element with Member = {val} already exists.");
				}
				else
				{
					list.Add(val);
					Console.WriteLine(") Added.");
				}
			}
			return demodisct;
		}

		//REMOVE
		public static Dictionary<string, List<string>> RemoveDictdata(Dictionary<string, List<string>> demodisct, string key, string val)
		{
			if (!demodisct.ContainsKey(key))
			{
				Console.WriteLine($"Key {key} is not found.");
			}
			else
			{
				List<string> list;
				if (demodisct.TryGetValue(key, out list))
				{
					if (list.Any(k => k == val))
					{
						var item = list.First(k => k == val);
						list.Remove(item);
						Console.WriteLine($"{val} Removed.");
					}
					else
					{
						Console.WriteLine($"{val} Not found to remove");
					}

					if (!list.Any())
					{
						demodisct.Remove(key);
						Console.WriteLine($"Key {key} is removed.");
					}
				}
				else
				{
					demodisct.Remove(key);
					Console.WriteLine($"{key},{val} Removed.");
				}
			}

			return demodisct;
		}

		//REMOVEALL
		public static Dictionary<string, List<string>> RemoveAllDictdata(Dictionary<string, List<string>> demodisct, string key)
		{
			if (!demodisct.ContainsKey(key))
			{
				Console.WriteLine($"Key {key} does not exist.");
			}
			else
			{
				demodisct.Remove(key);
				Console.WriteLine($"{key} Removed.");
			}

			return demodisct;
		}

		//MEMBEREXISTS
		public static void checkMemberExists(Dictionary<string, List<string>> demodisct, string key, string val)
		{
			if (!demodisct.ContainsKey(key))
			{
				Console.WriteLine(demodisct.ContainsKey(key));
			}
			else
			{
				List<string> list;
				if (demodisct.TryGetValue(key, out list))
				{
					Console.WriteLine(list.Any(k => k == val));
				}
				else
				{
					Console.WriteLine(demodisct.TryGetValue(key, out list));
				}
			}
		}

		//ALLMEMBERS
		public static Dictionary<string, List<string>> getAllMembers(Dictionary<string, List<string>> demodisct)
		{
			Dictionary<string, List<string>>.ValueCollection memberColl = demodisct.Values;
			if (memberColl.Any())
			{
				int count = 0;
				foreach (var s in memberColl)
				{
					foreach (var item in s)
					{
						count = count + 1;
						Console.WriteLine("{0}) {1}", count, item);
					}
				}
			}
			else
			{
				Console.WriteLine("(Empty Set)");
			}
			return demodisct;
		}

		//ITEMS
		public static Dictionary<string, List<string>> getAllItems(Dictionary<string, List<string>> demodisct)
		{
			Dictionary<string, List<string>>.KeyCollection keyColl = demodisct.Keys;
			if (keyColl.Any())
			{
				int mCount = 0;
				foreach (string s in keyColl)
				{
					List<string> list;
					if (demodisct.TryGetValue(s, out list))
					{
						foreach (var item in list)
						{
							mCount = mCount + 1;
							Console.WriteLine("{0}) {1}: {2}", mCount, s, item);
						}
					}
					else
					{
						Console.WriteLine("(Empty Set)");
					}
				}
			}
			else
			{
				Console.WriteLine("(Empty Set)");
			}
			return demodisct;
		}
	}
}