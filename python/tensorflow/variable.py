# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
tf.enable_eager_execution()
print();
# ternsorflow head used for tf without warning


def change_scalar_variable():
    v = tf.contrib.eager.Variable([3])
    print(v.numpy())

    tf.assign(v, [7])
    print(v.numpy())

    v.assign([5])
    print(v.numpy())

def change_matrix_variable():
    v = tf.contrib.eager.Variable([[1, 2, 3], [4, 5, 6]])
    print(v.numpy())

    try:
        print("Assigning [7, 8, 9] to v")
        v.assign([7, 8, 9])
    except ValueError as e:
        print("Exception:", e)

change_scalar_variable()
change_matrix_variable()
print();
