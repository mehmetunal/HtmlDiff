using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Compare
{
    public class CompareLibrary
    {
        private readonly string pattern = @"<[^>]*?>(.*?)<[^>]*?>|[a-zA-Z0-9\=*?()]+";
        public string CompareText(string oldValue, string newValue)
        {
            StringBuilder newText = new StringBuilder();

            oldValue = Regex.Replace(oldValue, @"(<br */>)|(\[br */\])", "");
            newValue = Regex.Replace(newValue, @"(<br */>)|(\[br */\])", "");

            List<string> oldArray = new List<string>();
            List<string> newArray = new List<string>();

            if (oldValue != null)
                oldArray = Regex.Matches(oldValue, pattern, RegexOptions.IgnoreCase).Select(s => s.Value).ToList();

            if (newValue != null)
                newArray = Regex.Matches(newValue, pattern, RegexOptions.IgnoreCase).Select(s => s.Value).ToList();

            if (oldArray.Count() > newArray.Count())
            {
                var count = (oldArray.Count() - newArray.Count());
                for (int i = 0; i <= count - 1; i++)
                    newArray.Add(string.Empty);
            }
            else
            {
                var count = (newArray.Count() - oldArray.Count());
                for (int i = 0; i <= count - 1; i++)
                    oldArray.Add(string.Empty);
            }

            for (int i = 0; i <= oldArray.Count() - 1; i++)
            {
                if (oldArray[i].ToString().Equals(newArray[i].ToString()) == false && oldArray[i] != string.Empty && newArray[i] != string.Empty)
                {
                    if (oldArray.Count(p => p.Equals(newArray[i].ToString())) > 0)
                    {
                        newText.Append(RemoveText(oldArray[i].ToString()) + " " + newArray[i].ToString() + " ");
                    }
                    else
                    {
                        newText.Append(AddText(newArray[i].ToString()) + " ");
                    }
                }
                else
                {
                    if (oldArray[i] == string.Empty && newArray[i] != string.Empty)
                    {
                        newText.Append(AddText(newArray[i].ToString()) + " ");
                    }
                    else if (oldArray[i] != string.Empty && newArray[i] == string.Empty)
                    {
                        newText.Append(RemoveText(oldArray[i].ToString()) + " ");
                    }
                    else
                    {
                        newText.Append(newArray[i].ToString() + " ");
                    }
                }
            }
            return newText.ToString();
        }
        private object AddText(string text) => "<ins style='background-color:#4CAF50'>" + text + "</ins>";
        private object GrayText(string text) => "<em style='background-color:#a6a7a7'>" + text + "</em>";
        private object UpdateText(string text) => "<mark>" + text + "</mark>";
        private object RemoveText(string text) => "<del style='background-color:red'>" + text + "</del>";
    }
}
