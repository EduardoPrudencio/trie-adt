namespace TrieADT
{
    public class TrieNode
    {
        private const int AlphabetSize = 26; // Assuming lowercase English letters

        public TrieNode[] Children { get; }
        public bool IsEndOfWord { get; set; }

        public TrieNode()
        {
            Children = new TrieNode[AlphabetSize];
            IsEndOfWord = false;
        }
    }
}
