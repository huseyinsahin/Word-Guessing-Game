# Kelime Tahmin Oyunu / Word Guessing Game
Oyun iki modda ve iki farklı puanlama sistemi ile oynanmaktadır.</br>
***The game is played in two modes and with two different scoring systems.***
## Oyun Modları / Game Modes
* Bilgisayarın sözlük içerisindeki bir kelimeyi tuttuğu ve insanın her adımda tahmin ettiği kelimeye karşılık puan vererek devam etmesi</br>
***The computer keeps a word in the dictionary and the person continues by giving points for the word they guess at each step.***
* İnsanın sözlük içerisindeki bir kelimeyi tuttuğu ve bilgisayarın her adımda tahmin ettiği kelimeye karşılık puan vererek devam etmesi</br>
***Keeping a word in the dictionary and continuing by giving points for the word the computer guesses at each step***
## Puan Modları / Score Modes
* Sıralı Puanlama</br>
***Ranked Scoring***
* Kartezyen Puanlama</br>
***Cartesian Scoring***

## Oyun Form Ekranı Gösterimi / Game Form Screen Display
<p align="center">
  <img src="https://github.com/huseyincatalbas/word-guessing-game/blob/master/images/form_tasar%C4%B1m%C4%B1.jpg" align="center">
</p>


## Kelime Tahmin Oyunu (Bilgisayar - İnsan) / Word Guessing Game (Computer - Human)
Oyunda bilgisayar, kullanıcının sözlükten seçtiği bir kelimeyi en az tahminle bulmaya çalışmaktadır. Kullanıcı açılan form ekranından puanlama sistemini 
kartezyen veya normal olarak seçmektedir.</br>
***In the game, the computer tries to find a word selected by the user from the dictionary with the least guesses. The user chooses the scoring system as 
cartesian or normal from the opened form screen.***

Tahmin etme işlemi için, hem yapının hızla oluşturulması hem de kısa sürede bir sonraki tahminin bulunabilmesi 
için seçilen puanlama sistemine göre tüm sözlüğü bir ağaca yerleştirmek gayet verimli olmaktadır. Bunun için ağaca her eklenecek yeni kelimenin, ağacın 
root düğürnünden itibaren, yeni kelimenin potansiyel parent kelimesine puanı hesaplanıp, ilgili child dalı boş bulunana kadar ağaçta aşağı inilir. 
Boş olan dal bulunduğunda kelime ekleme işlemi yapılabilir.</br>
***For the guessing process, it is very efficient to place the entire dictionary on a tree according to the 
chosen scoring system, both to quickly create the structure and to find the next guess in a short time. For this, the score of each new word to be added to the 
tree, starting from the root node of the tree, to the potential parent word of the new word is calculated and the tree is descended until the relevant child 
branch is found empty. When the empty branch is found, word addition can be done.***

### Sözlüğün Ağaç İçin Daha Optimum Hale Getirilmesi / Optimizing the Dictionary for the Tree
Ağacın derinliğine düşürebilmek için tepeden aşağıya doğru maksimum dallanma olacak şekilde ağaca eklenme yapılmalıdır. Bunun için daha iyi yaklaşımlar
mümkün olsa da gerçekleme konusunda yaşanan problemlerden dolayı, sözlüğü en uzun kelimeler başta en kısa kelimeler sonda olacak şekilde sıralamak tercih edilmiştir 
(örn: "ab" için normal puanlamada 0,1,2 puan alternatifleri varken 3 dala ayrılan root, "abandone" kelimesi için 0,1,2,3,4,5,6,7,8 puanlarını verebilir). 
Bu sayede tek tahminde ağaçtan daha fazla eleme yapılabilir. Yani ilgili child düğümegidildiğinde daha az kelime kalmış olma ihtimali yüksektir.</br>
***In order to reduce the depth of the tree, it should be added to the tree so that there is maximum branching from the top to the bottom. 
Although better approaches are possible for this, due to the problems experienced in implementation, it is preferred to sort the dictionary with the longest 
words first and the shortest words at the end (eg: root divided into 3 branches, while there are 0,1,2 points alternatives in the normal scoring for "ab", 
for the word "abandone" can score 0,1,2,3,4,5,6,7,8). In this way, more eliminations can be made from the tree in a single guess. In other words, there is a high 
probability that fewer words are left when the relevant child node is visited.***

### Düğümlerin Oluşturulması / Creating Nodes
Her bir düğüm temel olarak bir kelime ve bu kelimeden alınabilecek olası puanlar kadar child düğtim gösterebilecek kadar dal içermeli. Bu aşamada kartezyen 
puanlama sistemine göre çok çeşitli puanlar gelebileceği için her bir düğtimde iki liste tutup, bir listedepuan ve diğer listede puanıyla aynı indiste o 
puana sahip child pointeri tutulmaktadır. Bu yapı sayesinde hem kartezyen puanlama için hem normal puanlama için kullanılabilir temel bir ağaç üretme sistemi
oluşturulabilir olmaktadır.</br>
***Each node should basically contain a word and enough branches to show as many child nodes as possible points that can be taken from this word. 
At this stage, according to the Cartesian scoring system, there may be a wide variety of scores, so two lists are kept in each node, a score in one list and a child 
pointer with that score in the same index with the score in the other list is kept. Thanks to this structure, a basic tree generation system that can be used for both 
cartesian scoring and normal scoring can be created..***

### Puanlama Sistemleri / Scoring Systems
Kartezyen ve normal olmak üzere iki farklı puanlama için true-false yapısıyla seçilmektedir. Her iki yöntemde de agaç yapısı ve oluşturma aşamaları değişmemektedir
ancak kartezyen puanlamada dallanma miktarı daha yüksek olduğu icin tahmin sayısını düşürmektedir. Bunun sebebi ise harflerin tekrarlı karşılaştırılmasının gizli 
kelimeye dair daha fazla ipucu içermesidir. </br>
***It is selected with a true-false structure for two different scoring, Cartesian and normal. In both methods, tree structure and formation stages do not change, 
but since the amount of branching is higher in Cartesian scoring, it reduces the number of predictions. This is because repeated comparisons of letters contain more 
clues about the hidden word.***

Agaçta ise bu durum normal puanlamaya göre dallanma sayısı en fazla, tahmin edilen kelimenin sayısı n ise n+1 kadarken
kartezyende bundan cok daha fazla olabilmektedir. Dallanmanın artması herhangi bir koşulda agacın root düğümü ile en uzak düğüm arasındaki mesafenin düşmesi ihtimalini arttırır.</br>
***In the tree, this situation is the highest number of branches according to the normal scoring, and the number of predicted words is n+1, whereas in Cartesian it can be much more. 
Increasing branching increases the probability that the distance between the root node of the tree and the furthest node will decrease under any condition.***

### Tahmin Edilen Kelimeye Doğru İlerlemek / Proceeding to the Guessed Word
Oyun başında seçilen puanlama sistemine gore oluşturulmuş agactaki root düğümün içeriği kullanıcıya tahmin olarak verilir. Kullanıcının hesaplayıp verdiği puana göre,
ağaçta sadece bir dal o puanı sağlayabileceği için sonraki tahmin, otomatik olarak root'un kullanıcı tarafından verilen puanına sahip child'ı olarak seçilir. 
Bu durumda zaten ağaç oluşturulurken tüm puan hesaplama işlemleri root düğümden itibaren yapıldığı için root'un: ilgili child' na göre olan puanı, root'un; ilgili 
child’ının tüm child düğümlerine göre olan puanına eşittir.</br>
***The content of the root node in the tree created according to the scoring system selected at the beginning of the game is given to the user as a guess. 
According to the score calculated by the user, since only one branch in the tree can provide that score, the next guess is automatically chosen as root's child with 
the score given by the user. In this case, while creating the tree, all points are calculated from the root node, so the root's score according to the related child 
is the root's; is equal to the score of its child relative to all child nodes.***

Sonuç olarak, sadece her tahmin işlemi sonrasinda kullanıcının verdiği puana sahip child düğümüne gidilir ve bu islem ya kullanıcı oyunu sonlandırana kadar ya da
hiç doğru puana sahip child kalmayana kadar devam edilir.Hiç doğru puana sahip child düğüm kalmadığında kelime sözlükte mevcut değildir. 
Kullanıcıdan bu aşamada sözlüğe kaydetmek için kelimenin kendisi istenmektedir.</br>
***As a result, only after each guessing operation, the child node with the score given by the user is reached, and this process continues until either the user ends
the game or there are no children with the correct score. When there are no child nodes with the correct score, the word is not available in the dictionary. 
At this stage, the user is asked to save the word itself in the dictionary.***

### Genel Olarak Programın Akışı / Flow of the Program in General
1. Sözlüğün okunması ve uzun kelimeden kısa kelimeye doğru sıralaması
Örnek olarak sözlüğümüz "{ "ana", "adana", "acemi", "edebi", "leblebi", "zil"}" olsun. "{"leblebi", "adana", "acemi", "edebi", "ana", "zil"}" şeklinde bir listeye 
dönüştürmüş oluyoruz. (C# kodunda quick sort kullanılmakta)</br>
***For example, let's say our dictionary is "{ "ana", "adana", "acemi", "edebi", "leblebi", "zil"}"  We turn it into a list such as 
"{"leblebi", "adana", "acemi", "edebi", "ana", "zil"}". (Quick sort is used in C# code)***

2. Uzun kelimeden kısa kelimeye doğru ağacın oluşturulması için listeden sırayla okuma yapılır ve ağaca add işlemleri yapılır.</br>
***In order to form the tree from the long word to the short word, the list is read sequentially and the tree is added.***
<p align="center">
  <img src="https://github.com/huseyincatalbas/word-guessing-game/blob/master/images/ornek.JPG" align="center">
</p>

3. Sonuç olarak oluşan ağaçtan alınana her tahmindeki puana göre ilgili daldaki kelime tahmin olarak yazdırılacaktır. Bu ardışık ilerleme sonucu ya ağaça sonlanır, 
ki bu durumda sözlükte tutulan kelimenin varlığı mümkün değildir, ya da en kötü ihtimalle son tahmin edilen kelime kullanıcının tuttuğu kelimedir.</br>
***As a result, the word in the relevant branch will be printed as a guess, according to the score in each guess from the tree that is formed. 
The result of this sequential progression either ends up in the tree, in which case the word retained in the dictionary is not possible, or in the worst case, 
the last guessed word is the one the user holds.***

## Kelime Tahmin Oyunu (İnsan-Bilgisayar) / Word Guessing Game (Human-Computer)
Oyunda bu modda ise amaç bilgisayar tarafından sozükten rastgele seçilen bir kelimenin kullanıcı tarafından en az tahminle bulmasıdır. Kullanıcı açılan form ekranından
puanlama sistemini kartezyen veya normal olarak seçmektedir.</br>
***In this mode of the game, the aim is to find a word randomly selected from the word by the computer with the least guesses by the user. 
The user chooses the scoring system as cartesian or normal from the opened form screen.***</br>

Bu modda bilgisayarın ağaç oluşturmasına veya sözlüğü sıralamasına gerek yoktur.
Sadece yine Bilgisayar-İnsan modundaki gibi true-false yapısı ile normal veya kartezyen puanlama sistemini seçip aynı puan hesaplama fonksiyonlarıyla elde ettiği 
puanları döndürülecektir.</br>
***In this mode the computer does not need to build a tree or sort the dictionary. Just as in the Computer-Human mode, the scores obtained with the same score calculation
functions by choosing the normal or cartesian scoring system with the true-false structure will be returned.***

### Kartezyen ve Normal Modda Puan Hesaplamaları / Score Calculations in Cartesian and Normal Mode
* <b>Kartezyen Puan Hesaplama / Cartesian Score Calculator</b></br>
Kartezyen puan hesabı için,tutulmuş olan veya tutulmuş olduğu tahmin edilen kelimenin her bir harfinin, hesaplanan kelimede kaçar defa geçtiklerinin toplam değeri hesaplanmaktadır. </br>
***For the Cartesian score calculation, the total value of how many times each letter of the word that is or is predicted to be involved is used in the calculated word.***

<p align="center">
  <img src="https://github.com/huseyincatalbas/word-guessing-game/blob/master/images/kartezyen_puan_hesaplama.JPG" align="center">
</p>

* <b>Normal Puan Hesaplama / Normal Score Calculation</b></br>
Kartezyen puan hesaplamaktan tek farkı yukarıdaki flowchartta belirtilen algoritmaya girmeden önce tutulmuş olma olasılığı olan veya tutulmuş kelimenin tekrar edilen harflerinin silinmiş olmasıdır. 
Böylece her bir harfin tahmin kelimesinde kaç kere geçtiğinin toplam değerini elde etmiş oluruz.</br>
***The only difference from calculating a Cartesian score is that before entering the algorithm specified in the flowchart above, the repeated letters of the word that may
have been afflicted or that have been afflicted are deleted. Thus, we get the total value of how many times each letter occurs in the prediction word.***

