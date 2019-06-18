# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning

def reshaping_1():
    # Create an 8x2 matrix (2-D tensor).
    matrix = tf.constant(
        [[1, 2], [3, 4], [5, 6], [7, 8], [9, 10], [11, 12], [13, 14], [15, 16]],
        dtype=tf.int32)

    reshaped_2x8_matrix = tf.reshape(matrix, [2, 8])
    reshaped_4x4_matrix = tf.reshape(matrix, [4, 4])

    print("Original matrix (8x2):")
    print(matrix.numpy())
    print("Reshaped matrix (2x8):")
    print(reshaped_2x8_matrix.numpy())
    print("Reshaped matrix (4x4):")
    print(reshaped_4x4_matrix.numpy())

def reshaping_2():
    # Create an 8x2 matrix (2-D tensor).
    matrix = tf.constant(
        [[1, 2], [3, 4], [5, 6], [7, 8], [9, 10], [11, 12], [13, 14], [15, 16]],
        dtype=tf.int32)

    reshaped_2x2x4_tensor = tf.reshape(matrix, [2, 2, 4])
    one_dimensional_vector = tf.reshape(matrix, [16])

    print("Original matrix (8x2):")
    print(matrix.numpy())
    print("Reshaped 3-D tensor (2x2x4):")
    print(reshaped_2x2x4_tensor.numpy())
    print("1-D vector:")
    print(one_dimensional_vector.numpy())

reshaping_1()
reshaping_2()
print();
