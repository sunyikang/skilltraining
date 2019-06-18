# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
print();
# ternsorflow head used for tf without warning

def add_vector():
    primes = tf.constant([2, 3, 5, 7, 11, 13], dtype=tf.int32)
    print("primes:", primes)

    ones = tf.ones([6], dtype=tf.int32)
    print("ones:", ones)

    just_beyond_primes = tf.add(primes, ones)
    print("just_beyond_primes:", just_beyond_primes)

    twos = tf.constant([2, 2, 2, 2, 2, 2], dtype=tf.int32)
    primes_doubled = primes * twos
    print("primes_doubled:", primes_doubled)

    with tf.Session() as ses:
        print('primes:', ses.run(primes))
        print('ones:', ses.run(ones))
        print('just_beyond_primes:', ses.run(just_beyond_primes))
        print('primes_doubled:', ses.run(primes_doubled))

add_vector()
print();