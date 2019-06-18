# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning


# A 3x4 matrix (2-d tensor).
x = tf.constant([[5, 2, 4, 3], [5, 1, 6, -2], [-1, 3, -1, -2]],
                dtype=tf.int32)

# A 4x2 matrix (2-d tensor).
y = tf.constant([[2, 2], [3, 5], [4, 5], [1, 6]], dtype=tf.int32)

# Multiply `x` by `y`; result is 3x2 matrix.
matrix_multiply_result = tf.matmul(x, y)

print(matrix_multiply_result)


print();
