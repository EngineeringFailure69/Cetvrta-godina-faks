# ZAD 1

def parni(lista):
    return {
        "Parni": [broj for broj in lista if broj % 2 == 0],
        "Neparni": [broj for broj in lista if broj % 2 != 0],
    }


print("Zad 1: " + str(parni([1, 7, 2, 4, 5])))

# ZAD 2

def numlista(lista):
    tipovi = {}
    for el in lista:
        tip = type(el).__name__
        if tip not in tipovi:
            tipovi[tip] = []
        tipovi[tip].append(el)
    return tipovi

print("Zad 2: " + str(numlista(["Prvi", "Drugi", 2, 4, [3, 5]])))

# ZAD 3

def uredi(lista,N,value):
    count = N
    for i in range(len(lista)):
        if count == 0:
            lista[i] -= value
        else:
            lista[i] += value
            count -= 1
    return lista

print("Zad 3: " + str(uredi([1, 2, 3, 4, 5], 3, 1)))

# ZAD 4

def zbir(lista):
    return list(map(lambda i: lista[i] + lista[i + 1], range(len(lista) - 1)))

print("Zad 4: " + str(zbir([1, 2, 3, 4, 5])))

# ZAD 5
def brojEl(lista):
    rez = []
    for x in lista:
        if isinstance(x,list):
            rez.append(len(x))
        else:
            rez.append(-1)
    return rez

print("Zad 5: " + str(brojEl([[1, 2], [3, 4, 5], 'el', ['1', 1]])))

# ZAD 6

def razlika(lista1,lista2):
    return [broj for broj in lista1 if broj not in lista2]

print("Zad 6: " + str(razlika([1, 4, 6, "2", "6"], [4, 5, "2"])))

# ZAD 7

def saberi(tuple):
    lista = []
    for x in tuple:
     lista.append(sum(x))

    return lista

print("Zad 7:" + str(saberi([(1, 4, 6), (2, 4), (4, 1)])))

# ZAD 8

def izmeni(lista):
    sum = 0
    nova = []
    for i in range(len(lista)):
        nova.append(sum + lista[i])
        sum += lista[i]
    return nova

print("Zad 8:" + str(izmeni([1, 2, 4, 7, 9])))

# ZAD 9

def prosek(lista):
    listaProsecnih = []
    for x in lista:
        listaProsecnih.append(sum(x) / len(x))
    return listaProsecnih

print("Zad 9: " + str(prosek([[1, 4, 6, 2], [4, 6, 2, 7], [3, 5], [5, 6, 2, 7]])))

# ZAD 10

def izbroj(lista):
    broj = 0
    for el in lista:
        if isinstance(el,list):
            broj += izbroj(el)
        else:
            broj +=1
    return broj

print("Zad 10: " + str(izbroj([1, [1, 3, [2, 4, 5, [5, 5], 4]], [2, 4], 4, 6])))