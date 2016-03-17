"""
Caroline Danzi
Dr. Zmuda
CSE 465

Note: I used http://www.tutorialspoint.com/python/python_command_line_arguments.htm
to learn how to get command line arguments in Python.  I also used the Python 3
documentation for string methods, and notes from another class for regex syntax.
"""

import sys

# The first command line argument at 0 is the file name, the second will be
# the tsv, and the third will be the tmp file.  
tsvFile = sys.argv[1]
formFile = sys.argv[2]

# open the files for reading
tsvFile = open(tsvFile, "r")
formFile = open(formFile, "r")

# The first line in the tsv file has the column headings
colHeadings = tsvFile.readline().strip().split('\t')

# Build a dictionary of the column headings where the key
# is the string heading and the value is the index
columns = {}
i = 0
for column in colHeadings:
    columns[column] = i
    i += 1

# Get the index of the ID column for file name
idIndex = columns['ID']

for line in tsvFile:
    cells = line.strip().split('\t')
    fileName = cells[idIndex] + '.txt'
    print(fileName)
    
