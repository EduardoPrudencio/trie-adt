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

                string word = GetWord(current.Children[index]);

                current = current.Children[index];
            }

            return words;
        }

        private string GetWord(TrieNode node)
        {
            TrieNode firstLetter = node.Children.FirstOrDefault(t => t != null);

            StringBuilder wordReceived = new StringBuilder();

            for (int i = 0; i < node.Children.Length; i++)
            {
                
            }

            return wordReceived.ToString();
        }
    }
}
