#include <iostream>
#include <map>
using namespace std;

string WaveSorting(int arr[], const unsigned int size) {

  // code goes here
  map<int,unsigned int> m;
  unsigned int max=0;
  for(unsigned int i=0;i<size;i++)
  {
      map<int,unsigned int>::iterator it;
      if((it=m.find(arr[i]))==m.end())
      {
          it=m.insert(make_pair(arr[i],0)).first;
      }
      if(++(it->second)>max)
      {
          max=it->second;
      }
  }
  return max>size/2?"false":"true";

}

/*
int main() {

  int A[] = {1,2,3,1,2,3,1,2,3,3,3};
  cout << WaveSorting(A,sizeof(A)/sizeof(*A));
  cout << "\n";
  return 0;

}
*/
