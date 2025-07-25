; polja u strukturi kojima se pristupa:

; id -> +0
; type -> +4
; next -> +8
; -----------------------------------------------------------------------
; F-ja calculate_tasks:
; -----------------------------------------------------------------------
; Aktivacioni slog za  f-ju calculate_tasks:

; rezultat
; t
; adresa povratka (ESP + 4)
; vrednost EBP u pozivajucoj f-ji (staro EBP) <- EBP
; res
; -----------------------------------------------------------------------
; kod:

PUSH EBP
MOV EBP, ESP

;telo f-je:

SUB ESP, 4 ; rezervacija prostora za lokalnu promenljivu res
MOV [EBP - 4], 0 ; stavljam 0 u res
MOV EBX, [EBP + 8] ; hvatam t pokazivac
MOV EAX, [EBX + 4] ; uzimam vrednost type i smestam u EAX
CMP EAX, 1 ; prvi if uslov t->type == 1
JNE lab1
MOV EBX, [EBP + 8] ; moze i bez ove naredbe, jer se t pokazivac svakako vec nalazi u EBX, ali neka je za svaki slucaj, zbog ispita
MOV EAX, [EBX] ; uzo sam t->id
PUSH EAX
CALL validate_task ; rezultat je u ECX
ADD ESP, 4
MOV EDX, ECX  ; stavljam rezultat funkcije u EDX, jer je to registar podataka
MOV EAX, [EBP - 4] ; uzimam res promenljivu 
ADD EAX, EDX ; sabiram res sa rezultatom iz f-je validate_task, zbir je u EAX
MOV [EBP - 4], EAX ; smestam rezultat u promenljivu res

lab1: MOV EBX, [EBP + 8] ; ako prvi if nije ispunjen, skace se na ovaj if(t->next!=0), i prolazi se ovde u svakom slucaju, cak iako je prvi if ispunjen, opet moze i bez ove linije, jer se vrednost EBX nije promenila od proslog puta
MOV EAX, [EBX + 8] ; ovo je t->next 
CMP EAX, 0
JE lab2
MOV EBX, [EBP + 8] ; potencijalni visak opet, jer EBX jos uvek nosi pokazivac t
MOV EAX, [EBX + 8] ; opet moze i bez ovoga, jer EAX jos uvek nosi ispravnu vrednost t->next
;rekurzivan poziv
PUSH EAX ; pravimo mesto na  steku za rezultat
MOV EDX, [EBX + 8] ; ovo je parametar f-je
PUSH EDX
CALL calculate_tasks
ADD ESP, 4
POP EAX ; skidamo rezultat sa steka i upisujemo u EAX
MOV EDX, [EBP - 4] ; uzimam res sa steka
MUL EDX  ; mnozim EAX i EDX, i smestam rezultat u EAX
MOV [EBP - 4], EAX

;sekvenca povratka iz f-je:
lab2: MOV EAX, [EBP - 4] ; uzimam vrednost res promenljive i stavljam u EAX 
MOV [EBX + 12], EAX ; stavljam vrednost iz EAX na vrh steka, jer tako funkcija vraca rezultat

MOV ESP, EBP
POP EBP
RET