def neparni(lista = []):
    i=0
    br = 1
    listb = []
    for i in range(len(lista)):
        if((i+1)%2!=0):
            listb.append(lista[i])
    print(listb)

neparni(lista=[['a', 1], 'b', 'c', 6, ['d', 4, ['e', 5]]])