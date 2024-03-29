
import itertools
import base64
import math
import time
import sys
#matrix used to permutate the plaintext
P=[69,45,30,128,38,95,23,73,71,53,82,31,99,111,106,79,
   97,101,107,113,4,25,49,94,44,119,75,76,83,92,17,67,
   88,51,104,81,100,58,102,77,87,103,121,22,123,124,32,59,
   96,55,68,122,8,29,105,20,56,61,11,62,127,2,84,65,
   108,10,66,74,24,80,47,54,3,39,26,117,118,18,57,64,
   14,110,48,93,37,116,70,12,98,28,115,63,91,125,33,6,
   21,114,41,27,90,15,60,50,85,78,126,34,35,5,40,42,
   43,72,7,13,89,1,36,9,19,112,52,109,16,120,86,46]
#inverse matrix for decryption
PI_1=[118, 62, 73, 21, 110, 96, 115, 53, 120, 66, 59, 88, 116, 81, 102, 125,
      31, 78, 121, 56, 97, 44, 7, 69, 22, 75, 100, 90, 54, 3, 12, 47,
      95, 108, 109, 119, 85, 5, 74, 111, 99, 112, 113, 25, 2, 128, 71, 83, 
      23, 104, 34, 123, 10, 72, 50, 57, 79, 38, 48, 103, 58, 60, 92, 80,
      64, 67, 32, 51, 1, 87, 9, 114, 8, 68, 27, 28, 40, 106, 16, 70,
      36, 11, 29, 63, 105, 127, 41, 33, 117, 101, 93, 30, 84, 24, 6, 49,
      17, 89, 13, 37, 18, 39, 42, 35, 55, 15, 19, 65, 124, 82, 14, 122,
      20, 98, 91, 86, 76, 77, 26, 126, 43, 52, 45, 46, 94, 107, 61, 4]

P1=[15,13,9,31,7,21,27,8,
    5,4,26,10,14,16,17,23,
    2,29,32,20,25,1,3,6,
    19,28,11,18,22,12,30,24]

P1_I=[22, 17, 23, 10, 9, 24, 5, 8,
      3, 12, 27, 30, 2, 13, 1, 14, 
      15, 28, 25, 20, 6, 29, 16, 32,
      21, 11, 7, 26, 18, 31, 4,19]

compression_table=[1,14,17,11,24,60,5,39,
                   2,15,6,21,10,23,19,23,
                   3,26,45,16,7,27,20,13,
                   4,41,52,31,37,47,55,30]


# data="12347681"
# secret_key="yjayshil"
# pswd="ganesha"
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

def xor(l1, l2):#Apply a xor and return the resulting list
    return [x^y for x,y in zip(l1,l2)]

def addPadding(text):#Add padding to the datas using PKCS5 spec.
    pad_len = 16 - (len(text) % 16)
    text += pad_len * chr(pad_len)
    return [text,pad_len]
    
def removePadding(text,pad_len):#Remove the padding of the plain text (it assume there is padding)
    return text[:-pad_len]



   

def generate_subkey(plaintext,secretkey):   # Generate subkey for each round
    m=0 # M value which is added to the plaintext
    # RC4_key="w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA=="
    keys=list()
    key_arr=string_to_bit_array(secretkey[:16])
    for i in range(len(plaintext)): # calculation M
         m=m+(ord(plaintext[i])*(i+1))
    m=m%len(plaintext)
    for i in range(len(plaintext)): #adding M to each character
        t= (ord(plaintext[i])+m)%256
        plaintext = plaintext[:i] + chr(t) + plaintext[i + 1:]
    
    for i in range(len(plaintext)//16):
        plaintext_arr=string_to_bit_array(plaintext[i*16:(i+1)*16])
        temp_arr=xor(plaintext_arr,key_arr)
        keys.append(bit_array_to_string(temp_arr))
    if len(keys)<8:
        diff=8-len(keys)
        for i in range(diff):
            keys.append(keys[i])
    
    return keys

def round(self,plaintext,subkey):
    subkey_L=subkey[:8]
    subkey_R=subkey[8:]
    round_key=""
    plaintext_L=plaintext[:4]
    plaintext_R=plaintext[4:]
    
    if string_to_bit_array(subkey)[0] == 0:
        round_key=subkey_R
    else:
        round_key=subkey_L
    
    #converting strings to bit arrays
    round_key_bit_array=string_to_bit_array(round_key)
    bit_array_L=string_to_bit_array(plaintext_L)
    
    bit_array_R=string_to_bit_array(plaintext_R)
    
    #compresion and XOR operation
    
    round_key_bit_array=permute(round_key_bit_array,compression_table)
    self.roundkeys.append(bit_array_to_string(round_key_bit_array))
    bit_array_R=xor(bit_array_R,round_key_bit_array) #performing XOR operation
    bit_array_R=shift(bit_array_R,1) #shifting bits to left
    
    bit_array_L=xor(bit_array_L,bit_array_R)
    
    
    bit_array_L=permute(bit_array_L,P1)
    encrypted_plaintext_R=bit_array_to_string(bit_array_R)
    encrypted_plaintext_L=bit_array_to_string(bit_array_L)
    result=encrypted_plaintext_R+encrypted_plaintext_L
    
    return result

def reverse_round(plaintext,subkey):
    round_key=""
    plaintext_R=plaintext[:4]
    plaintext_L=plaintext[4:]
   
    
    #converting strings to bit arrays
    round_key_bit_array=string_to_bit_array(subkey)
    bit_array_L=string_to_bit_array(plaintext_L)
    bit_array_R=string_to_bit_array(plaintext_R)
    
    #applying inverse permutation
    bit_array_L=permute(bit_array_L,P1_I)
    bit_array_L=xor(bit_array_L,bit_array_R)
    #applying right shift
    bit_array_R=shift(bit_array_R,-1)
    
    bit_array_R=xor(bit_array_R,round_key_bit_array)
    
    decrypted_plaintext_L=bit_array_to_string(bit_array_L)
    decrypted_plaintext_R=bit_array_to_string(bit_array_R)
    result=decrypted_plaintext_L+decrypted_plaintext_R
    return result

def shift(arr,n):
    return arr[n:]+arr[:n]
    
    
ENCRYPT=1
DECRYPT=0


class algorithm():
    def __init__(self):
        self.pswd=None
        self.subkey=None
        self.subkeys=list()
        self.roundkeys=list()
        self.inputtext=None
        self.ispadding=False
        self.pad_len=0
    
    def perform_check(self,text):
        if len(text)%16!=0:
            text=addPadding(text)
            self.ispadding=True
        return text
    
    def encrypt(self,secret_key,plaintext):
        res=""
        if len(plaintext)%16!=0:
            plaintext,self.pad_len=addPadding(plaintext)
            self.ispadding=True
        self.pswd=secret_key
        self.inputtext=plaintext
        blocks=nsplit(self.inputtext,8)
        round_encrypted_result=None
        self.subkeys=generate_subkey(plaintext,secret_key)
        for block in blocks:
            roundtext=block
            for j in range(8):
                round_encrypted_result=round(self,roundtext,self.subkeys[j])
                roundtext=round_encrypted_result
            
            res+=roundtext
        
        return [res,self.roundkeys,self.pad_len]
    
    def decrypt(self,keys,pad_len,plaintext):
        res=""
        self.roundkeys=keys
        self.inputtext=plaintext
        blocks=nsplit(self.inputtext,8)
        round_decrypted_result=None
        for block in blocks:
            roundtext=block
            for j in range(7,-1,-1):
                round_decrypted_result=reverse_round(roundtext,self.roundkeys[j])
                roundtext=round_decrypted_result
            res+=roundtext
        return removePadding(res,pad_len)
#------------------------------------------------------------TESTING--------------------------------------------------------------------


# s=time.time()
# obj=algorithm()
# e=obj.encrypt("w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA==",data)
# print("--- %s seconds ---" % (time.time() - s))
# print(len(data))
# print(len(e))




def get_text(path):
    f = open(path, "r")
    return f.read()

def write_text(text):
    f=open("D:\\d.txt","w",encoding="utf-8")
    f.write(text)
    f.close()

def write_keys(key):
    f=open("D:\\keys.txt","w",encoding="utf-8")
    f.write(key)
    f.close()

def read_text():
    f=open("D:\\d.txt","r",encoding="utf-8")
    t=f.read()
    return t

def read_keys():
    f=open("D:\\keys.txt","r",encoding="utf-8")
    lines=f.readlines()
    for i in range(8):
        lines[i]=lines[i].replace("\n","")
    return lines

def temp(text):
    f=open("D:\\my.txt","w",encoding="utf-8")
    f.write(text)
    f.close()


def run():
    argv = sys.argv
    obj=algorithm()
    keys=""
    if argv[1] == 'encrypt':
        data=get_text(argv[3])
        res=obj.encrypt(argv[2],data)
        etext=res[0]
        for i in range(8):
            keys=keys+res[1][i] + "\n"
        pad_len=res[2]
        write_text(etext)
        write_keys(keys)
        dec_res=obj.decrypt(res[1],pad_len,etext)
        temp(dec_res)
        print(pad_len)

    if argv[1] == 'decrypt':
        keys=read_keys()
        data=read_text()
        res=obj.decrypt(keys,int(argv[2]),data)
        temp(res)
      

    
if __name__ == '__main__':
    run()
