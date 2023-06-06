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

                List<string> newWords = GetWordsByPrefix(prefix);
                current = current.Children[index];

            }

            return words;
        }

        public List<string> GetWordsByPrefix(string prefix)
        {
            List<string> words = new List<string>();
            TrieNode prefixNode = GetPrefixNode(prefix);

            if (prefixNode != null)
            {
                StringBuilder currentWord = new StringBuilder(prefix);
                GetWordsByPrefix(prefixNode, currentWord, words);
            }

            return words;
        }

        private TrieNode GetPrefixNode(string prefix)
        {
            TrieNode current = root;

            foreach (char c in prefix)
            {
                int index = c - 'a';

                if (current.Children[index] == null)
                {
                    return null;
                }

                current = current.Children[index];
            }

            return current;
        }

        private void GetWordsByPrefix(TrieNode node, StringBuilder currentWord, List<string> words)
        {
            if (node.IsEndOfWord)
            {
                words.Add(currentWord.ToString());
            }

            for (int i = 0; i < node.Children.Length; i++)
            {
                if (node.Children[i] != null)
                {
                    char letter = (char)('a' + i);
                    currentWord.Append(letter);
                    GetWordsByPrefix(node.Children[i], currentWord, words);
                    currentWord.Length--;
                }
            }
        }

    }
}
