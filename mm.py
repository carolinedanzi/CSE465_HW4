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
print(sys.argv[0])
print(sys.argv[1])
print(sys.argv[2])

tsvFile = sys.arg[1]
formFile = sys.arg[2]

tsvFile = open(tsvFile, "r")
formFile = open(formFile, "r")

colHeadings = tsvFile.readLine().strip.split('\t')
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
    
