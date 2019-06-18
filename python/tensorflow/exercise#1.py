# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning

primes = tf.constant([2, 3, 5, 7, 11, 13], dtype=tf.int32)

squared = tf.pow(primes, 2)
print(squared)

one = tf.constant(1, dtype=tf.int32)
print(one)

just_under_primes_squared = squared - one
print(just_under_primes_squared)