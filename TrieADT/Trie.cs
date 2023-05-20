namespace TrieADT
{
    public class Trie
    {
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
    }
}
