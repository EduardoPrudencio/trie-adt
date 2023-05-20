# trie-adt

Nesse exemplo, a classe Trie representa a árvore Trie, e a classe TrieNode representa um nó da árvore. 
Cada nó contém um array de tamanho fixo (26 no caso, representando as 26 letras minúsculas do alfabeto inglês) 
para armazenar seus filhos. O método Insert insere uma palavra na árvore, o método Search verifica se 
uma palavra está presente na árvore e o método StartsWith verifica se existem palavras na árvore com um determinado prefixo.


Uma Trie, também conhecida como árvore de prefixos, é uma estrutura de dados especializada usada para armazenar um conjunto de 
palavras em que cada nó representa um caractere. Ela é amplamente utilizada para realizar operações eficientes em dicionários de palavras, 
como pesquisa, inserção e exclusão de palavras.

Uma Trie possui as seguintes características:

Estrutura Hierárquica: Os caracteres das palavras são organizados em uma estrutura hierárquica de árvore, onde cada nó representa um caractere. 
O caminho da raiz até um nó folha representa uma palavra completa.

Prefixos Compartilhados: A Trie aproveita a propriedade de que muitas palavras compartilham prefixos comuns.
Isso significa que os nós na Trie podem ser compartilhados entre várias palavras, economizando espaço de armazenamento.

Eficiência na Pesquisa: A Trie oferece uma busca rápida de palavras, pois não é necessário percorrer todos os nós da árvore.
    A busca é feita caractere por caractere, seguindo o caminho correspondente na Trie.

Inserção e Exclusão Eficientes: A inserção e exclusão de palavras em uma Trie são operações relativamente rápidas. 
Elas envolvem o percurso da árvore de acordo com os caracteres da palavra e a criação ou remoção de nós conforme necessário.

Suporte a Prefixos: A Trie é especialmente útil para pesquisar palavras com base em prefixos. 
Ela pode ser facilmente adaptada para encontrar todas as palavras que começam com um determinado prefixo, o que é muito eficiente em comparação com outras estruturas de dados.

As vantagens de uma Trie incluem:

Eficiência na Pesquisa: A pesquisa em uma Trie é muito rápida e tem complexidade de tempo O(m), onde m é o tamanho da palavra a ser pesquisada. 
Isso torna a Trie uma escolha eficiente para aplicações que exigem pesquisa de palavras.

Compartilhamento de Prefixos: As Trie compartilham nós comuns entre palavras que possuem prefixos idênticos ou semelhantes.
    Isso resulta em economia de espaço em comparação com estruturas de dados lineares, como listas ou arrays.

Suporte a Autocompletar: Como as Trie permitem pesquisar palavras com base em prefixos, elas são frequentemente usadas em recursos de autocompletar ou sugestão de palavras, 
como em editores de texto ou mecanismos de pesquisa.

Flexibilidade: A Trie é flexível e pode ser adaptada para diferentes aplicações. Ela pode ser usada para resolver problemas que envolvam pesquisa de palavras, 
como verificação de ortografia, análise de texto, jogos de palavras, entre outros.

No entanto, é importante observar que uma desvantagem da Trie é o consumo de espaço, especialmente quando há um grande número de palavras com prefixos comuns. 
Em alguns casos, o uso de memória pode ser maior do que em outras estruturas de dados. Além disso, as Trie podem exigir um pouco mais de esforço para implementação em comparação com estruturas de dados mais simples.
