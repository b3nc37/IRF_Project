Az általam húzott tételek alapján az az ötletem támadt, hogy egy XML to CSV Convertert készítek.
Amelynek az két fő funkciója az lesz, hogy elsősorban beolvas egy adott Xml-t ("Choose XML" gomb) majd azt átalakítja
olyan formába amely már könnyedén kiírható CSV formátumba is. Emellett a felhasználónak lehetősége van új CSV típusú fájlt
létrehoznia vagy egy létezőt kiválasztania.("Choose or Create CSV" gomb) Az utóbbi esetben hozzáfűzés történik.
Ezután megtörténik a kiírás Csv-be.("Convert"gomb)
Nem legutolsó sorban pedig Unit Test-et valósítok meg, hogy ellenőrizzem egyes funkciók helyes működését. 
Összeségében véleményem szerint ez egy hasznos funkció lehet mivel elképzelhető olyan életszituáció amikor
Xml fájlt Csv-be kell konvertálni. Emellett a timer-t egy óraként szeretném felhasználni az alkalmazásban, hogy a
felhasználói kényelmet növelje.
Ezen felül alkalmazásom felhasználói felületét könnyen kezelhetőre terveztem, színvak barát színösszeállítással és
ezt kiegészítve egy súgóval.