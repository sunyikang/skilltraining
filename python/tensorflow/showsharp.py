# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning

def show_sharps():
    # A scalar (0-D tensor).
    scalar = tf.zeros([])

    # A vector with 3 elements.
    vector = tf.zeros([3])

    # A matrix with 2 rows and 3 columns.
    matrix = tf.zeros([2, 3])

    print('scalar has shape', scalar.get_shape(), 'and value:\n', scalar.numpy())
    print('vector has shape', vector.get_shape(), 'and value:\n', vector.numpy())
    print('matrix has shape', matrix.get_shape(), 'and value:\n', matrix.numpy())

    some_matrix = tf.constant([[1, 2, 3], [4, 5, 6]], dtype=tf.int32)
    print(some_matrix)
    print("\nvalue of some_matrix is:\n", some_matrix.numpy)

show_sharps()
print();