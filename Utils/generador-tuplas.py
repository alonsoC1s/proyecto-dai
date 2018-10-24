from random import randint

alph = ["a", "b", "c", "d", "e", "f","g","h","i","j","k","l","m","n","o","p","q","r","s","t"]


# Crea 100 Usuarios

def generar_usuarios():
    strBuilder = ""
    for i in range(200):
        dummy = alph[randint(0,19)] + alph[randint(0,19)] + alph[randint(0,19)]+ alph[randint(0,19)]
        str = "insert into Usuario Values ('" + dummy + "','" + dummy + "') \n"
        strBuilder = strBuilder + str

    return strBuilder



def generar_compras():
    strBuilder = ""
    for i in range(200):
        rand_cid = randint(0,17)
        rand_uid = randint(0,300)
        temp = "insert into Compra values ('" + str(rand_cid) + "', '" + str(rand_uid) + "', getdate(), 155); \n"
        strBuilder = strBuilder + temp

    return strBuilder


print(generar_compras())
