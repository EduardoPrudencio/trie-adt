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
                int index = word[i] - 'a'; // Assuming lowercase English letters

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

                StringBuilder word = GetWord(current, prefix);
                current = current.Children[index];
            }

            return words;
        }

        private StringBuilder GetWord(TrieNode node, string prefix, StringBuilder? wordReceived = null, List<string> words = null)
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

            bool patternFound = prefix.Equals(wordReceived.ToString());

            if (children != null && !children.IsEndOfWord) wordReceived = GetWord(children, prefix, wordReceived, words);

            words.Add(wordReceived.ToString());

            return wordReceived;
        }
    }
}
