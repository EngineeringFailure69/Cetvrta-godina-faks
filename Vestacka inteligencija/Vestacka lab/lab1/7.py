def promeni(n, lista = []):
    listb = []
    i=0
    while(i<n):
        listb.append(lista[i]+1)
        i+=1
    while(i<len(lista)):
        listb.append(lista[i]-1)
        i+=1
    print(listb)

promeni(4, lista=[5, 8, 3, 8, 1, 8, 6, 7, 9])