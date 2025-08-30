; polja u strukturi kojima se pristupa:

; id -> +0
; left -> +4
; right -> +8
; ----------------------------------------------------------------
; F-ja sum:
; ----------------------------------------------------------------
; Aktivacioni slog za f-ju findNode:

; value
; node
; adresa povratka (ESP + 4)
; vrednost EBP u pozivajucoj f-ji (staro EBP) <- EBP
; current_value
; id
; -------------------------------------------------------------------
; kod:

PUSH EBP
MOV EBP, ESP

; telo f-je

SUB ESP, 8 ; rezervacija prostora za 2 lokalne promenljive
MOV EBX, [EBP + 8] ; hvatam node pokazivac
MOV ECX, [EBX] ; uzimam node -> id
PUSH EAX ; mesto na steku za rezultat f-je getValue
PUSH ECX ; argument funkcije getValue 
CALL getValue
ADD EAP + 4 ; skidanje parametra sa steka
POP EAX ; uzimam rezultat funkcije sa steka
MOV [EBP - 4], EAX ; smestam rezultat funkcije u current_value
MOV EDX, -1
MOV [EBP - 8], EDX ; id = -1
MOV EDX, [EBP + 12]  ; uzimam value

CMP EAX, EDX ;  value == current_value
JNE labela1
;ispunjen uslov
MOV [EBP - 8], ECX ; id = node -> id
JMP kraj

labela1: CMP EDX, EAX ; value > current_value
JB labela2 ; nije ispunjen uslov
MOV ECX, [EBX + 8] ; hvatam node -> right
CMP ECX, 0 ; node - > right != 0
JE labela2 ; nije ispunjen uslov
; ispunjen uslov, rekurzija
MOV EAX, [EBP + 12] ; drugi argument funkcije, value
PUSH EAX
MOV EAX, [EBX + 8] ; prvi argument funkcije, node -> right
PUSH EAX
CALL findNode
ADD ESP, 8 ; skidam oba argumenta sa steka
MOV [EBP - 8], ECX ;  stavljam rezultat u id

labela2: MOV ECX, [EBX + 4]
CMP ECX, 0 ; n->left != 0
JE kraj ; nijee ispunjen uslov
MOV EAX, [EBP + 12] ; drugi argument funkcije, value
PUSH EAX
MOV EAX, [EBX + 4] ; prvi argument funkcije, node -> left
PUSH EAX
CALL findNode
ADD ESP, 8 ; skidam oba argumenta sa steka
MOV [EBP - 8], ECX ;  stavljam rezultat u id

kraj: ; svakako se izvrsava
MOV ECX, [EBP - 8] ; vracam rezultat kroz ECX

MOV ESP, EBP
POP EBP
RET