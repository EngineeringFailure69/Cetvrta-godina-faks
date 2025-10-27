def pozitivni(lista = []):
    lista2 = []
    for element in lista:
        if(element > 0):
            #lista2+=[element]
            lista2.append(element)
    print(lista2)

pozitivni(lista = [2, -4, 6, 8, -7, 5])