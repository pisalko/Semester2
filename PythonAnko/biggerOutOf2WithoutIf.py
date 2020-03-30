first = int(input())
bool check = true

for i in range (1, first+1):
 if(first % i == 0):
  check = true
  continue
 if(i == first -1 & !check):
  print(first)
