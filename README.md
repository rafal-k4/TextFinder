# TextFinder

Projekt "TextFinder" działa w oparciu o zasadę działania algorytmów genetycznych. <br />
Wpisując docelowy tekst w odpowiednio oznakowywany do tego *textbox* aplikacja będzie szukała tego ciągu tekstu. <br />
W normalnym przypadku, metodą "Brute Force" dla ciągu znaków o długości powyżej 10 (w skład których mogą wchodzić litery małe, duże oraz znaki specjalne) wyszukując 1 miliard haseł na sekunde z prostego rachunku prawdopodobieństwa wynika, że znalezienie takiego łańcucha znaków zajęłoby lata.<br />
W tej aplikacji znalezienie takiego ciągu znaków nie stanowi większego problemu, dzięki zastosowaniu algorytmów genetycznych.<br />
Podobnie jak w projekcie Homing Rockets, również w tym przypadku dzięki mechanizmowi nagradzania najlepiej sobie radzących osobników, które to kolejno przekazują swój genotyp kolejnym pokoleniom z pokolenia na pokolenie program jest coraz bliższy dotarcia do celu.<br />
W celu zwiększenia szybkości działania programu, ograniczono się do znaków: małe litery, duże litery, spacja, kropka, przecinek, nawiasy kwadratowe, podkreślnik, apostrof, ukośnik prawy. <br />
