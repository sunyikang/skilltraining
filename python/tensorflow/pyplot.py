# ternsorflow head used for tf without warning
from __future__ import print_function
import os
os.environ['TF_CPP_MIN_LOG_LEVEL']='2'
import tensorflow as tf
# ternsorflow head used for tf without warning

  
# Importing the NumPy library 
import numpy as np 
  
# Importing the matplotlib.pylot function 
import matplotlib.pyplot as plt 
  
# Two vector each of size 20 with values from 0 to 10 
a = np.linspace(0, 10, 20) 
  
# Applying the reciprocal function and 
# storing the result in 'b' 
b = tf.reciprocal(a, name ='reciprocal') 
  
# Initiating a Tensorflow session 
with tf.Session() as sess: 
    print('Input:', a) 
    print('Output:', sess.run(b)) 
    plt.plot(a, sess.run(b), color = 'red', marker ='o') 
    plt.title("tensorflow.reciprocal")  
    plt.xlabel("X")  
    plt.ylabel("Y")  
    plt.grid() 
  
    plt.show() 