def prebroj(lista = []):
    listb = []
    for element in lista:
        listb.append(len(element))
    print(listb)

prebroj(lista = [['a', 1], ['b', 2], ['c'], ['d', 4, 5], ['e', 6, ['f', 8]]])