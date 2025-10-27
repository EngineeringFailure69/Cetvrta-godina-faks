from functools import reduce

def pronadjiPolje(t: list[list]) -> tuple:
    nadjenoPolje = False
    rezPolje = tuple()
    for i in range(0, 3):
        for j in range(0, 3):
            if t[i][j] is None:
                if nadjenoPolje is False:
                    rezPolje = (i, j)
                    nadjenoPolje = True
                if all(t[i][k] is not None for k in range(0 , 3) if k != j):
                    return (i, j), True, False
                if all(t[k][j] is not None for k in range(0, 3) if k != i):
                    return (i, j), True, True
    return rezPolje, False, False

def heuristic(cvor: int, polje: tuple, prazno: bool, tabla: list[list], jk: bool) -> int:
    if jk:
        H = 15 - reduce(lambda acc, el: acc + el, (tabla[k][polje[1]] for k in range(0, 3) if tabla[k][polje[1]] is not None), cvor)
    else:
        H = 15 - reduce(lambda acc, el: acc + el, (x for x in tabla[polje[0]] if x is not None), cvor)
    if H == 0 and prazno == False:
        return 100
    else:
        return H

def popuniMagicniKvadrat(tabla: list[list]) -> tuple:
    obradjeniCvorovi = {el for podlista in tabla for el in podlista if el is not None} 
    cvoroviZaObradu = {el for el in range(1, 10) if el not in obradjeniCvorovi}
    redosledPopunjavanja = dict()
    
    while len(cvoroviZaObradu) > 0:
        trenutniCvor = None
        praznoPolje, jednoPrazno, jeKolona = pronadjiPolje(tabla)
        for sledeciCvor in cvoroviZaObradu:
            if trenutniCvor is None or abs(heuristic(sledeciCvor, praznoPolje, jednoPrazno, tabla, jeKolona)) < abs(heuristic(trenutniCvor, praznoPolje, jednoPrazno, tabla, jeKolona)):
                trenutniCvor = sledeciCvor
        tabla[praznoPolje[0]][praznoPolje[1]] = trenutniCvor
        redosledPopunjavanja[trenutniCvor] = praznoPolje
        cvoroviZaObradu.remove(trenutniCvor)
        obradjeniCvorovi.add(trenutniCvor)
    
    return tabla, redosledPopunjavanja

magicniKvadrat = [[1, None, None],
                  [None, None, None],
                  [None, None, 3]]
print(popuniMagicniKvadrat(magicniKvadrat))
