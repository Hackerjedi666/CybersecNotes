# Regex

## Basics
- / expression / flags, i.e /[A-Z]+/g basic format
- / hello\?\*\\/ escape special characters with backslashes
- () group with parentheses
- | logical OR


## Character classes
- \w word \d digit \s whitespace (tabs, line breaks)
- \W NOT word \D NOT digit \S NOT whitespace
- \t tabs, \n line breaks
- . any character (except newline)


## Brackets
[xyz] match any x, y, z
[J-Z] match any capital letters between J & Z.
[^xyz] NOT x, y, z

## Quantification
- bob|alice match bob or alice
- z? zero or one occurrences
- z* zero or multiple occurrences
- z+ one or multiple occurrences
- z{n} n occurrences
- z{min,max} min/max occurrences

## Anchors
- hello world exact match
- ^hello start of the strings
- world$ end of the string


Python regex module is ```import re```






