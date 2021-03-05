import itertools
import base64
import math
P=[69,45,30,128,38,95,23,73,71,53,82,31,99,111,106,79,
   97,101,107,113,4,25,49,94,44,119,75,76,83,92,17,67,
   88,51,104,81,100,58,102,77,87,103,121,22,123,124,32,59,
   96,55,68,122,8,29,105,20,56,61,11,62,127,2,84,65,
   108,10,66,74,24,80,47,54,3,39,26,117,118,18,57,64,
   14,110,48,93,37,116,70,12,98,28,115,63,91,125,33,6,
   21,114,41,27,90,15,60,50,85,78,126,34,35,5,40,42,
   43,72,7,13,89,1,36,9,19,112,52,109,16,120,86,46]

PI_1=[118, 62, 73, 21, 110, 96, 115, 53, 120, 66, 59, 88, 116, 81, 102, 125,
      31, 78, 121, 56, 97, 44, 7, 69, 22, 75, 100, 90, 54, 3, 12, 47,
      95, 108, 109, 119, 85, 5, 74, 111, 99, 112, 113, 25, 2, 128, 71, 83, 
      23, 104, 34, 123, 10, 72, 50, 57, 79, 38, 48, 103, 58, 60, 92, 80,
      64, 67, 32, 51, 1, 87, 9, 114, 8, 68, 27, 28, 40, 106, 16, 70,
      36, 11, 29, 63, 105, 127, 41, 33, 117, 101, 93, 30, 84, 24, 6, 49,
      17, 89, 13, 37, 18, 39, 42, 35, 55, 15, 19, 65, 124, 82, 14, 122,
      20, 98, 91, 86, 76, 77, 26, 126, 43, 52, 45, 46, 94, 107, 61, 4]

data="02347618"
secret_key="yjayshil"
pswd="ganesha"
def binvalue(val, bitsize): #Return the binary value as a string of the given size 
    binval = bin(val)[2:] if isinstance(val, int) else bin(ord(val))[2:]
    if len(binval) > bitsize:
        raise "binary value larger than the expected size"
    while len(binval) < bitsize:
        binval = "0"+binval #Add as many 0 as needed to get the wanted size
    return binval

def string_to_bit_array(text):#Convert a string into a list of bits
    array = list()
    for char in text:
        binval = binvalue(char, 8)#Get the char value on one byte
        array.extend([int(x) for x in list(binval)]) #Add the bits to the final list
    return array

def bit_array_to_string(array): #Recreate the string from the bit array
    res = ''.join([chr(int(y,2)) for y in [''.join([str(x) for x in _bytes]) for _bytes in  nsplit(array,8)]])   
    return res

def nsplit(s, n):#Split a list into sublists of size "n"
    return [s[k:k+n] for k in range(0, len(s), n)]

def permute(block, table):#Permut the given block using the given table (so generic method)
    return [block[x-1] for x in table]

def generate_subkey(plaintext,secretkey):   # Generate subkey for each round
    m=0
    # RC4_key="w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA=="
    for i in range(len(plaintext)): # calculation M
         m=m+(ord(plaintext[i])*(i+1))
    m=m%len(plaintext)
    for i in range(len(plaintext)): #adding M to each character
        t= (ord(plaintext[i])+m)%256
        plaintext = plaintext[:i] + chr(t) + plaintext[i + 1:]

    final_subkey_string=plaintext+nsplit(secretkey,8)[0]
    temp_arr=string_to_bit_array(final_subkey_string)
    print(temp_arr)
    subkey_bitarray=permute(temp_arr,P)
    r=permute(subkey_bitarray,PI_1)
    
    final_subkey_string=bit_array_to_string(subkey_bitarray)
    print(final_subkey_string,bit_array_to_string(r))
    # final_subkey_string=final_subkey_string.encode('ascii', 'ignore').decode('ascii')
    return len(final_subkey_string)


class algorithm:
    def __init__(self):
        self.pswd=None
        self.subkeys=list()
        self.inputtext=None
    
    # def encrypt(self,key,inputtext)
# ------------------------------------------------------------ TESTING --------------------------------------------------------------------


    print(bit_array_to_string([0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0]))
    print(generate_subkey(data,"w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA=="))
# k=[]
# for i in range(1,129):
#     l=P.index(i)
#     k.append(l+1)
      
# print(k)
