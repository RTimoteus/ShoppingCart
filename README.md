# ShoppingCart

Feladat: áruházi kosár tartalmának ára

Tegyük fel, hogy egy áruházi bevásárlás során minden vásárolt terméket leolvasunk a pénztárnál és az eredmény 
egy string lesz. Ebben nagybetűk jelölik az egyes termékeket. Például veszünk A-t, B-t és D-t, akkor a string “ABD”.

Miután tudjuk, hogy az egyes termékeknek mennyi az ára, a feladat egy olyan metódus elkészítése, 
mely a kosár tartalmát (stringként) megkapja és visszaadja az összesített árat.

A házi feladat egy olyan osztály elkészítése, mely a fenti feladatot el tudja végezni úgy, 
hogy közben speciális helyzetek módosítják az árakat. Ilyen például a “kettőt fizet, hármat vihet” akció.


1. feladat: lehessen termékeket regisztrálni és az árukat megadni

Az osztálynak meg lehet adni termékeket és árakat (pl. ‘A’ és 54), 
egy kosár tartalmára (pl. “ABC”) pedig meg tudja mondani az összesített árat.

Például:

Shop.RegisterProduct('A', 10);
Shop.RegisterProduct('C', 20);
Shop.RegisterProduct('E', 50);
var price = Shop.GetPrice("ACEE");  // 130-at ad vissza


2. feladat: 3-at fizet, 4-et vihet akció

Meg lehet adni olyan kedvezményt, hogy N darab vásárlása esetén M-et vihet ugyanazon az áron.

Például:

Shop.RegisterProduct('A', 10);
Shop.RegisterProduct('E', 50);
Shop.RegisterCountDiscount('A', 3, 4); // 3 áráért 4-et vihet
var price = Shop.GetPrice("AAAAAEEE");  // 5*10+3*50 helyett 4*10+3*50


3. feladat: mennyiségi kedvezmény

Ha egy termékből pl. legalább 5-öt veszek, a termék árából kapok 10% kedvezményt.

Shop.RegisterProduct('A', 10);
Shop.RegisterProduct('B', 100);
Shop.RegisterAmountDiscount('A', 5, 0.9);   // 5 darabtól, 0.9-es szorzó
var price = Shop.GetPrice("AAAAAAB");  // 6*10*0.9+100


4. feladat: kombó kedvezmény

Pl. A, B és C külön-külön megvásárolva 20 lenne, de így együtt csak 16.

Shop.RegisterProduct('A', 10);
Shop.RegisterProduct('B', 20);
Shop.RegisterProduct('C', 50);
Shop.RegisterProduct('D', 100);
Shop.RegisterComboDiscount("ABC", 60);
var price = Shop.GetPrice("CAAAABB");  // ABC+AAAB -> 60+3*10+20

5. feladat: klubtagság 

Ha egy kosárban szerepel a “t” betű (kisbetű, ami nem lehet termék), akkor az azt jelenti, 
hogy a pénztárnál lecsippantottak egy tagsági kártyát. Ekkor a végösszegből jár 10% kedvezmény.

6. feladat: kombó klubtagság esetén

A kombó kedvezményekre megadható, hogy az csak klubtagoknak jár.

7. feladat: user ID és pontgyűjtés

Ha a kosárban egy számjegy is szerepel (pl. ‘3’), akkor az a vásárló azonosító száma. 
Ekkor a program a kosár értékénak 1%-át “supershop pontként” eltárolja. 
(Fájlba nem menti el, csak a memóriában tárolja most, így a program leállása után a pontok elvesznek.)

Ha egy kosárban szerepel a ‘p’ betű, akkor a vevő a “supershop” pontjaiból szeretne fizetni. 
A supershop pontjai levonódnak a végösszegből és csak a maradékot kell kifizetni.
