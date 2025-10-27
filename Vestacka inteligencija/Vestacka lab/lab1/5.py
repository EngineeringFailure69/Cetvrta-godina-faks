def zbir(lista = []):
    sumafja=0
    suma = 0
    for element in lista:
        suma += element
    sumafja = sum(lista)
    print(f"Suma pesaka: {suma}")
    print(f"Suma preko sum funkcije: {sumafja}")

zbir(lista = [2, 3, 7, 6, 5])