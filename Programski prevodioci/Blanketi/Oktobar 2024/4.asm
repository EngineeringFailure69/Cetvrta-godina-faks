;polja u strukturi kojima se pristupa:

; id -> +0
; price -> +4
; next -> +8
; ----------------------------------------------------------------
; F-ja add_product:
; ----------------------------------------------------------------
; Aktivacioni slog za f-ju add_product:

; max_product_weight
; max_basket_price
; current_price
; p
; adresa povratka
; vrednost EBP i pozivajucoj f-ji (staro EBP) <- EBP
; num_of_products
; weight
; new_basket_price
; -------------------------------------------------------------------
; kod:

PUSH EBP
MOV EBP, ESP
SUB ESP, 12 ; rezervacija za 3 lokalne promenljive 
MOV [EBP - 4], 0 ; inicijalizacija num_of_products
MOV EBX, [EBP + 8] ; hvatam p pokazivac
MOV ECX, [EBX] ; uzimam p->id
PUSH EAX ; alociranje mesta na steku za rezultat calculate_weight f-je
PUSH ECX ; argument za calculate_weight
CALL calculate_weight
ADD ESP, 4 ; skidanje parametara sa steka
POP EAX ; pribavljanje rezultata f-je calculate_weight
MOV [EBP - 8], EAX ; stavljam rezultat u promenljivu weight
MOV EAX, [EBP + 12] ; pomeram current_price u EAX
MOV EDX, [EBX + 4] ; p pokazivac je jos uvek u EBX, i uzimam p->price
ADD EAX, EDX ; sabiram i smestam rezultat u EAX
MOV [EBP - 12], EAX  ; smestam rezultat u new_basket_price
MOV EAX, [EBP-8]
MOV EDX, [EBP+20]
CMP EAX, EDX ; weight < max_product_weight if uslov
JAE lab1 ; ukoliko nije ispunjen uslov
MOV EAX, [EBP - 12]
MOV EDX, [EBP + 16]
CMP EAX, EDX ; new_basket_price < max_basket_price
JAE lab1 ; nije ispunjen uslov
; uslov ispunjen 
MOV EAX, 1
ADD [EBP - 4], EAX ; dodajem 1
MOV EAX, [EBP - 12] ; uzimam new_basket_price
MOV [EBP + 12], EAX ; smestam u current_price

lab1: MOV EAX, [EBX + 8] ; uzimam p->next
CMP EAX, 0 ; p->next != 0
JE kraj
; ispunjen uslov i sada ide rekurzija
MOV EAX, [EBP + 20] ; cetvrti argument
PUSH EAX
MOV EAX, [EBP + 16] ; treci argument
PUSH EAX
MOV EAX, [EBP + 12] ; drugi argument
PUSH EAX
MOV EAX, [EBX + 8] ; prvi argument f-je
PUSH EAX
CALL add_product
ADD ESP, 16 ; skidanje argumenata sa steka
ADD [EBP - 4], ECX ; dodajem rezultat f-je na num_of_products

kraj: ; svakako se izvrsava
MOV ECX, [EBP - 4] ; vracam rezultat kroz ECX

MOV ESP, EBP
POP EBP
RET