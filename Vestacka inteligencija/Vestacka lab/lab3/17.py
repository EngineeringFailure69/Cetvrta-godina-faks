from collections import deque
def kreiraj_graf_sa_heuristikom(graf, ciljni_cvor):
    heuristika = dict() 
    heuristika[ciljni_cvor] = 0
    obidjeni = []
    obidjeni.append(ciljni_cvor)

    red = deque(ciljni_cvor)
    while red:
        trenutni = red.popleft()
        for dest in graf[trenutni]:
            if dest[0] not in obidjeni:
                heuristika[dest[0]] = heuristika[trenutni] + dest[1]
                obidjeni.append(dest[0])
                red.append(dest[0])
            else:
                if heuristika[dest[0]] > heuristika[trenutni] + dest[1]:
                    heuristika[dest[0]] = heuristika[trenutni] + dest[1]

    for dest in heuristika:
        graf[dest] = (graf[dest], heuristika[dest])
    return graf

# Primer korišćenja
originalni_graf = {
    'A': [('B', 1), ('C', 2)],
    'B': [('A', 1), ('D', 2), ('E', 4)],
    'C': [('A', 2), ('F', 9)],
    'D': [('B', 2)],
    'E': [('B', 4), ('F', 3)],
    'F': [('C', 9), ('E', 3), ('G', 5)],
    'G': [('F', 5)]
}

ciljni_cvor = 'A'
graf_sa_heuristikom = kreiraj_graf_sa_heuristikom(originalni_graf, ciljni_cvor)
print(graf_sa_heuristikom)
