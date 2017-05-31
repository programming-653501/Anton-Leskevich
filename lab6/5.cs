#include <iostream> 
#include <cmath> 
#include <string> 
#include <vector> 

typedef unsigned long long ull; //lab 5(5.1.2) 

void sieve(std::vector < long > &primes, long s) 
{ 
s = (s < 7 ? s : 6); 
long count = std::pow(10, s); 
std::vector < bool > v(count, true); 
primes.push_back(2); 
long j; 
for (long i = 3; i < count; i += 2) 
{ 
if (!v[i]) continue; 
primes.push_back(i); 
j = i + i; 
while (j < count) 
{ 
v[j] = false; 
j += i; 
} 
} 
} 

class BigInt 
{ 
public: 
BigInt(int i = 0) 
{ 
firstDigit = new Digit(0); 
firstDigit->NextDigit = new Digit(-1); 
lastDigit = firstDigit->NextDigit; 
} 
void Display() 
{ 
Digit *temp = firstDigit; 
while (temp->value != -1) 
{ 
std::cout « temp->value; 
temp = temp->NextDigit; 
} 
} 
long GetLength() 
{ 
return length; 
} 
void SetValue(std::string s) 
{ 
Digit *temp = firstDigit; 
length = s.length(); 
for (long i = 0; i < s.length(); ++i) 
{ 
AddDigit(temp, (int)s[i] - 48); 
if (i != s.length() - 1) 
{ 
(temp->NextDigit)->PrevDigit = temp; 
temp = temp->NextDigit; 
} 
} 
lastDigit = temp; 
} 
void operator/= (long &d) 
{ 
Divide(true, d); 
} 
friend long operator% (BigInt &A, long &b) 
{ 
return A.Divide(false, b); 
} 
friend bool operator!=(BigInt &A, long b) 
{ 
std::string sa = "", sb = ""; 
Digit *it = A.firstDigit; 
while (it->value != -1) 
{ 
sa += (char)(it->value + 48); 
it = it->NextDigit; 
} 
while (b != 0) 
{ 
sb = (char)((b % 10) + 48) + sb; 
b /= 10; 
} 
return (sa != sb); 
} 
friend bool operator==(BigInt &A, long b) 
{ 
return !(A != b); 
} 

private: 
struct Digit 
{ 
Digit *NextDigit, *PrevDigit; 
short value; 
Digit(short v = -1) : value(v) {}; 
}; 
Digit *firstDigit, *lastDigit; 
long length; 

void AddDigit(Digit *d, long val) 
{ 
if (d->value == -1) 
{ 
d->NextDigit = new Digit(-1); 
(d->NextDigit)->PrevDigit = d; 
} 
d->value = val; 
} 
long Divide(bool isUpdate, long &d) 
{ 
long temp = 0, surplus = 0; 
Digit *it = firstDigit, *itAns, *itAnsFirst; 
itAns = new Digit(-1); 
itAnsFirst = itAns; 
do 
{ 
temp *= 10; 
temp += it->value; 
it = (temp < d ? it->NextDigit : it); 
} while (temp < d && it->value != -1); 
if (temp < d) return temp; 
while (it->value != -1) 
{ 
AddDigit(itAns, temp / d); 
itAns = itAns->NextDigit; 
surplus = temp % d; 
it = it->NextDigit; 
temp = surplus * 10 + it->value; 
} 

if (isUpdate) 
{ 
firstDigit = itAnsFirst; 
lastDigit = itAns; 
} 
return surplus; 
} 
}; 

void Cout_of_del(BigInt &A, std::vector < ull > &f) 
{ 
std::vector < long > primes; 
sieve(primes, (A.GetLength() / 2 + 1)); 
long i = 0; 
int cout_del = 0; 
while (i < primes.size() && A != 1) 
{ 
if ((A % primes[i]) == 0) 
{ 
cout_del ++; 
continue; 
} 
++i; 
} 
std::cout « cout_del; 

} 

bool solve() 
{ 
const long MAX_TIME = 20; 
std::vector < ull > f; 
BigInt A(1); 
std::string s; 
std::cout « "Введите число\n"; 
std::cin » s; 
A.SetValue(s); 
if (A == 0) 
{ 
return false; 
} 
if (A.GetLength() > MAX_TIME) 
{ 
std::cout « "Предполагаемое время работы может быть достаточно большим. Попробуйте другое число. "; 
return true; 
} 
Cout_of_del(A, f); 


} 

int main() 
{ 
setlocale(0, "RU-ru"); 
while (solve()); 
system("pause"); 
return 0; 
}
