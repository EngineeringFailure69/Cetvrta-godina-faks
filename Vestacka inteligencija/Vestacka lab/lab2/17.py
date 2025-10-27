def tekst(str):
    return ''.join(c if 'A' <= c <= 'Z' or 'a' <= c <= 'z' or '0' <= c <= '9' else '\\u' + hex(ord(c))[2:].zfill(4) for c in str)

rez = tekst("Otpornost 10Ω.")
print(rez)