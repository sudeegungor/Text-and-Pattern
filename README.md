# Text-and-Pattern

A C# program that takes a text and a pattern from the user and prints all the words in the text that corresponds to this
pattern.
The text contains only English alphabet letters and two punctuations dot (.) and comma (,).
The pattern can contain letters, as well as either the character(s) of “*” or the character(s) of “-”, but not both of them.
The symbol “*” corresponds to any number of letters (zero or more).
The symbol “-“ corresponds to only one letter.
For example; if a pattern contains a single “*”, this symbol should match any number of letters in the word; the other
characters in the word and pattern must be equal.
If the same word repeats more than one times, the program must print it only one time.

Examples:
Input: "Miss Polly had a poor dolly, who was sick. She called for the talled doctor Solly to come
quick. He knocked on the DOOR like a actor in the healthcare sector.";

Input: -olly
Output: Polly
 dolly
 Solly
 
 Input: -al-e
 Output: called
 talled
 
 
