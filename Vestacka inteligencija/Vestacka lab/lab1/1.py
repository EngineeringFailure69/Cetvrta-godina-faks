def umetni(el, n, lista = []):
    i = 0
    lista += [None]
    #Pomeram elemente liste od kraja do n (pozicija na koju umecem) na desno, da bih oslobodio mesto za novi element
    for i in range(len(lista)-1, n, -1):
        lista[i] = lista[i-1]
    #Ubacujem element na poziciju n
    lista[n] = el
    print(lista)

def umetni2(el, n, lista = []):
    lista.insert(n, el)
    print(lista)
        
umetni(['d',4], 3, lista=[['a',1],'b','c',['e',5,['f', 6]] ])
umetni2(['d',4], 3, lista=[['a',1],'b','c',['e',5,['f', 6]] ])