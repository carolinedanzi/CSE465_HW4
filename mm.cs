using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace CSE465 {

	public class MailMerge {
		
		private string tsvFile, tmpFile;
		private Dictionary<string, int> headers;
		
		public MailMerge(string tsvFile, string tmpFile) {
			this.tsvFile = tsvFile;
			this.tmpFile = tmpFile;
			this.headers = new Dictionary<string, int>();
		}
		
		public void parseTsv() {
			StreamReader tsvReader = new StreamReader(tsvFile);
			
			// The first line has the headers, so create
			// the dictionary of header and index pairs
			string headerLine = tsvReader.ReadLine();
			string[] tsvHeaders = headerLine.Split('\t');
			for(int i = 0; i < tsvHeaders.Length; i++) {
				headers.Add(tsvHeaders[i], i);
			}
			
			int idIndex = headers["ID"];
			StreamWriter output;
			StreamReader tmpReader;
			// Go through each line in the tsvFile
			while(!tsvReader.EndOfStream) {
				// Get the line, split it based on tab
				string line = tsvReader.ReadLine();
				string[] tokens = line.Split('\t');
				
				// Create and open the file for writing
				string fileName = tokens[idIndex] + ".txt";
				output = new StreamWriter(fileName);
				tmpReader = new StreamReader(tmpFile);
				
				while(!tmpReader.EndOfStream) {
					string templateLine = tmpReader.ReadLine();
					line = replaceHeaders(templateLine, tokens);
					output.WriteLine(line);
				}
						
				output.Close();
				tmpReader.Close();
			}
			
		}
		
		private string replaceHeaders(string line, string[] tokens) {
			string pattern = "<<(.*?)>>";
			Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
			MatchCollection matches = rx.Matches(line);
			
			foreach(Match m in matches) {
				string attribute = tokens[headers[m.Groups[1].ToString()]];
				line = line.Replace(m.Value, attribute);
			}
			return line;
		}
		
		public static void Main(string[] args) {
			MailMerge mm = new MailMerge(args[0], args[1]);
			mm.parseTsv();
		}
	}

}