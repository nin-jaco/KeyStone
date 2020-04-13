import math

def fib(n):
    gr = (1 + math.sqrt(5)) / 2
    fib_first = (gr**n - (1 - gr)**n) / math.sqrt(5)
    return int(round(fib_first))



#def powLF(n):
#    if n == 1:     return (1, 1)
#    L, F = powLF(n//2)
#    L, F = (L**2 + 5*F**2) >> 1, L*F
#    if n & 1:
#        return ((L + 5*F)>>1, (L + F) >>1)
#    else:
#        return (L, F)

#def fibonacci(n):
#    if n & 1:
#        return powLF(n)[1]
#    else:
#        L, F = powLF(n // 2)
#        return L * F



n = int(input('Enter a value for n: '))
 
#ans = fibonacci(n)
ans = fib(n)
print('The ' + str(n) + 'th value in the Fibonacci sequence is:' + str(ans))