from functools import reduce  # Importuje funkciju 'reduce' iz modula 'functools' za koriscenje u heuristici.

# Funkcija pronalazi sledece prazno polje na tabli i proverava specijalne slucajeve.
def pronadjiPolje(t: list[list]) -> tuple:
    nadjenoPolje = False  # Indikator da li je prvo prazno polje vec pronadjeno.
    rezPolje = tuple()  # Drzi koordinate prvog praznog polja.
    for i in range(0, 3):  # Iteracija kroz redove table.
        for j in range(0, 3):  # Iteracija kroz kolone u svakom redu.
            if t[i][j] is None:  # Proverava da li je trenutno polje prazno.
                if nadjenoPolje is False:  # Ako je ovo prvo prazno polje...
                    rezPolje = (i, j)  # Sacuvaj njegove koordinate.
                    nadjenoPolje = True  # Postavi indikator da je pronadjeno.
                # Proverava da li su ostala polja u istom redu popunjena.
                if all(t[i][k] is not None for k in range(0, 3) if k != j):
                    return (i, j), True, False  # Vraca polje i da li je to jedino prazno polje u redu.
                # Proverava da li su ostala polja u istoj koloni popunjena.
                if all(t[k][j] is not None for k in range(0, 3) if k != i):
                    return (i, j), True, True  # Vraca polje i da li je to jedino prazno polje u koloni.
    return rezPolje, False, False  # Vraca prvo pronadjeno prazno polje i oznake za red/kolonu.

# Funkcija koja izracunava heuristiku za odabir sledeceg broja.
def heuristic(cvor: int, polje: tuple, prazno: bool, tabla: list[list], jk: bool) -> int:
    if jk:  # Ako se radi o koloni...
        # Racuna sumu brojeva u koloni, dodaje trenutni cvor, i oduzima od 15.
        H = 15 - reduce(lambda acc, el: acc + el, (tabla[k][polje[1]] for k in range(0, 3) if tabla[k][polje[1]] is not None), cvor)
    else:  # Ako se radi o redu...
        # Racuna sumu brojeva u redu, dodaje trenutni cvor, i oduzima od 15.
        H = 15 - reduce(lambda acc, el: acc + el, (x for x in tabla[polje[0]] if x is not None), cvor)
    if H == 0 and prazno == False:  # Ako je suma tacna, ali polje nije jedino prazno...
        return 100  # Dodaje penal za to sto nije jedinstveno.
    else:
        return H  # Vraca izracunatu heuristiku.

# Funkcija koja popunjava magicni kvadrat koristeci heuristike.
def popuniMagicniKvadrat(tabla: list[list]) -> tuple:
    # Skup brojeva koji su vec popunjeni u tabli.
    obradjeniCvorovi = {el for podlista in tabla for el in podlista if el is not None}
    # Skup brojeva koji jos treba da se popune.
    cvoroviZaObradu = {el for el in range(1, 10) if el not in obradjeniCvorovi}
    # Mapa koja belezi redosled popunjavanja i koordinate gde su brojevi smesteni.
    redosledPopunjavanja = dict()
    
    while len(cvoroviZaObradu) > 0:  # Sve dok postoje brojevi koji treba da se popune...
        trenutniCvor = None  # Trenutno razmatrani broj.
        # Pronalazi sledece prazno polje i proverava specijalne slucajeve.
        praznoPolje, jednoPrazno, jeKolona = pronadjiPolje(tabla)
        for sledeciCvor in cvoroviZaObradu:  # Prolazi kroz sve dostupne brojeve.
            # Bira broj sa najmanjom apsolutnom vrednoscu heuristike.
            if trenutniCvor is None or abs(heuristic(sledeciCvor, praznoPolje, jednoPrazno, tabla, jeKolona)) < abs(heuristic(trenutniCvor, praznoPolje, jednoPrazno, tabla, jeKolona)):
                trenutniCvor = sledeciCvor  # Azurira trenutni broj.
        # Popunjava polje sa izabranim brojem.
        tabla[praznoPolje[0]][praznoPolje[1]] = trenutniCvor
        # Belezi gde je broj smesten.
        redosledPopunjavanja[trenutniCvor] = praznoPolje
        # Uklanja broj iz liste za obradu i dodaje ga u popunjene.
        cvoroviZaObradu.remove(trenutniCvor)
        obradjeniCvorovi.add(trenutniCvor)
    
    return tabla, redosledPopunjavanja  # Vraca popunjenu tablu i redosled popunjavanja.

# Primer pocetne table (magicni kvadrat).
magicniKvadrat = [[1, None, None],  # Delimicno popunjena tabla.
                  [None, None, None],  # Sva polja prazna u ovom redu.
                  [None, None, 3]]  # Donji desni ugao vec popunjen.
# Poziv funkcije i ispis rezultata.
print(popuniMagicniKvadrat(magicniKvadrat))