# OgloszeniaZadanie
Napisz aplikację która wchodzi na stronę https://ogloszenia.trojmiasto.pl/motoryzacja-sprzedam/ i następnie wyszukuje markę/model pojazdu którą pobierze z pliku konfiguracyjnego.
Config to plik tekstowy(w formacie json) w którym podane są informacje na temat Marki/Modelu i ewentualna informacja z ilu stron ma być przeprowadzone wyszukiwanie.
Po wyszukaniu danej frazy, program powinien przemapować zawartość strony do obiektów dostępnych w kodzie – a następnie wyliczyć średnie wartości rekordów na stronie:
- średnia cena, przebieg, rok produkcji, pojemność silnika
Program powinien wypisać wyżej wymienione wartości do konsoli.
Program powinien zapisać wyniki do pliku w formacie json.
Program powinien posiadać obsługę pobierania i zbierania wyników z wielu stron wyszukiwania – czyli wartości średnie muszą być liczone dla danej ilości stron z wynikami.
Domyślnie jeśli nie podamy odpowiedniego parametru w configu - zbieramy wyniki ze wszystkich dostępnych stron.
Program powinien mieć zaimplementowaną podstawową obsługę błędów.

Config:
- Jeśli istnieje plik konfiguracyjny to program go czyta
- Jeśli nie istnieje plik konfiguracyjny, to program pyta użytkownika o podanie Marki/Modelu, liczby stron i zapisuje te informacje do pliku konfiguracyjnego.

Przykładowy Input:
{"SearchPhrase":"Audi A3","NumberOfPagesRequested":2}

Przykładowy Output:
{"SearchPhrase":"Audi A3","NumberOfItems":40,"AveragePrice":10245.6,"AverageMileage":34040.7,"AverageEngineCapacity":2.65625,"AverageYearOfProduction":2015.0}
