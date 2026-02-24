A = [True, True, True, True, False, False, True, False, True, True, True, True, False, True, True, True, True, False]
B = [] #ako podniz True vrednosti u A ima paran broj elemenata, upisujem 1, ako ima neparan, upisujem 2

def kreirajB(A=[], B = []):
    B = [
        1 if len(blok) % 2 == 0 else 2 #ako je duzina bloka parna, upisujem 1, ako je  neparna, upisujem 2
        for blok in ''.join('1' if x else '0' for x in A).split('0') #pretvaram u string, 1 za True, 0 za False, i onda radim split po 0 (False)
        if blok #preskacem prazne stringove
    ]
    print(B)
kreirajB(A, B)

def kreirajB1(A = [], B = []):
    counter = 0
    for x in A:
        if  x == True:
            counter+=1
        else:
            if counter!=0:
                if counter % 2 == 0:
                    B.append(1)
                else:
                    B.append(2)
                counter = 0
    if counter!=0:
        if counter % 2 == 0:
            B.append(1)
        elif counter % 2 != 0:
            B.append(2)

    print(B)