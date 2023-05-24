using TrieADT;

namespace TrieTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Nao_Deve_Encontrar_Palavras_Nao_Cadastradas()
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            Assert.IsFalse(trie.Search("banana"));
        }

        [TestMethod]
        public void Deve_Encontrar_Palavras_Cadastradas()
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            Assert.IsTrue(trie.Search("apple"));
        }

        [TestMethod]
        public void Nao_Deve_Encontrar_Prefixo_De_Palavras_Nao_Cadastradas()
        {
            Trie trie = new Trie();
            trie.Insert("abacaxi");
            Assert.IsFalse(trie.Search("per"));
        }

        [TestMethod]
        public void Deve_Encontrar_Prefixo_De_Palavras_Cadastradas()
        {
            Trie trie = new Trie();
            trie.Insert("abacaxi");
            Assert.IsTrue(trie.StartsWith("aba"));
        }
        [TestMethod]
        public void Deve_Encontrar_Palavras_Por_Prefixo()
        {
            Trie trie = new Trie();
            trie.Insert("telefone");
            trie.Insert("Abacaxi");
            trie.Insert("Abacadabra");
            trie.Insert("Jose");
            Assert.IsTrue(trie.GetWordsThatStartsWith("tel").Count == 1);
        }
    }
}