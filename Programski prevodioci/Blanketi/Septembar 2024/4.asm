; polja u strukturi kojima se pristupa:

; data -> +0
; child1 -> +4
; child2 -> +8
; ----------------------------------------------------------------
; F-ja sum:
; ----------------------------------------------------------------
; Aktivacioni slog za f-ju sum:

; rezultat
; root
; adresa povratka (ESP + 4)
; vrednost EBP u pozivajucoj f-ji (staro EBP) <- EBP
; s
; -------------------------------------------------------------------
; kod:

PUSH EBP
MOV EBP, ESP

; telo f-je

SUB ESP, 4 ; rezervacija prostora za lokalnu promenljivu sa
MOV EBX, [EBP + 8] ; hvatam root pokazivac
MOV EAX, [EBX] ; uzimam vrednost root->data
MOV [EBP - 4], EAX ; stavljam root->data u promenljivu s
MOV EAX, [EBX + 4] ; uzimam root->child1
CMP EAX, 0 ; prvi if uslov: root->child1 != 0
JE lab1
; rekurzija
PUSH EAX ; pravim mesto za rezultat na steku
MOV EDX, [EBX + 4] ; parametar f-je
PUSH EDX
CALL sum
ADD ESP + 4 ; skidam  parametar sa steka
POP EAX ; skidam rezultat sa steka i pamtim u EAX
MOV EDX, [EBP - 4] ; uzimam s promenljivu
ADD EAX, EDX ; sabiram vrednost iz s sa rezultatom f-je i pamtim u EAX
MOV [EBP - 4], EAX ; smestam u s

lab1: MOV EAX, [EBX + 8] ; uzimam root->child2
CMP EAX, 0 ; drugi if uslov root->child2 != 0
JE kraj ; preskace se ovaj if ukoliko uslov nije ispunjen
; rekurzija2
PUSH EAX ; rezultat na steku
MOV EDX, [EBX + 8] ; parametar f-je
PUSH EDX
CALL sum
ADD ESP + 4 ; skidam parametar sa steka
POP EAX ; skidam rezultat sa steka i pamtim u EAX
MOV EDX, [EBP - 4] ; uzimam s
ADD EAX, EDX ; sabiram i smestam u EAX
MOV [EBP - 4], EAX ; smestam u s

; ukoliko drugi if uslov nije ispunjen, sekvenca povratka iz funkcije
kraj: MOV EAX, [EBP - 4] ; uzimam vrednost promenljive s i stavljam u EAX
MOV [EBP + 12], EAX ; stavljam vrednost iz s na vrh steka, jer se na taj nacin vraca vrednost iz funkcije

MOV ESP, EBP
POP EBP
RET