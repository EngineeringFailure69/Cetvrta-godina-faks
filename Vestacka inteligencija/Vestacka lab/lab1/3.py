def duzina(lista = []):
    i = 0
    for element in lista:
        i = i+1
    print(f"Duzina liste je: {i}")
    return i

def duzina2(lista = []):
    br = len(lista)
    print(f"Duzina2 je {br}")
    return br


duzinaPovratna = duzina(lista = [['a', 1], 'b', 'c', 6, ['d', 4, ['e', 5]]])
duzinaPovratna2 = duzina2(lista = [['a', 1], 'b', 'c', 6, ['d', 4, ['e', 5]]])
print(f"Povratna duzina je: {duzinaPovratna} ")
print(f"Povratna duzina2 je: {duzinaPovratna2} ")