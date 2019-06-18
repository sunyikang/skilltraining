# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning


a = tf.constant([5, 3, 2, 7, 1, 4])
b = tf.constant([4, 6, 3])
a1 = tf.reshape(a, [2, 3])
b1 = tf.reshape(b, [3, 1])
x = tf.matmul(a1, b1)
print(x.numpy())


print();

