"""
run:    python features/namedtupler.py

namedtuple instances are just as memory efficient as regular tuples because 
they do not have per-instance dictionaries. Each kind of namedtuple is represented 
by its own class, created by using the namedtuple() factory function. 
The arguments are the name of the new class and a string containing the names of the elements.
"""

import collections

Person = collections.namedtuple('Person', 'name age gender')
print('Type of Person:', type(Person))

bob = Person(name='Bob', age=30, gender='male')
print('\nRepresentation:', bob)

jane = Person(name='Jane', age=29, gender='female')
print('\nField by name:', jane.name)

print('\nFields by index:')
for p in [ bob, jane ]:
    print('%s is a %d year old %s' % p)

try:
    x = collections.namedtuple('Person', 'name age gender age')
except:
    print('wrong namedtuple class')

try:
    y = Person(name='Jane', age=29, gender='female', address='xxx')
except:
    print('wrong namedtuple instance')