using System.Text;

namespace TrieADT
{
    public class Trie
    {
        private readonly string letters = "abcdefghijklmnopqrstuvwxyz";
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word.ToLower()[i] - 'a'; // Assuming lowercase English letters

                if (current.Children[index] == null)
                {
                    current.Children[index] = new TrieNode();
                }

                current = current.Children[index];
            }

            current.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode current = root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a'; // Assuming lowercase English letters

                if (current.Children[index] == null)
                {
                    return false;
                }

                current = current.Children[index];
            }

            return current != null && current.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = root;

            for (int i = 0; i < prefix.Length; i++)
            {
                int index = prefix[i] - 'a'; // Assuming lowercase English letters

                if (current.Children[index] == null)
                {
                    return false;
                }

                current = current.Children[index];
            }

            return current != null;
        }

        public List<string> GetWordsThatStartsWith(string prefix)
        {
            TrieNode current = root;
            List<string> words = new();

            for (int i = 0; i < prefix.Length; i++)
            {
                int index = prefix[i] - 'a';

                if (current.Children[index] == null)
                {
                    return words;
                }

                List<string> newWords = GetWord(current).Item2;
                current = current.Children[index];
            }

            return words;
        }

        private (StringBuilder, List<string>) GetWord(TrieNode node, string prefix, StringBuilder? wordReceived = null, List<string>? words = null)
        {
            if (wordReceived == null) wordReceived = new StringBuilder();

            if (words == null) words = new List<string>();

            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            TrieNode children = node.Children.FirstOrDefault(t => t != null);

            int index = Array.IndexOf(node.Children, children);

            wordReceived.Append(letters[index]);

            if (prefix.Equals(wordReceived.ToString()))
            {
                List<TrieNode> tries = children.Children.Where(c => c != null).ToList();

                for (int i = 0; i < tries.Count(); i++)
                {
                    words.AddRange(GetWord(tries[i], wordReceived, words).Item2);
                }
            }

            if (children != null && !children.IsEndOfWord)
                (wordReceived, words) = GetWord(children, prefix, wordReceived, words);
            else
                words.Add(wordReceived.ToString());

            return (wordReceived, words);
        }

        private (StringBuilder, List<string>) GetWord(TrieNode node, StringBuilder? wordReceived = null, List<string>? words = null)
        {
            if (wordReceived == null) wordReceived = new StringBuilder();

            if (words == null) words = new List<string>();

            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            List<TrieNode> allChildrenWithContent = node.Children.Where(t => t != null).ToList();

            for (int i = 0; i < allChildrenWithContent.Count; i++)
            {
                int index = Array.IndexOf(node.Children, allChildrenWithContent[i]);

                wordReceived.Append(letters[index]);

                if (allChildrenWithContent[i] != null && !allChildrenWithContent[i].IsEndOfWord)
                    (wordReceived, words) = GetWord(allChildrenWithContent[i], wordReceived, words);
                else
                {
                    words.Add(wordReceived.ToString());
                    wordReceived.Clear();
                }
            }


            return (wordReceived, words);
        }
    }
}
