from random import randint

alph = ["a", "b", "c", "d", "e", "f","g","h","i","j","k","l","m","n","o","p","q","r","s","t"]
strBuilder = ""

# Crea 100 Usuarios
for i in range(100):
    dummy = alph[randint(0,19)] + alph[randint(0,19)] + alph[randint(0,19)]
    users.append(dummy)
    str = "insert into Usuario Values ('" + dummy + "','" + dummy + "') \n"
    strBuilder = strBuilder + str


print(strBuilder)
