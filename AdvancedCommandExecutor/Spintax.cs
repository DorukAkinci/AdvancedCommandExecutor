using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace AdvancedCommandExecutor
{
    static class Spintax
    {
        internal static string Spin(Random rnd, string str)
        {
            // Loop over string until all patterns exhausted.
            string pattern = "{[^{}]*}";
            Match m = Regex.Match(str, pattern);
            while (m.Success)
            {
                // Get random choice and replace pattern match.
                string seg = str.Substring(m.Index + 1, m.Length - 2);
                string[] choices = seg.Split('|');
                str = str.Substring(0, m.Index) + choices[rnd.Next(choices.Length)] + str.Substring(m.Index + m.Length);
                m = Regex.Match(str, pattern);
            }

            // Return the modified string.
            return str;
        }

        internal static List<string> CreateAllPossiblePermutations(string text)
        {
            string pattern = "{[^{}]*}";
            List<string> _allPossiblePermutations = new List<string>();
            List<string> _calculatingPermutations = new List<string>
            {
                text
            };

            while (_calculatingPermutations.Count > 0)
            {
                var _selectedText = _calculatingPermutations[0];
                Match m = Regex.Match(_selectedText, pattern);
                if (m.Success)
                { 
                  // Get a choice and replace pattern match. Calculate all possible choices.
                    string seg = _selectedText.Substring(m.Index + 1, m.Length - 2);
                    string[] choices = seg.Split('|');
                    foreach (var _choice in choices)
                    {
                        var _choicedText = _selectedText.Substring(0, m.Index) + _choice + _selectedText.Substring(m.Index + m.Length);
                        _calculatingPermutations.Remove(_selectedText);
                        if (Regex.Match(_choicedText, pattern).Success)
                        {
                            _calculatingPermutations.Add(_choicedText);
                        }
                        else
                        {
                            _allPossiblePermutations.Add(_choicedText);
                        }
                    }
                }
            }
            // Return List.
            return _allPossiblePermutations;
        }
    }
}
